using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;
using Lab03.DTOs;
using Lab03.Uri;

namespace Lab03.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string msg)
        {
            ViewBag.Msg = msg;
            return View();
        }
    }
    
    public class HomeApiController : ApiController
    {
        public IHttpActionResult GetControllers()
        {
            HateoasHelper.BaseLink = Request.RequestUri.Scheme + "://" + Request.RequestUri.Authority;
            
            var host = Request.RequestUri.AbsoluteUri;
            
            return Json(new List<HateoasLinkDto>
            {
                new HateoasLinkDto { Rel = "students", Method = "GET", Href = host + "/" + RouteConfig.StudentsUri },
                new HateoasLinkDto { Rel = "errors", Method = "GET", Href = host + "/" + RouteConfig.ErrorsUri },
            });
        }
    }
}