using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarEvents {
    class Program {
        static void Main(string[] args) {
            Car c1 = new Car("SlugBug", 100, 10);

            c1.AboutToBlow += CarIsAlmostDoomed;
           // c1.AboutToBlow += new Car.CarEngineHandler(CarAboutToBlow);
            c1.AboutToBlow += CarAboutToBlow;  //method group conversion works fine

            

            EventHandler<CarEventArgs> d =  CarExploded;
            c1.Exploded += d;

            for (int i = 0; i < 6; i++) {
                c1.Accelerate(20);
            }

            c1.Exploded -= d;

            for (int i = 0; i < 6; i++) {
                c1.Accelerate(20);
            }

            Console.ReadLine();
        }

        static void CarAboutToBlow(object sender, CarEventArgs e) {
            Console.WriteLine("{0} sayy {1}", sender, e.msg);
        }

        static void CarIsAlmostDoomed(object sender, CarEventArgs e) {
            if (sender is Car) {
                Car c = (Car)sender;
                Console.WriteLine("=> Critical message from {0}: {1}", c.PetName, e.msg);
            } else {
                Console.WriteLine("EEEEEEE");
            }

        }

        static void CarExploded(object sender, CarEventArgs e) {
            Console.WriteLine(e.msg);
        }
    }
}
