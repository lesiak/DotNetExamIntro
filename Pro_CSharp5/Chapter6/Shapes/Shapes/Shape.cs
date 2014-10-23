using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    abstract class Shape
    {
        public String PetName { get; set; }

        public Shape(string name = "NoName")
        {
            PetName = name;
        }

        public abstract void Draw();
        /*{
            Console.WriteLine("Inside Shape.Draw()");
        }*/ //Cannot declare a body
    }
}
