using System.Web.Mvc;
using System.Web.Routing;
using Lab08.JsonRpc;

namespace Lab08
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.Add(new Route("json-rpc", new RouteHandler()));
            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            
        }
    }
}