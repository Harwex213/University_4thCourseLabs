using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace Lab08.JsonRpc.Core
{
    [AttributeUsage(AttributeTargets.Class)]
    public class JsonRpcServiceAttribute : Attribute
    {
        public string Name { get; set; }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class JsonRpcMethodAttribute : Attribute
    {
    }
    
    public class JsonRpcService
    {
        public string Name { get; set; }
        public Service Template { get; set; }
        public Dictionary<string, JsonRpcMethod> Methods { get; set; }
    }

    public class JsonRpcMethod
    {
        public MethodInfo Method { get; set; }
        public List<string> Params { get; set; }
    }

    public static class ServiceCollection
    {
        public static void GetServiceCollection()
        {
            var services = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.BaseType == typeof(Service))
                .Where(t => t.GetCustomAttribute<JsonRpcServiceAttribute>() != null).ToList();

            Services = new Dictionary<string, JsonRpcService>();
            foreach (var service in services)
            {
                var jsonRpcService = new JsonRpcService
                {
                    Template = Activator.CreateInstance(service) as Service
                };

                var attribute = service.GetCustomAttribute<JsonRpcServiceAttribute>();
                jsonRpcService.Name = attribute?.Name ?? service.Name;

                var methods = service.GetMethods(BindingFlags.Instance | BindingFlags.Public)
                    .Where(m => m.GetCustomAttribute<JsonRpcMethodAttribute>() != null).ToList();
                jsonRpcService.Methods = new Dictionary<string, JsonRpcMethod>();
                foreach (var methodInfo in methods)
                {
                    jsonRpcService.Methods.Add(methodInfo.Name, new JsonRpcMethod
                    {
                        Method = methodInfo,
                        Params = methodInfo.GetParameters().Select(p => p.Name).ToList(),
                    });
                }
                
                Services.Add(jsonRpcService.Name, jsonRpcService);
            }
        }

        public static Dictionary<string, JsonRpcService> Services;
    }
}