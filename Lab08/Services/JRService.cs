using Lab08.JsonRpc;
using Lab08.JsonRpc.Common;
using Lab08.JsonRpc.Core;

namespace Lab08.Services
{
    public class TryDivideByZeroException : JsonRpcException
    {
        public override int Code => -32000;
        public override string Message => "Trying divide by zero";
    }

    [JsonRpcService]
    public class JRService : Service
    {
        [JsonRpcMethod]
        public long SetM(string k, long x)
        {
            Context.Session[k] = x;
            return x;
        }
        
        [JsonRpcMethod]
        public long GetM(string k)
        {
            var result = Context.Session[k] is long ? (long)Context.Session[k] : 0;
            return result;
        }
        
        [JsonRpcMethod]
        public long AddM(string k, long x)
        {
            var m = Context.Session[k] is long ? (long)Context.Session[k] : 0;
            var result = m + x;
            Context.Session[k] = result;
            return result;
        }
        
        [JsonRpcMethod]
        public long SubM(string k, long x)
        {
            var m = Context.Session[k] is long ? (long)Context.Session[k] : 0;
            var result = m - x;
            Context.Session[k] = result;
            return result;
        }
        
        [JsonRpcMethod]
        public long MulM(string k, long x)
        {
            var m = Context.Session[k] is long ? (long)Context.Session[k] : 0;
            var result = m * x;
            Context.Session[k] = result;
            return result;
        }

        [JsonRpcMethod]
        public long DivM(string k, long x)
        {
            if (x == 0)
            {
                throw new TryDivideByZeroException();
            }
            var m = Context.Session[k] is long ? (long)Context.Session[k] : 0;
            var result = m / x;
            Context.Session[k] = result;
            return result;
        }

        public override Service Clone()
        {
            return new JRService();
        }
    }
}