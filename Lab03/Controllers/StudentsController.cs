using System.Linq;
using System.Net;
using System.Web.Http;
using Lab03.DataAccess;
using Lab03.DTOs;
using Lab03.Uri;

namespace Lab03.Controllers
{
    public class StudentsController : ApiController
    {
        // columns (можно through сэлэкт)

        private IQueryable<StudentEntity> GetStudentsQuery(GetStudentsUri request)
        {
            var studentsQuery = (IQueryable<StudentEntity>) State.DbContext.Students;
            if (request.Limit.HasValue)
            {
                studentsQuery = studentsQuery.Take(request.Limit.Value);
            }
            if (request.Offset.HasValue)
            {
                studentsQuery = studentsQuery.Skip(request.Offset.Value);
            }
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
                    (s.Id + s.Name + s.Phone).Contains(request.GlobalLike));
            }

            return studentsQuery;
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

            return ResponseOk(content, request.MediaType);
        }
        
        [HttpGet]
        public IHttpActionResult GetStudent(int id, 
            [FromUri] GetStudentsUri.SupportedMediaTypeResponse mediaType = GetStudentsUri.SupportedMediaTypeResponse.Json)
        {
            var studentEntity = State.DbContext.Students.FirstOrDefault(student => student.Id == id);
            if (studentEntity == null)
            {
                return Content(HttpStatusCode.NotFound, new ResponseErrorDto
                {
                    StatusCode = ErrorsController.ErrorCodes.StudentEntityNotFound
                });
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
                return ResponseBadRequest(ErrorsController.ErrorCodes.StudentEntityNotFound, mediaType);
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
                return ResponseBadRequest(ErrorsController.ErrorCodes.StudentEntityNotFound, mediaType);
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
            return Json<T>(content);
        }
        
        private IHttpActionResult ResponseBadRequest(int code, GetStudentsUri.SupportedMediaTypeResponse mediaType)
        {
            var content = new ResponseErrorDto
            {
                StatusCode = code
            };
            
            if (mediaType == GetStudentsUri.SupportedMediaTypeResponse.Xml)
            {
                return Content(HttpStatusCode.BadRequest, content, Configuration.Formatters.XmlFormatter);
            }
            return Content(HttpStatusCode.BadRequest, content, Configuration.Formatters.JsonFormatter);
        }
    }
}