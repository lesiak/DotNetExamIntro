using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cancellation {
    class Program {
        static void Main(string[] args) {
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken ct = cts.Token;

           
           // Console.WriteLine(z);
            Task myTask = Task.Run(() => {
                //while (!ct.IsCancellationRequested) {
                //    Console.Write('*');
                //    Thread.Sleep(1000);
                //}
                while (true) {
                    ct.ThrowIfCancellationRequested();
                    Console.Write('*');
                    Thread.Sleep(1000);
                }
            });
            Console.WriteLine("Press key to cancel");
            Console.ReadKey();
            cts.Cancel();
            try {
                myTask.Wait();
            } catch (AggregateException ex) {
                Console.WriteLine(ex);
            }

            Console.ReadLine();
        }
    }
}
                                                   