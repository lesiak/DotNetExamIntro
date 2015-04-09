using System;
using Microsoft.Owin.Hosting;

namespace ConsoleHosting {
    internal class Program {
        private static void Main(string[] args) {
            using (WebApp.Start<Startup>("http://localhost:11111")) {
                Console.WriteLine("Server running at http://localhost:11111");
                Console.ReadLine();
            }
        }
    }
}