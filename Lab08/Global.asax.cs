using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Lab08.JsonRpc.Core;

namespace Lab08
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ServiceCollection.GetServiceCollection();
        }
    }
}