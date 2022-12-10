using Newtonsoft.Json.Linq;

namespace Lab08.JsonRpc.Common
{
    public class Request
    {
        public string JsonRpc { get; set; }
        public string Method { get; set; }
        public JToken Params { get; set; }
        public object Id { get; set; } = "NotSpecified";
    }
}