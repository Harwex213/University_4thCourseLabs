using System;
using System.IO;
using System.Web;
using System.Web.SessionState;
using Lab08.JsonRpc.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Lab08.JsonRpc
{
    public class HttpHandler : IHttpHandler, IRequiresSessionState
    {
        public bool IsReusable => false;
            
        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.HttpMethod != "POST")
            {
                context.Response.StatusCode = 404;
                return;
            }

            
            using (var reader = new StreamReader(context.Request.GetBufferlessInputStream()))
            {
                var body = reader.ReadToEnd();
                context.Response.ContentType = "application/json";
                var requestProcessor = new RequestProcessor();
                var result = body.StartsWith("[") ? requestProcessor.ProcessBatch(context, body) 
                    : requestProcessor.ProcessSingle(context, body);
                context.Response.Write(result);
            }
        }
    }
}