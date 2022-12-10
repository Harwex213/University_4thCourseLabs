using System.Web.Mvc;
using System.Web.Routing;
using Lab08.JsonRpc;

namespace Lab08
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.Add(new Route("{*route}", new RouteHandler()));
        }
    }
}