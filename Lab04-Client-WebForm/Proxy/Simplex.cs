﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;

// 
// This source code was auto-generated by wsdl, Version=4.8.3928.0.
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.8.3928.0")]
[System.Web.Services.WebServiceAttribute(Namespace="http://koa/")]
[System.Web.Services.WebServiceBindingAttribute(Name="SimplexSoap", Namespace="http://koa/")]
public abstract partial class Simplex : System.Web.Services.WebService {
    
    /// <remarks/>
    [System.Web.Services.WebMethodAttribute()]
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://koa/Add-simplex", RequestElementName="Add-simplex", RequestNamespace="http://koa/", ResponseElementName="Add-simplexResponse", ResponseNamespace="http://koa/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("Add-simplexResult")]
    public abstract int Add(int x, int y);
    
    /// <remarks/>
    [System.Web.Services.WebMethodAttribute()]
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://koa/Concat-simplex", RequestElementName="Concat-simplex", RequestNamespace="http://koa/", ResponseElementName="Concat-simplexResponse", ResponseNamespace="http://koa/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("Concat-simplexResult")]
    public abstract string Concat(string s, double d);
    
    /// <remarks/>
    [System.Web.Services.WebMethodAttribute()]
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://koa/Sum-simplex", RequestElementName="Sum-simplex", RequestNamespace="http://koa/", ResponseElementName="Sum-simplexResponse", ResponseNamespace="http://koa/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("Sum-simplexResult")]
    public abstract A Sum(A a1, A a2);
    
    /// <remarks/>
    [System.Web.Services.WebMethodAttribute()]
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://koa/Adds-simplex", RequestElementName="Adds-simplex", RequestNamespace="http://koa/", ResponseElementName="Adds-simplexResponse", ResponseNamespace="http://koa/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("Adds-simplexResult")]
    public abstract int Adds(int x, int y);
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://koa/")]
public partial class A {
    
    private string sField;
    
    private int kField;
    
    private float fField;
    
    /// <remarks/>
    public string s {
        get {
            return this.sField;
        }
        set {
            this.sField = value;
        }
    }
    
    /// <remarks/>
    public int k {
        get {
            return this.kField;
        }
        set {
            this.kField = value;
        }
    }
    
    /// <remarks/>
    public float f {
        get {
            return this.fField;
        }
        set {
            this.fField = value;
        }
    }
}
