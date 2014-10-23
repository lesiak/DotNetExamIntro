using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Remoting.Messaging;


namespace AsyncCallbackDelegate {
    public delegate int BinaryOp(int x, int y);

    class Program {

        private static bool isDone = false;

        static void Main(string[] args) {
            Console.WriteLine("Async callback delegate");
            Console.WriteLine("Main invoked on thread {0}", Thread.CurrentThread.ManagedThreadId);

            BinaryOp b = new BinaryOp(Add);

            IAsyncResult iftAR = b.BeginInvoke(10, 10, new AsyncCallback(AddComplete), "custom state object");

            while (!isDone) {
                Thread.Sleep(1000);
                Console.WriteLine("-> Doing more work in main");
            }
            Console.WriteLine("Done...");
            Console.ReadLine();
        }

        static int Add(int x, int y) {
            Console.WriteLine("Add invoked on thread {0}", Thread.CurrentThread.ManagedThreadId);

            Thread.Sleep(5000);
            return x + y;
        }

        static void AddComplete(IAsyncResult itfAR) {
            Console.WriteLine("AddComplete invoked on thread {0}", Thread.CurrentThread.ManagedThreadId);
            
            Console.WriteLine("Your addition is complete");
            string msg = (string)itfAR.AsyncState;
            Console.WriteLine("AsyncState: {0}", msg);

            AsyncResult ar = (AsyncResult)itfAR;           
    

            BinaryOp b = (BinaryOp)ar.AsyncDelegate;
            Console.WriteLine("10 + 10 is {0}", b.EndInvoke(itfAR));

            isDone = true;
        }
    }
}


