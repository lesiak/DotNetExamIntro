using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClassExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Car myCar; would cause use of unassigned local variable error
            Car myCar = new Car();
            myCar.PrintState();


            myCar.petName = "Henry";
            myCar.currSpeed = 10;
            for (int i = 0; i<= 10; i++)
            {
                myCar.SpeedUp(5);
                myCar.PrintState();
            }

            Console.WriteLine();
            Car mary = new Car(pn: "Mary");  //nmaed param
            mary.PrintState();

            Car daisy = new Car("Daisy", 25);
            daisy.PrintState();

            Console.WriteLine();

            Motorcycle c = new Motorcycle();
            c.SetDriverName("AAA");
            Console.WriteLine("Rider name is {0}", c.name);
            Console.WriteLine("Rider name is null: {0}", c.name == null);

            Console.WriteLine();
            Console.WriteLine("=> Constructor flow");
            Motorcycle cc = new Motorcycle(5);
            Console.WriteLine();

            Console.WriteLine("=> Optional params instead of constructor chaining");

            Motorcycle1 m1 = new Motorcycle1();
            Motorcycle1 m2 = new Motorcycle1(name: "Tiny");
            Motorcycle1 m3 = new Motorcycle1(7);
            Motorcycle1 m4 = new Motorcycle1(7, "Tiny2");

            Console.WriteLine("Name = {0}, Intensity = {1}", m1.name, m1.driverIntensity);
            Console.WriteLine("Name = {0}, Intensity = {1}", m2.name, m2.driverIntensity);
            Console.WriteLine("Name = {0}, Intensity = {1}", m3.name, m3.driverIntensity);
            Console.WriteLine("Name = {0}, Intensity = {1}", m4.name, m4.driverIntensity);

            Console.ReadLine();
        }
    }
}
