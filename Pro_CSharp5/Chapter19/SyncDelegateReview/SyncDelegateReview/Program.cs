using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SyncDelegateReview {

    public delegate int BinaryOp(int x, int y);

    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Synch delegate review");
            Console.WriteLine("Main invoked on thread {0}", Thread.CurrentThread.ManagedThreadId);

            BinaryOp b = new BinaryOp(Add);
            int answer = b(10, 10);

            Console.WriteLine("-> Doing more work in main");
            Console.WriteLine("10 + 10 is {0}", answer);
            
            Console.WriteLine("Async delegate invocation");
            IAsyncResult iftAR = b.BeginInvoke(10, 10, null, null);

         //   while (!iftAR.IsCompleted) {
          //      Console.WriteLine("-> Doing more work in main");
          //      Thread.Sleep(1000);
         //   }
            while (!iftAR.AsyncWaitHandle.WaitOne(1000, true)) {
                Console.WriteLine("-> Doing more work in main");
            }

            int answer1 = b.EndInvoke(iftAR);
            Console.WriteLine("10 + 10 is {0}", answer1);

            Console.WriteLine("Done...");
            Console.ReadLine();
        }

        static int Add(int x, int y) {
            Console.WriteLine("Add invoked on thread {0}", Thread.CurrentThread.ManagedThreadId);

            Thread.Sleep(5000);
            return x + y;
        }
    }
}
