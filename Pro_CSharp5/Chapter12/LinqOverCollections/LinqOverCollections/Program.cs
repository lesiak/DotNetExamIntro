using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqOverCollections {
    class Program {
        static void Main(string[] args) {
            List<Car> myCars = new List<Car>() {
                new Car {PetName = "Henry", Color = "Silver", Speed = 100, Make = "BMW"},
                new Car {PetName = "Daisy", Color = "Tan", Speed = 90, Make = "BMW"},
                new Car {PetName = "Mary", Color = "Black", Speed = 55, Make = "VW"},
                new Car {PetName = "Clunker", Color = "Rust", Speed = 5, Make = "Yugo"},
                new Car {PetName = "Melvin", Color = "White", Speed = 43, Make = "Ford"}
            };
            GetFastCars(myCars);
            GetFastBMWs(myCars);
            LinqOverArrayList();
            OfTypeAsFilter();
            Console.ReadLine();
        }

        static void GetFastCars(List<Car> myCars) {
            var fastCars = from c in myCars
                           where c.Speed > 55
                           select c;
            foreach (var car in fastCars) {
                Console.WriteLine("{0} is going at {1}", car.PetName, car.Speed);
            }
            Console.WriteLine();
        }


        static void GetFastBMWs(List<Car> myCars) {
            var fastCars = from c in myCars
                           where c.Speed > 55 && c.Make == "BMW"
                           select c;
            foreach (var car in fastCars) {
                Console.WriteLine("{0} is going at {1}", car.PetName, car.Speed);
            }
            Console.WriteLine();
        }

        static void LinqOverArrayList() {
            ArrayList myCars = new ArrayList() {
                new Car {PetName = "Henry", Color = "Silver", Speed = 100, Make = "BMW"},
                new Car {PetName = "Daisy", Color = "Tan", Speed = 90, Make = "BMW"},
                new Car {PetName = "Mary", Color = "Black", Speed = 55, Make = "VW"},
                new Car {PetName = "Clunker", Color = "Rust", Speed = 5, Make = "Yugo"},
                new Car {PetName = "Melvin", Color = "White", Speed = 43, Make = "Ford"}
            };
            var myCarsGen = myCars.OfType<Car>();
            var fastCars = from c in myCarsGen
                           where c.Speed > 55 && c.Make == "BMW"
                           select c;
            foreach (var car in fastCars) {
                Console.WriteLine("{0} is going at {1}", car.PetName, car.Speed);
            }
            Console.WriteLine();
        }

        static void OfTypeAsFilter() {
            ArrayList myStuff = new ArrayList();
            myStuff.AddRange(new object[] { 10, 400, 8, false, new Car(), "sting data" });
            var myInts = myStuff.OfType<int>();

            foreach (int i in myInts) {
                Console.WriteLine(i);
            }
            Console.WriteLine();
        }
    }
}
