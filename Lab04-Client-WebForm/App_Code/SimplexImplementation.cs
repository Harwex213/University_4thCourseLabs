using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Harwex.Models
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.8.3928.0")]
    [System.Web.Services.WebServiceAttribute(Namespace = "http://koa/")]
    [System.Web.Services.WebServiceBindingAttribute(Name = "SimplexSoap", Namespace = "http://koa/")]
    public abstract partial class Simplex : System.Web.Services.WebService
    {

        /// <remarks/>
        [System.Web.Services.WebMethodAttribute()]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://koa/Add-simplex", RequestElementName = "Add-simplex", RequestNamespace = "http://koa/", ResponseElementName = "Add-simplexResponse", ResponseNamespace = "http://koa/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("Add-simplexResult")]
        public abstract int Add(int x, int y);

        /// <remarks/>
        [System.Web.Services.WebMethodAttribute()]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://koa/Concat-simplex", RequestElementName = "Concat-simplex", RequestNamespace = "http://koa/", ResponseElementName = "Concat-simplexResponse", ResponseNamespace = "http://koa/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("Concat-simplexResult")]
        public abstract string Concat(string s, double d);

        /// <remarks/>
        [System.Web.Services.WebMethodAttribute()]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://koa/Sum-simplex", RequestElementName = "Sum-simplex", RequestNamespace = "http://koa/", ResponseElementName = "Sum-simplexResponse", ResponseNamespace = "http://koa/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("Sum-simplexResult")]
        public abstract A Sum(A a1, A a2);

        /// <remarks/>
        [System.Web.Services.WebMethodAttribute()]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://koa/Adds-simplex", RequestElementName = "Adds-simplex", RequestNamespace = "http://koa/", ResponseElementName = "Adds-simplexResponse", ResponseNamespace = "http://koa/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("Adds-simplexResult")]
        public abstract int Adds(int x, int y);
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://koa/")]
    public partial class A
    {

        private string sField;

        private int kField;

        private float fField;

        /// <remarks/>
        public string s
        {
            get
            {
                return this.sField;
            }
            set
            {
                this.sField = value;
            }
        }

        /// <remarks/>
        public int k
        {
            get
            {
                return this.kField;
            }
            set
            {
                this.kField = value;
            }
        }

        /// <remarks/>
        public float f
        {
            get
            {
                return this.fField;
            }
            set
            {
                this.fField = value;
            }
        }
    }

    public class SimplexImplementaion : Simplex
    {
        [return: XmlElement("Add-simplexResult")]
        public override int Add(int x, int y)
        {
            return x + y;
        }

        [return: XmlElement("Adds-simplexResult")]
        public override int Adds(int x, int y)
        {
            return x + y;
        }

        [return: XmlElement("Concat-simplexResult")]
        public override string Concat(string s, double d)
        {
            return s + d;
        }

        [return: XmlElement("Sum-simplexResult")]
        public override A Sum(A a1, A a2)
        {
            return new A
            {
                s = a1.s + a2.s,
                k = a1.k + a2.k,
                f = a1.f + a2.f
            };
        }
    }

    public static class Helper
    {
        public static string Display(this A obj)
        {
            return "f: " + obj.f + "; k: " + obj.k + "; s: " + obj.s + ";";
        }
    }

}