using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceNameClash {
    class Program {
        static void Main(string[] args) {
            Octagon oct = new Octagon();
            IDrawToForm itForm = (IDrawToForm)oct;
            IDrawToMemory itMemory = (IDrawToMemory)oct;
            IDrawToPrinter itPrinter = (IDrawToPrinter)oct;

            //oct.Draw(); ERROR, interfaces are implemented explicitely
            itForm.Draw();
            itMemory.Draw();
            itPrinter.Draw();

            Console.ReadLine();
        }
    }

    class Octagon : IDrawToForm, IDrawToMemory, IDrawToPrinter {
       // public void Draw() {
       //     Console.WriteLine("Drawing the Octagon");
       // }


        //public void IDrawToForm.Draw() { ERROR, implicitely private
         void IDrawToForm.Draw() {
            Console.WriteLine("Drawing the Octagon to form");
        }

        void IDrawToMemory.Draw() {
            Console.WriteLine("Drawing the Octagon to memory");
        }

        void IDrawToPrinter.Draw() {
            Console.WriteLine("Drawing the Octagon to printer");
        }
    }

    public interface IDrawToForm {
        void Draw();
    }

    public interface IDrawToMemory {
        void Draw();
    }

    public interface IDrawToPrinter {
        void Draw();
    }
}
