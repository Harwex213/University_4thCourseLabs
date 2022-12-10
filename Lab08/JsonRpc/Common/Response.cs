using Newtonsoft.Json;

namespace Lab08.JsonRpc.Common
{
    public class Error
    {
        public Error(JsonRpcException exception)
        {
            Code = exception.Code;
            Message = exception.Message;
        }

        public int Code { get; }
        public string Message { get; }
    }
    
    public class Response
    {
        public object Id { get; set; } = null;
        
        public string JsonRpc { get; set; } = Constants.JsonRpcSpecification;
        
        public object Result { get; set; }
        
        [JsonIgnore]
        public bool ResultSpecified { get; set; }
        
        public Error Error { get; set; }
        
        [JsonIgnore]
        public bool ErrorSpecified { get; set; }
    }
}