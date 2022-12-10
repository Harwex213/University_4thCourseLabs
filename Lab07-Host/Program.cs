using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using Lab07_Library;

namespace Lab07_Host
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:10000/HarwexFeed");
            WebServiceHost svcHost = new WebServiceHost(typeof(Feed1));
            //ServiceHost host = new ServiceHost(typeof(IFeedService));
            svcHost.Open();
            Console.WriteLine("Host Open");
            string s = Console.ReadLine();
        }
    }
}
