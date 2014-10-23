using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

namespace ThreadStats {
    class Program {
        static void Main(string[] args) {
            Thread primaryThread = Thread.CurrentThread;
            primaryThread.Name = "The primary thread";

            Console.WriteLine("Name of current AppDomain: {0}", Thread.GetDomain().FriendlyName);
            Console.WriteLine("ID of current Context: {0}", Thread.CurrentContext.ContextID);

            Console.WriteLine("Thread Name: {0}", primaryThread.Name);
            Console.WriteLine("Has thread started: {0}", primaryThread.IsAlive);
            Console.WriteLine("Priority Level: {0}", primaryThread.Priority);
            Console.WriteLine("Thread State: {0}", primaryThread.ThreadState);

            Console.ReadLine();
        }
    }
}
