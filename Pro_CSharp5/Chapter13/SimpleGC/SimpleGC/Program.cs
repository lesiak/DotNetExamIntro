using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGC {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Estimated bytes on heap {0}", GC.GetTotalMemory(false));

            Console.WriteLine("this OS has {0} object generations", GC.MaxGeneration + 1);


            Car car = new Car("Zippy", 100);
            Console.WriteLine(car);
            Console.WriteLine("Generation of myCar is {0}", GC.GetGeneration(car));

            object[] tonsOfObjects = new object[50000];
            for (int i = 0; i < tonsOfObjects.Length; i++) {
                tonsOfObjects[i] = new object();
            }

            GC.Collect(0, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();

            Console.WriteLine("Generation of myCar is {0}", GC.GetGeneration(car));

            if (tonsOfObjects[9000] != null) {
                Console.WriteLine("Generation of tonsOfObjects[9000] is {0}", GC.GetGeneration(tonsOfObjects[9000]));
            }

            Console.WriteLine("Gen 0 has been swept {0} times", GC.CollectionCount(0));
            Console.WriteLine("Gen 1 has been swept {0} times", GC.CollectionCount(1));
            Console.WriteLine("Gen 2 has been swept {0} times", GC.CollectionCount(2));

            Console.ReadLine();



        }
    }

    class Car {
        public string Name { get; set; }
        public int Speed { get; set; }

        public Car(string name, int speed) {
            this.Name = name;
            this.Speed = speed;
        }
    }
}
