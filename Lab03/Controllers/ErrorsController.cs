using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using Lab03.DTOs;
using Lab03.Uri;


namespace Lab03.Controllers
{
    public class ErrorsController : ApiController
    {
        public class ErrorCodes
        {
            public const int StudentEntityNotFound = 10000;
        }
        
        public static Dictionary<int, string> Errors { get; set; } = new Dictionary<int, string>
        {
            { ErrorCodes.StudentEntityNotFound, "Student entity not found" }
        };

        [HttpGet]
        public IHttpActionResult GetCode(int code, 
            [FromUri] GetStudentsUri.SupportedMediaTypeResponse mediaType = GetStudentsUri.SupportedMediaTypeResponse.Json)
        {
            var content = new GetErrorDto
            {
                Message = Errors.TryGetValue(code, out var errorMessage) ? errorMessage : "Undefined error"
            };
            
            if (mediaType == GetStudentsUri.SupportedMediaTypeResponse.Xml)
            {
                return Content(HttpStatusCode.OK, content, Configuration.Formatters.XmlFormatter);
            }
            return Json(content);
        }
    }
}