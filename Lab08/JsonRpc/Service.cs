using System.Web;

namespace Lab08.JsonRpc
{
    public abstract class Service
    {
        public HttpContext Context { get; set; }

        public abstract Service Clone();
    }
}