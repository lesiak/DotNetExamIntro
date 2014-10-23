using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClassExample
{
    class Motorcycle
    {
        public int driverIntensity;
        public string name;
        public Motorcycle()
        {
            Console.WriteLine("in default ctor");
        }

        public Motorcycle(int intensity)
            : this(intensity, "")
        {
            Console.WriteLine("in ctor taking an int");
        }


        public Motorcycle(string name) : this(0, name)
        {
            Console.WriteLine("in ctor taking a string");
        }

        public Motorcycle(int intensity,string name)
        {
            Console.WriteLine("in master ctor");
            this.driverIntensity = intensity;
            this.name = name;

        }

        public void SetDriverName(string name)
        {
            ///name = name; compiles, but does not change the field
        }

    }



    class Motorcycle1
    {
        public int driverIntensity;
        public string name;
      
      

       
        public Motorcycle1(int intensity = 0, string name = "")
        {            
            this.driverIntensity = intensity;
            this.name = name;
        }

        
    }
}
