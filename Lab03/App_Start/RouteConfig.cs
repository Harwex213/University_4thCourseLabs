using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Lab03
{
    public class RouteConfig
    {
        public const string ApiPrefix = "api";
        public const string StudentsUri = "students";
        public const string ErrorsUri = "errors";
        
        public static void RegisterHttpRoutes(HttpConfiguration config)
        {
            config.Formatters.XmlFormatter.Indent = true;
            config.Formatters.JsonFormatter.Indent = true;

            config.Routes.MapHttpRoute(
                name: "HomeApi",
                routeTemplate: ApiPrefix,
                defaults: new { controller = "HomeApi" }
            );
            
            config.Routes.MapHttpRoute(
                name: "StudentsApi",
                routeTemplate: ApiPrefix + "/" + StudentsUri + "/{id}",
                defaults: new { controller = "Students", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "ErrorsApi",
                routeTemplate: ApiPrefix + "/" + ErrorsUri + "/{code}",
                defaults: new { controller = "Errors" }
            );
        }
        
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}