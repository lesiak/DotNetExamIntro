using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIInheritanceHierarchy {
    class Program {
        static void Main(string[] args) {
        }
    }

    interface IDrawable {
        void Draw();
    }

    interface IPrintable {
        void Print();
        void Draw();
    }

    interface IShape : IDrawable, IPrintable {
        int GetNumberOfSides();
    }

    class Rectange : IShape {

        public int GetNumberOfSides() {
            return 4;
        }

        public void Draw() {
            Console.WriteLine("Drawing");
        }

        public void Print() {
            Console.WriteLine("Printing");
        }
    }

    class Square : IShape {

        public int GetNumberOfSides() {
            return 4;
        }

        void IDrawable.Draw() {
            //Draw to screen
        }

        void IPrintable.Draw() {
            //Draw to printer
        }

        public void Print() {
            //Print
        }


    }
}
