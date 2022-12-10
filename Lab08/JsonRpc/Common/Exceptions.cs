using System;

namespace Lab08.JsonRpc.Common
{
    public abstract class JsonRpcException : Exception
    {
        public abstract int Code { get; }
        public new abstract string Message { get; }
    }
    
    public class ParseErrorException : JsonRpcException
    {
        public override int Code => -32700;
        public override string Message => "Parse error";
    }

    public class InvalidRequestException : JsonRpcException
    {
        public override int Code => -32600;
        public override string Message => "Invalid Request";
    }
    
    public class MethodNotFoundException : JsonRpcException
    {
        public override int Code => -32601;
        public override string Message => "Method not found";
    }
    
    public class InvalidParametersException : JsonRpcException
    {
        public override int Code => -32602;
        public override string Message => "Invalid params";
    }
    
    public class InternalErrorException : JsonRpcException
    {
        public override int Code => -32603;
        public override string Message => "Internal error";
    }
}