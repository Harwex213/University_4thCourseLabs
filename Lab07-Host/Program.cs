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
            ServiceHost host = new ServiceHost(typeof(Feed1));
            host.Open();
            Console.WriteLine("Host Open");
            string s = Console.ReadLine();
        }
    }
}
