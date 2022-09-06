using System;
using System.Collections.Generic;
using System.Web;
using System.Web.SessionState;

namespace Lab01.Core
{
    public class HttpHandler : IHttpHandler, IRequiresSessionState
    {
        private static readonly Dictionary<string, Action<HttpContext>> Actions = new Dictionary<string, Action<HttpContext>>()
        {
            { "GET", ProcessGet },
            { "POST", ProcessPost },
            { "PUT", ProcessPut },
            { "DELETE", ProcessDelete },
        };

        private const string SessionDataName = "Data";
        private const string PostParamName = "Result";
        private const string DeleteParamName = "Add";

        public static void ProcessGet(HttpContext context)
        {
            var data = context.Session[SessionDataName] as Data;
            var result = State.Result + data.Peek();

            var response = context.Response;
            response.Headers["Content-Type"] = "application/json";
            response.Write("{\n\t\"result\":" + result + "\n}");
        }
        
        public static void ProcessPost(HttpContext context)
        {
            var request = context.Request;
            var newResult = int.Parse(request.Params[PostParamName]);
            State.Result = newResult;
            
            var response = context.Response;
            response.End();
        }
        
        public static void ProcessPut(HttpContext context)
        {
            var request = context.Request;
            var value = int.Parse(request.Params[DeleteParamName]);
            var data = context.Session[SessionDataName] as Data;
            data.Push(value);
            
            var response = context.Response;
            response.End();
        }
        
        public static void ProcessDelete(HttpContext context)
        {
            var data = context.Session[SessionDataName] as Data;
            data.Pop();
            
            var response = context.Response;
            response.End();
        }

        public void ProcessRequest(HttpContext context)
        {
            var request = context.Request;
            var processorFound = Actions.TryGetValue(request.HttpMethod, out var processor);
            if (processorFound == false)
            {
                throw new Exception("Unsupported method");
            }

            if (context.Session[SessionDataName] == null)
            {
                context.Session[SessionDataName] = new Data();
            }
            processor(context);
        }

        public bool IsReusable => false;
    }
}