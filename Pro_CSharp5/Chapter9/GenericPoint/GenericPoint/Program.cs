using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericPoint {
    class Program {
        static void Main(string[] args) {
            Point<int> p1 = new Point<int>(10, 11);
            Point<double> p2 = new Point<double>(5.4, 3.3);

            Console.WriteLine(p1);
            Console.WriteLine(p2);

            p1.ResetPoint();
            p2.ResetPoint();

            Console.WriteLine(p1);
            Console.WriteLine(p2);


            Console.ReadLine();
        }
    }

    class MyGenericClass<T> where T : new() { 
    }

    /** NOT ssupported
    class BasicMath<T> where T : operator +, operator -, operator *, operator /{
        public T Add(T arg1, T arg2) {
            return arg1 + arg2;
        }

        public T Subtract(T arg1, T arg2) {
            return arg1 - arg2;
        }

        public T Multiply(T arg1, T arg2) {
            return arg1 * arg2;
        }


        public T Divide(T arg1, T arg2) {
            return arg1 / arg2;
        }
    }*/
}
