using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05_Client
{
    class Program
    {
        private static void DoThings(WCFSimplex.SimplexClient client)
        {
            Console.WriteLine("Add: " + client.Add(12, 32));
            Console.WriteLine("Concat: " + client.Concat("dsdas", 32.32221));

            var sumResult = client.Sum(new WCFSimplex.A
            {
                S = "al",
                K = 17,
                F = 29.2f
            }, new WCFSimplex.A
            {
                S = "eg",
                K = 18,
                F = 17.8f
            });
            Console.WriteLine($"Sum: s = {sumResult.S}, k = {sumResult.K}, f = {sumResult.F}");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Via HTTP:");
            var serviceClient = new WCFSimplex.SimplexClient("httpEndpoint");
            DoThings(serviceClient);
            serviceClient.Close();

            Console.WriteLine("--------------------");
            Console.WriteLine("Via TCP:");
            serviceClient = new WCFSimplex.SimplexClient("tcpEndpoint");
            DoThings(serviceClient);
            serviceClient.Close();
        }
    }
}
