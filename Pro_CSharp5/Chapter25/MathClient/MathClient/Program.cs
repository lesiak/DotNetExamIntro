using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathClient.ServiceReference1;
using System.Threading;

namespace MathClient {
    class Program {
        static void Main(string[] args) {
            using (BasicMathClient proxy = new BasicMathClient()) {
                proxy.Open();
                IAsyncResult result = proxy.BeginAdd(2, 3, ar => {
                    Console.WriteLine("result : {0}", proxy.EndAdd(ar));
                }, null);
                while (!result.IsCompleted) {
                    Console.WriteLine("Client working...");
                    Thread.Sleep(200);
                    
                }
                Console.ReadLine();
            }
            
        }
    }
}
