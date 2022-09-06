using System.Web;
using System.Web.Http;
using Lab02.Core;

namespace Lab02.Controllers
{
    [Route("api")]
    public class DataController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetData()
        {
            return Json(State.GetData());
        }

        [HttpPost]
        public void PostData([FromUri] int result)
        {
            State.Result = result;
        }

        [HttpPut]
        public void PutData([FromUri] int add)
        {
            State.Push(add);
        }

        [HttpDelete]
        public void DeleteData()
        {
            State.Pop();
        }
    }
}