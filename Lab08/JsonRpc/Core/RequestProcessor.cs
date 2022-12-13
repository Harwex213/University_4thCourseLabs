using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Lab08.JsonRpc.Common;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Lab08.JsonRpc.Core
{
    public class RequestProcessor
    {
        public string ProcessSingle(HttpContext context, string body)
        {
            try
            {
                var request = JsonConvert.DeserializeObject<Request>(body);
                var response = ProcessSingle(context, request);
                return response == null ? string.Empty : SerializeResponse(response);
            }
            catch (Exception)
            {
                return SerializeResponse(new Response
                {
                    Error = new Error(new ParseErrorException()),
                    ErrorSpecified = true,
                    ResultSpecified = false,
                });
            }
        }
        
        public string ProcessBatch(HttpContext context, string body)
        {
            try
            {
                var requests = JsonConvert.DeserializeObject<Request[]>(body);
                var results = new List<Response>();
                foreach (var request in requests)
                {
                    var result = ProcessSingle(context, request);
                    if (result != null)
                    {
                        results.Add(result);
                    }
                    if (request.Method.Contains("ErrorExit") && (result?.ErrorSpecified == false || result == null))
                    {
                        break;
                    }
                }
                if (results.Count == 0)
                {
                    return string.Empty;
                }
                return JsonConvert.SerializeObject(results, new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });
            }
            catch (Exception)
            {
                return SerializeResponse(new Response
                {
                    Error = new Error(new ParseErrorException()),
                    ErrorSpecified = true,
                    ResultSpecified = false,
                });
            }
        }

        private string SerializeResponse(Response response)
        {
            return JsonConvert.SerializeObject(response, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
        }
        
        private void Validate(Request request)
        {
            if (request.JsonRpc != Constants.JsonRpcSpecification)
            {
                throw new InvalidRequestException();
            }
        }

        private (string serviceName, string methodName) ParseMethod(string method)
        {
            if (method.IsNullOrWhiteSpace())
            {
                throw new InvalidRequestException();
            }
            var split = method.Split('.');
            if (split.Length != 2)
            {
                throw new InvalidRequestException();
            }
            
            return (split[0], split[1]);
        }

        private JsonRpcService GetService(string serviceName)
        {
            if (ServiceCollection.Services.TryGetValue(serviceName, out var service))
            {
                return service;
            }
            throw new MethodNotFoundException();
        }

        private JsonRpcMethod GetMethod(JsonRpcService service, string method)
        {
            if (service.Methods.TryGetValue(method, out var jsonRpcMethod))
            {
                return jsonRpcMethod;
            }
            throw new MethodNotFoundException();
        }

        private object[] GetParameters(JsonRpcMethod method, JToken parameters)
        {
            if (parameters is JObject jObject)
            {
                var nameParams = jObject.ToObject<Dictionary<string, object>>();
                if (nameParams == null)
                {
                    throw new InvalidParametersException();
                }
                if (method.Params.Count != nameParams.Count)
                {
                    throw new InvalidParametersException();
                }
                var result = new object[nameParams.Count];
                foreach (var prop in nameParams)
                {
                    var methodParamIndex = method.Params.FindIndex(p => p == prop.Key);
                    if (methodParamIndex == -1)
                    {
                        throw new InvalidParametersException();
                    }
                    result[methodParamIndex] = prop.Value;
                }

                return result;
            }
            if (parameters is JArray jArray)
            {
                var result = jArray.ToObject<object[]>(new JsonSerializer());
                if (result == null)
                {
                    throw new InvalidParametersException();
                }
                if (method.Params.Count != result.Length)
                {
                    throw new InvalidParametersException();
                }
                return result;
            }
            
            return null;
        }

        private Response ProcessSingle(HttpContext context, Request request)
        {
            try
            {
                Validate(request);
                var (serviceName, methodName) = ParseMethod(request.Method);
                var jsonService = GetService(serviceName);
                var service = jsonService.Template.Clone();
                service.Context = context;
                var jsonRpcMethod = GetMethod(jsonService, methodName);
                var parameters = GetParameters(jsonRpcMethod, request.Params);
                var result = jsonRpcMethod.Method.Invoke(service, parameters);

                if (request.Id is "NotSpecified")
                {
                    return null;
                }
                
                return new Response
                {
                    Id = request.Id,
                    Result = result ?? string.Empty,
                    ResultSpecified = true,
                    ErrorSpecified = false,
                };
            }
            catch (JsonRpcException e)
            {
                return new Response
                {
                    Id = request.Id,
                    Error = new Error(e),
                    ErrorSpecified = true,
                    ResultSpecified = false,
                };
            }
            catch (TargetInvocationException tie)
            {
                if (tie.InnerException is JsonRpcException e)
                {
                    return new Response
                    {
                        Id = request.Id,
                        Error = new Error(e),
                        ErrorSpecified = true,
                        ResultSpecified = false,
                    };
                }
                return new Response
                {
                    Id = request.Id,
                    Error = new Error(new InternalErrorException()),
                    ErrorSpecified = true,
                    ResultSpecified = false,
                };
            }
            catch (Exception)
            {
                return new Response
                {
                    Id = request.Id,
                    Error = new Error(new InternalErrorException()),
                    ErrorSpecified = true,
                    ResultSpecified = false,
                };
            }
        }
    }
}