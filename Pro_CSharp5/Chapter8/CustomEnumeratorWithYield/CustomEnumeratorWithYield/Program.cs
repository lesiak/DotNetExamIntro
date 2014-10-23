using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEnumeratorWithYield {
    class Program {
        static void Main(string[] args) {
            Garage carLot = new Garage();

            foreach (Car c in carLot) {
                Console.WriteLine("{0} is going {1} MPH", c.PetName, c.CurrentSpeed);
            }

            Console.WriteLine();

            Console.WriteLine("=> Using IEnumerator");
            IEnumerator i = carLot.GetEnumerator();
            i.MoveNext();
            Car myCar = (Car)i.Current;
            Console.WriteLine("{0} is going {1} MPH", myCar.PetName, myCar.CurrentSpeed);

            Console.WriteLine();
            Console.WriteLine("=> Using named iterator");
            foreach (Car c in carLot.GetTheCars(true)) {
                Console.WriteLine("{0} is going {1} MPH", c.PetName, c.CurrentSpeed);
            }


            Console.ReadLine();
        }
    }
}
