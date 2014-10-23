using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFinalize {
    class Program {
        static void Main(string[] args) {
            MyResourceWrapper a = new MyResourceWrapper();
        }
    }

    class MyResourceWrapper {
        //protected override void Finalize() { } ERROR

        ~MyResourceWrapper() {
            //Console.WriteLine("In destructor");
            Console.Beep();
        }
    }
}
