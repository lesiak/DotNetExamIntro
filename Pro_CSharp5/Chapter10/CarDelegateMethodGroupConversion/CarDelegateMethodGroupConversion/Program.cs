using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDelegateMethodGroupConversion {
    class Program {
        static void Main(string[] args) {
            Car c1 = new Car();
            c1.RegisterWithCarEngine(CallMeHere);
            c1.RegisterWithCarEngine(CallMeHere);

            for (int i = 0; i < 6; i++) {
                c1.Accelerate(20);
            }

            c1.UnRegisterWithCarEngine(CallMeHere); //works fine, unregistered one
           //c1.UnRegisterWithCarEngine(CallMeHere); //works fine
            for (int i = 0; i < 6; i++) {
                c1.Accelerate(20);
            }
            Console.ReadLine();
        }

        static void CallMeHere(string msg) {
            Console.WriteLine("=> Massage from Car: {0}", msg);
        }
    }
}
