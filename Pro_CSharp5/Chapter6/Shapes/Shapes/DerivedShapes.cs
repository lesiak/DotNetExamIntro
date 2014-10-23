using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes {
    class Circle : Shape {
        public Circle() { }
        public Circle(string name) : base(name) { }

        public override void Draw() {
            Console.WriteLine("Drawing {0} the Circle", PetName);
        }

        public void NotVirtual() {
            Console.WriteLine("NotVirtual {0} the Circle", PetName);
        }


    }


    class Hexagon : Shape {
        public Hexagon() { }
        public Hexagon(string name) : base(name) { }
        public override void Draw() {
            Console.WriteLine("Drawing {0} the Hexagon", PetName);
        }
    }
    class ThreDCircle : Circle {
        public new void Draw()  // shadowing, warn without new keyword
        {
            Console.WriteLine("Drawing a 3D Circle");
            //base.Draw(); Works fine
        }

        public new void NotVirtual()  //WARN
        {
            Console.WriteLine("NotVirtual {0} 3D Circle", PetName);
        }

    }
}
