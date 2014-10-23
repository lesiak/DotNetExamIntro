using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Task t = new Task(() =>
            {
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            });
            t.Start();
            t.Wait();
            Console.ReadLine();
        }
    }
}
