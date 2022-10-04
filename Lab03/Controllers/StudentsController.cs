using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web.Http;
using Lab03.DataAccess;
using Lab03.DTOs;
using Lab03.Uri;
using Lab03.Utils;
using Newtonsoft.Json;

namespace Lab03.Controllers
{
    public static class HateoasHelper
    {
        public static string BaseLink { private get; set; } = "";
        public static string StudentsLink { get; } = $"{RouteConfig.ApiPrefix}/{RouteConfig.StudentsUri}";
        public static string ErrorsLink { get; } = $"{RouteConfig.ApiPrefix}/{RouteConfig.ErrorsUri}";
        
        public static List<HateoasLinkDto> CreateStudentDto_s()
        {
            var href = $"{BaseLink}/{StudentsLink}";
            
            return new List<HateoasLinkDto>
            {
                new HateoasLinkDto { Rel = "create", Method = "POST", Href = href },
            };
        }
        
        public static List<HateoasLinkDto> CreateStudentDto(int entityId, bool isInternalOfList = false)
        {
            var href = $"{BaseLink}/{StudentsLink}/{entityId}";

            if (isInternalOfList)
            {
                return new List<HateoasLinkDto>
                {
                    new HateoasLinkDto { Rel = "self", Method = "GET", Href = href },
                    new HateoasLinkDto { Rel = "update", Method = "PUT", Href = href },
                    new HateoasLinkDto { Rel = "delete", Method = "DELETE", Href = href },
                };
            }
            
            return new List<HateoasLinkDto>
            {
                new HateoasLinkDto { Rel = "get all", Method = "GET", Href = $"{BaseLink}/{StudentsLink}" },
                new HateoasLinkDto { Rel = "update", Method = "PUT", Href = href },
                new HateoasLinkDto { Rel = "delete", Method = "DELETE", Href = href },
            };
        }
        
        public static List<HateoasLinkDto> CreateResponseError(string code)
        {
            var href = $"{BaseLink}/{ErrorsLink}/{code}";
            
            return new List<HateoasLinkDto>
            {
                new HateoasLinkDto { Rel = "describe", Method = "GET", Href = href },
            };
        }
    }
    
    public class StudentsController : ApiController
    {
        private IQueryable<StudentEntity> GetStudentsQuery(GetStudentsUri request)
        {
            var studentsQuery = (IQueryable<StudentEntity>) State.DbContext.Students;
            if (request.MinId.HasValue)
            {
                studentsQuery = studentsQuery.Where(x => x.Id >= request.MinId);
            }
            if (request.MaxId.HasValue)
            {
                studentsQuery = studentsQuery.Where(s => s.Id <= request.MaxId);
            }
            if (request.GlobalLike != null)
            {
                studentsQuery = studentsQuery.Where(s =>
                    (s.Id + s.Name + s.Phone).ToLower().Contains(request.GlobalLike));
            }
            if (request.Like != null)
            {
                studentsQuery = studentsQuery.Where(s => s.Name.ToLower().Contains(request.Like.ToLower()));
            }
            if (request.Sort.HasValue)
            {
                studentsQuery = studentsQuery.OrderBy(s => s.Name);
            }
            else
            {
                studentsQuery = studentsQuery.OrderBy(s => s.Id);
            }
            if (request.Limit.HasValue)
            {
                if (request.Offset.HasValue)
                {
                    studentsQuery = studentsQuery.Skip(request.Offset.Value);
                }
                studentsQuery = studentsQuery.Take(request.Limit.Value);
            }
            
            return studentsQuery;
        }

        [HttpGet]
        public IHttpActionResult GetStudents([FromUri] GetStudentsUri request)
        {
            void SpecifyStudentDtosProperties(GetStudentsDto students, string columns)
            {
                var columnsLowered = columns.ToLower();
                var studentProps = typeof(GetStudentDto).GetProperties(BindingFlags.Instance | BindingFlags.Public);
                var studentUnselectedProps = studentProps.Where(p => p.IsDefined(typeof(PropertySelectSpecifierAttribute)))
                    .Where(p => columnsLowered.Contains(p.Name.ToLower().Replace("specified", "")) == false)
                    .ToList();

                students.Content = students.Content.Select(s =>
                {
                    foreach (var property in studentUnselectedProps)
                    {
                        property.SetValue(s, false);
                    }
                    return s;
                }).ToList();
            }

            var studentEntities = GetStudentsQuery(request).ToList();
            var studentsDtos = studentEntities.Select(studentEntity => new GetStudentDto
            {
                Id = studentEntity.Id,
                Name = studentEntity.Name,
                Phone = studentEntity.Phone,
                Links = HateoasHelper.CreateStudentDto(studentEntity.Id, true)
            }).ToList();
            var content = new GetStudentsDto
            {
                Content = studentsDtos,
                Links = HateoasHelper.CreateStudentDto_s()
            };

            if (request.MediaType == GetStudentsUri.SupportedMediaTypeResponse.Xml)
            {
                SpecifyStudentDtosProperties(content, request.Columns);
                return Content(HttpStatusCode.OK, content, Configuration.Formatters.XmlFormatter);
            }

            var result = string.IsNullOrEmpty(request.Columns) ?
                JsonConvert.SerializeObject(content) :
                JsonConvert.SerializeObject(content, Formatting.None, new JsonSerializerSettings
                {
                    ContractResolver = new AppJsonContractResolver(
                        request.Columns.Split(',')
                            .Append("Content").Append("Links").Append("Href").Append("Rel").Append("Method")
                            .ToArray())
                });
            return Json(JsonConvert.DeserializeObject(result));
        }
        
