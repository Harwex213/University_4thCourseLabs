﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lab05
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="A", Namespace="http://schemas.datacontract.org/2004/07/Lab05")]
    public partial class A : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private float FField;
        
        private int KField;
        
        private string SField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public float F
        {
            get
            {
                return this.FField;
            }
            set
            {
                this.FField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int K
        {
            get
            {
                return this.KField;
            }
            set
            {
                this.KField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string S
        {
            get
            {
                return this.SField;
            }
            set
            {
                this.SField = value;
            }
        }
    }
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName="ISimplex")]
public interface ISimplex
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISimplex/Add", ReplyAction="http://tempuri.org/ISimplex/AddResponse")]
    int Add(int x, int y);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISimplex/Add", ReplyAction="http://tempuri.org/ISimplex/AddResponse")]
    System.Threading.Tasks.Task<int> AddAsync(int x, int y);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISimplex/Concat", ReplyAction="http://tempuri.org/ISimplex/ConcatResponse")]
    string Concat(string x, double y);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISimplex/Concat", ReplyAction="http://tempuri.org/ISimplex/ConcatResponse")]
    System.Threading.Tasks.Task<string> ConcatAsync(string x, double y);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISimplex/Sum", ReplyAction="http://tempuri.org/ISimplex/SumResponse")]
    Lab05.A Sum(Lab05.A x, Lab05.A y);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISimplex/Sum", ReplyAction="http://tempuri.org/ISimplex/SumResponse")]
    System.Threading.Tasks.Task<Lab05.A> SumAsync(Lab05.A x, Lab05.A y);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface ISimplexChannel : ISimplex, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class SimplexClient : System.ServiceModel.ClientBase<ISimplex>, ISimplex
{
    
    public SimplexClient()
    {
    }
    
    public SimplexClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public SimplexClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public SimplexClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public SimplexClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public int Add(int x, int y)
    {
        return base.Channel.Add(x, y);
    }
    
    public System.Threading.Tasks.Task<int> AddAsync(int x, int y)
    {
        return base.Channel.AddAsync(x, y);
    }
    
    public string Concat(string x, double y)
    {
        return base.Channel.Concat(x, y);
    }
    
    public System.Threading.Tasks.Task<string> ConcatAsync(string x, double y)
    {
        return base.Channel.ConcatAsync(x, y);
    }
    
    public Lab05.A Sum(Lab05.A x, Lab05.A y)
    {
        return base.Channel.Sum(x, y);
    }
    
    public System.Threading.Tasks.Task<Lab05.A> SumAsync(Lab05.A x, Lab05.A y)
    {
        return base.Channel.SumAsync(x, y);
    }
}
