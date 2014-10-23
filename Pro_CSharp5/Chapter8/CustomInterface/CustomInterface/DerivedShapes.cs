using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterface {
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


    class Hexagon : Shape, IPointy, IDraw3D {
        public Hexagon() { }
        public Hexagon(string name) : base(name) { }
        public override void Draw() {
            Console.WriteLine("Drawing {0} the Hexagon", PetName);
        }
        public byte Points {
            get {
                return 6;
            }
        }
        public void Draw3D() {
            Console.WriteLine("Drawing Hexagon in 3D");
        }
    }
    class ThreDCircle : Circle, IDraw3D {
        public new void Draw()  // shadowing, warn without new keyword
        {
            Console.WriteLine("Drawing a 3D Circle");
            //base.Draw(); Works fine
        }

        public new void NotVirtual()  //WARN
        {
            Console.WriteLine("NotVirtual {0} 3D Circle", PetName);
        }

        public void Draw3D() {
            Console.WriteLine("Drawing Cirdle in 3D");
        }

    }

    class Triangle : Shape, IPointy {
        public Triangle() {

        }

        public Triangle(string name)
            : base(name) {

        }

        public override void Draw() {
            Console.WriteLine("Drawing {0} the rieangle", PetName);
        }

        public byte Points {
            get {
                return 3;
            }
        }
    }
}
