using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousMethods {
    class Program {
        static void Main(string[] args) {
            int aboutToBlowCounter = 0;
            Car c1 = new Car("SlugBug", 100, 10);

            c1.AboutToBlow += delegate
            {
                aboutToBlowCounter++;
                Console.WriteLine("Eek!, Going too fast!");
            };

            c1.AboutToBlow += delegate(object sender, CarEventArgs e)
            {
                aboutToBlowCounter++;
                Console.WriteLine("Message from Car {0}", e.msg);
            };



            EventHandler<CarEventArgs> d = delegate(object sender, CarEventArgs e) {
              Console.WriteLine("Message from Car {0}", e.msg);
            };  
            c1.Exploded += d;
            

            for (int i = 0; i < 6; i++) {
                c1.Accelerate(20);
            }

            c1.Exploded -= d;

            for (int i = 0; i < 6; i++) {
                c1.Accelerate(20);
            }

            Console.WriteLine();
            Console.WriteLine("About to blow was fired {0} times", aboutToBlowCounter);

            Console.ReadLine();
        }
    }

}


