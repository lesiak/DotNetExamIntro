using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection {

    //class MyAttibute : Attribute { }

    class Dog {

        //[MyAttibute]
        //int aaa;

        public string Name { get; set; }

        public void Bark() {
            Console.WriteLine("Woof");
        }

        public static void StaticFoo() {
            Console.WriteLine("Woof");
        }

    }

    class Program {
        static void Main(string[] args) {
            Dog d = new Dog() { Name = "Lassie" };
            TypeInfo ti = typeof(Dog).GetTypeInfo();
            MethodInfo mi = ti.GetMethod("Bark");
            Console.WriteLine("Method Info {0}",mi);
            MethodInfo mis = ti.GetMethod("StaticFoo");
            Console.WriteLine("Static Method Info {0}", mis);
            mi.Invoke(d, null);
            mi.Invoke(d, new object[] {});
            Console.WriteLine();

            PropertyInfo pi = ti.GetProperty("Name");
            Console.WriteLine("Property Info {0}", pi);
            Console.WriteLine(pi.GetValue(d));

            Console.ReadLine();
        }
    }
}
