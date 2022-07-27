using Remote.Worker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remote.CommandLine
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new WebServer("http://*:5001/");
            Console.WriteLine("Press enter to exit");
            Console.ReadKey();
            server.Dispose();
        }
    }
}
