using System;
using System.ServiceModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05_Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(Lab05.Simplex));
            host.Open();
            Console.WriteLine($"The service is ready at {host.BaseAddresses[0].AbsoluteUri}");
            Console.ReadLine();
            host.Close();
        }
    }
}
