using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Lab03.Controllers;

namespace Lab03
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_BeginRequest()
        {
            HateoasHelper.BaseLink = Request.Url.Scheme + "://" + Request.Url.Authority;
        }
        
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(RouteConfig.RegisterHttpRoutes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.UseXmlSerializer = true;
        }
    }
}