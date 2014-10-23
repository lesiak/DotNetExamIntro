using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousTypes {
    class Program {
        static void Main(string[] args) {
            var myCar = new { Color = "pink", Make = "saab", Speed = 55 };
            Console.WriteLine("Mu car is a {0} {1}", myCar.Color, myCar.Make);
            BuildAnonType("BMW", "Black", 90);
            ReflectOverAnonymousType(myCar);
            EqualityTest();

            var purchaseItem = new
            {
                TimeBought = DateTime.Now,
                ItemBought = new { Color = "Red" , Make = "Saab", CurrentSpeed = 55},
                Price = 34.000
            };
            ReflectOverAnonymousType(purchaseItem);

            Console.ReadLine();
        }

        static void BuildAnonType(string make, string color, int currSp) {
            var car = new { Make = make, Color = color, Speed = currSp };
            Console.WriteLine("Yoy have a {0} {1} gpoing {2} MPH", car.Color, car.Make, car.Speed);

            Console.WriteLine("ToString = {0}", car.ToString());
        }

        static void ReflectOverAnonymousType(object obj) {
            Console.WriteLine("obj is an instance ofof {0}", obj.GetType().Name);
            Console.WriteLine("Base class of {0} is {1}", obj.GetType().Name, obj.GetType().BaseType);
            Console.WriteLine("obj.ToString(): {0}", obj.ToString());
            Console.WriteLine("obj.GetHashCode(): {0}", obj.GetHashCode());
            Console.WriteLine();
        }

        static void EqualityTest() {
            var car1 = new { Color = "Pink", Make = "Saab", Speed = 55 };
            var car2 = new { Color = "Pink", Make = "Saab", Speed = 55 };

          

            Console.WriteLine("car1.Equals(car2)? {0}", car1.Equals(car2));
            Console.WriteLine("car1 == car2 ? {0}", car1 == car2);
            Console.WriteLine("car1.GetType().Name == car2.GetType().Name ? {0}", car1.GetType().Name == car2.GetType().Name);
            Console.WriteLine();
            ReflectOverAnonymousType(car1);
            ReflectOverAnonymousType(car2);
        }
    }
}
