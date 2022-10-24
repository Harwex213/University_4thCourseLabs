using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Lab04.WebServices
{
    public class IgnoreErrorPropertiesResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
            var properties = new List<string>()
            {
                "InputStream",
                "Filter",
                "Length",
                "Position",
                "ReadTimeout",
                "WriteTimeout",
                "LastActivityDate",
                "LastUpdatedDate",
                "Session"
            };

            if (properties.Contains(property.PropertyName))
            {
                property.Ignored = true;
            }
            return property;
        }
    }

    public class A
    {
        public string s;
        public int k;
        public float f;
    }
    
    public static class Configuration
    {
        public const string LogPath = @"D:\Wordplace\2_Blue\1University\yFourth_course\WebServices\Labs\Lab04\Log\";
    }

    [WebService(Namespace = "http://koa/", Description = "Lab 04")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [ScriptService]
    public class Simplex : WebService
    {
        [WebMethod(MessageName = "Add-simplex", Description = "Summation of 2 int")]
        public int Add(int x, int y)
        {
            return x + y;
        }

        [WebMethod(MessageName = "Concat-simplex", Description = "Concatenation")]
        public string Concat(string s, double d)
        {
            return s + d;
        }

        [WebMethod(MessageName = "Sum-simplex", Description = "Summation of 2 classes of A type")]
        public A Sum(A a1, A a2)
        {
            var now = DateTime.Now;
            var logName = now.ToString("dd.MM.yyyy") + ".log";

            var startMessageLog = "\n----------------------------------\n" + now.ToString("dd.MM.yyyy hh:mm:ss:fff") + ". Request body:\n";
            var request = HttpContext.Current.Request;
            using (var log = File.Open(Configuration.LogPath + logName, FileMode.Append))
            {
                var startMessageLogBytes = Encoding.ASCII.GetBytes(startMessageLog);
                log.Write(startMessageLogBytes, 0, startMessageLogBytes.Length);
                request.InputStream.Seek(0, SeekOrigin.Begin);
                request.InputStream.CopyTo(log);
            }

            return new A
            {
                s = a1.s + a2.s,
                k = a1.k + a2.k,
                f = a1.f + a2.f
            };
        }
        
        [WebMethod(MessageName = "Adds-simplex", Description = "Summation of 2 int, but response in JSON")]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public int Adds(int x, int y)
        {
            return x + y;
        }
    }
}
