using System.Web.Script.Services;
using System.Web.Services;

namespace Lab04.WebServices
{
    public class A
    {
        public string s;
        public int k;
        public float f;
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
