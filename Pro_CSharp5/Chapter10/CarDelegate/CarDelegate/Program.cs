using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDelegate {
    class Program {
        static void Main(string[] args) {
            Car c1 = new Car("SlugBug", 100, 10);
            //c1.RegisterWithCarEngine(OnCarEngineEvent);          Also works fine, method group conversion
            c1.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent));

            Car.CarEngineHandler handler2 = new Car.CarEngineHandler(OnCarEngineEvent2);
            c1.RegisterWithCarEngine(handler2);

            for (int i = 0; i < 6; i++) {
                c1.Accelerate(20);
            }

            c1.UnRegisterWithCarEngine(handler2);
            for (int i = 0; i < 2; i++) {
                c1.Accelerate(20);
            }

            Console.ReadLine();
        }

        static void OnCarEngineEvent(string msg) {
            Console.WriteLine("**** message from car ******");
            Console.WriteLine("=> {0}", msg);
            Console.WriteLine("****************************\n");
        }

        static void OnCarEngineEvent2(string msg) {
            
            Console.WriteLine("=> {0}", msg.ToUpper());
            
        }
    }
}
