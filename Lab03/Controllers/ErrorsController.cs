using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using Lab03.DTOs;
using Lab03.Uri;


namespace Lab03.Controllers
{
    public static class ErrorCodes
    {
        public const string StudentEntityNotFound = "10000";
        public const string StudentEntityBadName = "10001";
        public const string StudentEntityBadPhone = "10002";
    }
    
    public class ErrorsController : ApiController
    {

        public static Dictionary<string, string> Errors { get; } = new Dictionary<string, string>
        {
            { ErrorCodes.StudentEntityNotFound, "Student entity not found" },
            { ErrorCodes.StudentEntityBadName, "Student entity name should contains only symbols" },
            { ErrorCodes.StudentEntityBadPhone, "Student entity name should be valid: 375{29|33|44}XXXXXXXX, where X - only numbers" },
        };

        [HttpGet]
        public IHttpActionResult GetCode(string code, 
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