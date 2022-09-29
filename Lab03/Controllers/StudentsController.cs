using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Xml.Serialization;
using Lab03.DataAccess;
using Lab03.DTOs;
using Lab03.Uri;
using Lab03.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Lab03.Controllers
{
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
            if (request.Like != null)
            {
                studentsQuery = studentsQuery.Where(s => s.Name.ToLower().Contains(request.Like.ToLower()));
            }
            if (request.GlobalLike != null)
            {
                studentsQuery = studentsQuery.Where(s =>
                    (s.Id + s.Name + s.Phone).ToLower().Contains(request.GlobalLike));
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
                    studentsQuery = studentsQuery.Skip(request.Offset.Value * request.Limit.Value);
                }
                studentsQuery = studentsQuery.Take(request.Limit.Value);
            }
            
            return studentsQuery;
        }

        private XmlSerializer GetStudentsXmlSerializer(GetStudentsDto students, string columns)
        {
            XmlSerializer serializer;
            
            if (string.IsNullOrEmpty(columns))
            {
                serializer = new XmlSerializer(students.GetType());
            }
            else
            {
                var studentDtoPropertyAttributes = new XmlAttributes()
                {
                    XmlIgnore = true
                };
                
                var studentDtoAttributes = new XmlAttributeOverrides();
                foreach (var prop in typeof(GetStudentDto).GetProperties())
                {
                    if (!columns.ToLower().Contains(prop.Name.ToLower()) && prop.Name.ToLower() != "links")
                    {
                        studentDtoAttributes.Add(typeof(GetStudentDto), prop.Name, studentDtoPropertyAttributes);
                    }
                }
            
                serializer = new XmlSerializer(students.GetType(), studentDtoAttributes);
            }

            return serializer;
        }

        [HttpGet]
        public IHttpActionResult GetStudents([FromUri] GetStudentsUri request)
        {
            var query = Request.RequestUri.Query;
            var absoluteUri = Request.RequestUri.AbsoluteUri;
            var link = query == "" ? absoluteUri : absoluteUri.Replace(query, string.Empty);
            
            var studentEntities = GetStudentsQuery(request).ToList().Select(studentEntity => new GetStudentDto
            {
                Id = studentEntity.Id,
                Name = studentEntity.Name,
                Phone = studentEntity.Phone,
                Links = GetStudentDto.CreateDefaultLinks(link, studentEntity.Id)
            }).ToList();
            var content = new GetStudentsDto
            {
                Content = studentEntities,
                Links = GetStudentsDto.CreateDefaultLinks(link)
            };

            if (request.MediaType == GetStudentsUri.SupportedMediaTypeResponse.Xml)
            {
                var serializer = GetStudentsXmlSerializer(content, request.Columns);
                var formatter = new XmlMediaTypeFormatter
                {
                    UseXmlSerializer = true
                };
                formatter.SetSerializer(content.GetType(), serializer);
                return Content(HttpStatusCode.OK, content, formatter);
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
                return ResponseBadRequest(ErrorsController.ErrorCodes.StudentEntityNotFound, mediaType,
                    HttpStatusCode.NotFound);
            }

            var query = Request.RequestUri.Query;
            var absoluteUri = Request.RequestUri.AbsoluteUri;
            var link = query == "" ? absoluteUri : absoluteUri.Replace(query, string.Empty);
            var content = new GetStudentDto
            {
                Id = studentEntity.Id,
                Name = studentEntity.Name,
                Phone = studentEntity.Phone,
                Links = GetStudentDto.CreateDefaultLinks(link)
            };

            return ResponseOk(content, mediaType);
        }

        [HttpPost]
        public IHttpActionResult PostStudent([FromBody] PostStudentDto studentDto, 
            [FromUri] GetStudentsUri.SupportedMediaTypeResponse mediaType = GetStudentsUri.SupportedMediaTypeResponse.Json)
        {
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
            var studentEntity = State.DbContext.Students.FirstOrDefault(s => s.Id == id);
            if (studentEntity == null)
            {
                return ResponseBadRequest(ErrorsController.ErrorCodes.StudentEntityNotFound, mediaType,
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
                return ResponseBadRequest(ErrorsController.ErrorCodes.StudentEntityNotFound, mediaType,
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
                return Content<T>(HttpStatusCode.OK, content, Configuration.Formatters.XmlFormatter);
            }
            return Json<T>(content, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }
        
        private IHttpActionResult ResponseBadRequest(int code, GetStudentsUri.SupportedMediaTypeResponse mediaType,
            HttpStatusCode httpCode = HttpStatusCode.BadRequest)
        {
            var content = new ResponseErrorDto
            {
                StatusCode = code,
                Links = ResponseErrorDto.CreateDefaultLinks(code)
            };
            
            if (mediaType == GetStudentsUri.SupportedMediaTypeResponse.Xml)
            {
                return Content(httpCode, content, Configuration.Formatters.XmlFormatter);
            }
            return Content(httpCode, content, Configuration.Formatters.JsonFormatter);
        }
    }
}