        [HttpGet]
        public IHttpActionResult GetStudent(int id, 
            [FromUri] GetStudentsUri.SupportedMediaTypeResponse mediaType = GetStudentsUri.SupportedMediaTypeResponse.Json)
        {
            var studentEntity = State.DbContext.Students.FirstOrDefault(student => student.Id == id);
            if (studentEntity == null)
            {
                return ResponseBadRequest(ErrorCodes.StudentEntityNotFound, mediaType,
                    HttpStatusCode.NotFound);
            }

            var content = new GetStudentDto
            {
                Id = studentEntity.Id,
                Name = studentEntity.Name,
                Phone = studentEntity.Phone,
                Links = HateoasHelper.CreateStudentDto(studentEntity.Id)
            };

            return ResponseOk(content, mediaType);
        }

        [HttpPost]
        public IHttpActionResult PostStudent([FromBody] PostStudentDto studentDto, 
            [FromUri] GetStudentsUri.SupportedMediaTypeResponse mediaType = GetStudentsUri.SupportedMediaTypeResponse.Json)
        {
            if (ModelState.IsValid == false)
            {
                var errorCode = ModelState.First().Value.Errors.First().ErrorMessage;
                return ResponseBadRequest(errorCode, mediaType);
            }
            
            var student = new StudentEntity
            {
                Name = studentDto.Name,
                Phone = studentDto.Phone
            };
            State.DbContext.Students.Add(student);
            State.DbContext.SaveChanges();

            return ResponseOk(string.Empty, mediaType);
        }

        [HttpPut]
        public IHttpActionResult PutStudent(int id, [FromBody] PutStudentDto studentDto, 
            [FromUri] GetStudentsUri.SupportedMediaTypeResponse mediaType = GetStudentsUri.SupportedMediaTypeResponse.Json)
        {
            if (ModelState.IsValid == false)
            {
                var errorCode = ModelState.First(state => state.Value.Errors.Count != 0)
                    .Value.Errors.First().ErrorMessage;
                return ResponseBadRequest(errorCode, mediaType);
            }
            
            var studentEntity = State.DbContext.Students.FirstOrDefault(s => s.Id == id);
            if (studentEntity == null)
            {
                return ResponseBadRequest(ErrorCodes.StudentEntityNotFound, mediaType,
                    HttpStatusCode.NotFound);
            }
            studentEntity.Name = studentDto.Name;
            studentEntity.Phone = studentDto.Phone;
            State.DbContext.SaveChanges();
            
            return ResponseOk(string.Empty, mediaType);
        }

        [HttpDelete]
        public IHttpActionResult DeleteData(int id, 
            [FromUri] GetStudentsUri.SupportedMediaTypeResponse mediaType = GetStudentsUri.SupportedMediaTypeResponse.Json)
        {
            var studentEntity = State.DbContext.Students.FirstOrDefault(s => s.Id == id);
            if (studentEntity == null)
            {
                return ResponseBadRequest(ErrorCodes.StudentEntityNotFound, mediaType,
                    HttpStatusCode.NotFound);
            }
            State.DbContext.Students.Remove(studentEntity);
            State.DbContext.SaveChanges();
            
            return ResponseOk(string.Empty, mediaType);
        }
        
        private IHttpActionResult ResponseOk<T>(T content, GetStudentsUri.SupportedMediaTypeResponse mediaType)
        {
            if (mediaType == GetStudentsUri.SupportedMediaTypeResponse.Xml)
            {
                return Content(HttpStatusCode.OK, content, Configuration.Formatters.XmlFormatter);
            }
            return Json(content, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }
        
        private IHttpActionResult ResponseBadRequest(string code, GetStudentsUri.SupportedMediaTypeResponse mediaType,
            HttpStatusCode httpCode = HttpStatusCode.BadRequest)
        {
            var content = new ResponseErrorDto
            {
                StatusCode = int.Parse(code),
                Links = HateoasHelper.CreateResponseError(code)
            };
            
            if (mediaType == GetStudentsUri.SupportedMediaTypeResponse.Xml)
            {
                return Content(httpCode, content, Configuration.Formatters.XmlFormatter);
            }
            return Content(httpCode, content, Configuration.Formatters.JsonFormatter);
        }
    }
}