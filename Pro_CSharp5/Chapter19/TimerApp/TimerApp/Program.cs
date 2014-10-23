using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TimerApp {
    class Program {
        static void Main(string[] args) {
            TimerCallback timeCB = new TimerCallback(PrintTime);

            Timer t = new Timer(timeCB, null, 0, 1000);

            Console.WriteLine("Hit key to terminate...");
            Console.ReadLine();


        }

        static void PrintTime(object state) {
            Console.WriteLine("Time is: {0}", DateTime.Now.ToLongTimeString());
        }
    }
}
