using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoProps
{
    class Program
    {
        static void Main(string[] args)
        {
            Car c = new Car("Frank", 50, "red");
            
            c.DisplayStats();

            Garage g = new Garage();
            Console.WriteLine("=> auto properies are initialized to defaults");
            Console.WriteLine("int: {0}", g.NumberOfCars);            
            Console.WriteLine("object is null {0}", g.MyAuto == null);
            Console.ReadLine();
        }   
    }

    class Car
    {
        public string PetName { get; set; }  //auto generated backing field
        public int Speed { get; set; }
        public string Colour { get; set; }
        //public int MyReadOnlyProp { get; } ERROR: auto properties must have both getter and setter

        public Car(string name, int speed, string colour)
        {
            PetName = name;
            Speed = speed;
            Colour = colour;
        }

        public void DisplayStats()
        {
            Console.WriteLine("Car name {0}", PetName);
            Console.WriteLine("Speed {0}", Speed);
            Console.WriteLine("Colour {0}", Colour);
        }
    }

    class Garage
    {
        public int NumberOfCars { get; set; }
        public Car MyAuto { get; set; }
    }
}
