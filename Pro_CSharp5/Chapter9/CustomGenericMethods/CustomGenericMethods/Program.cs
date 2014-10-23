using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGenericMethods {
    class Program {
        static void Main(string[] args) {
            float af = 0.0f, bf = 0.0f;
            int ai = 0, bi = 0;
            Person p = new Person();
            object o = new object();
            Swap(ref af, ref bf);
            Swap(ref ai, ref bi);
           // Swap<Object>(ref o, ref p);  //ref object could come into person variable ERROR

            DisplayBaseClass<Person>();  //if no argument is available, no inference is possible so type must be stated in code.



            Console.ReadLine();
        }

        static void Swap<T>(ref T a, ref T b) {
            Console.WriteLine("in generic swap for type {0}", typeof(T));
            T temp;
            temp = a;
            a = b;
            b = temp;
        }

        static void Swap(ref int a, ref int b) {
            Console.WriteLine("in int swap");
            int temp;
            temp = a;
            a = b;
            b = temp;
        }

        static void Swap(ref Person a, ref Person b) {
            Console.WriteLine("in person swap");
            Person temp;
            temp = a;
            a = b;
            b = temp;
        }

        static void DisplayBaseClass<T>() {
            Console.WriteLine("Base class of {0} is {1}", typeof(T), typeof(T).BaseType);
        }
    }

    class Person {

    }
}
