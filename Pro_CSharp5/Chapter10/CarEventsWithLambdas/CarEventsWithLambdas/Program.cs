using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarEventsWithLambdas {
    class Program {
        static void Main(string[] args) {
           
            Car c1 = new Car("SlugBug", 100, 10);

            c1.AboutToBlow += (sender, e) => { Console.WriteLine("Eek!, Going too fast!"); };
            c1.AboutToBlow += (sender, e) => { Console.WriteLine("Message from Car {0}", e.msg); };        
            c1.Exploded += (sender, e) => { Console.WriteLine("Message from Car {0}", e.msg); };


            for (int i = 0; i < 6; i++) {
                c1.Accelerate(20);
            }

           

            Console.ReadLine();
        }


    }
}
