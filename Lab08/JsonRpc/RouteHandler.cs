using System.Web;
using System.Web.Routing;

namespace Lab08.JsonRpc
{
    public class RouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new HttpHandler();
        }
    }
}