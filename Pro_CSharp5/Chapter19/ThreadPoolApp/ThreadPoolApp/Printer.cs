using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPoolApp {
    class Printer {

        private object threadLock = new object();

        public void PrintNumbers() {
            lock (threadLock) {
                Console.WriteLine("-> {0} is executing PrintNumbers()", Thread.CurrentThread.ManagedThreadId);
                for (int i = 0; i < 10; i++) {
                    Random r = new Random();
                    Thread.Sleep(10 * r.Next(5));
                    Console.Write("{0}, ", i);
                }
                Console.WriteLine();
            }
        }
    }

    
}
