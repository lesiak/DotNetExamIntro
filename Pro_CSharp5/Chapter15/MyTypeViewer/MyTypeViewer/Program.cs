using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyTypeViewer {
    class Program {
        static void Main(string[] args) {
            //string typeName = "System.Int32";
            string typeName = "System.Collections.Generic.List`1";
            try {
                Type t = Type.GetType(typeName);
                ListVariousStats(t);
                ListFields(t);
                ListProps(t);
                ListMethods(t);
                ListInterfaces(t);
            } catch (Exception e) {
                
                Console.WriteLine("Cannot find type {0}", e.ToString());
            }
            Console.ReadLine();
        }

        static void ListMethods(Type t) {
            Console.WriteLine("***********Methods*************");
            MethodInfo[] mi = t.GetMethods();
            foreach (MethodInfo m in mi) {
               // Console.WriteLine(m);
                string retVal = m.ReturnType.Name;
                StringBuilder paramInfo = new StringBuilder("( ");
                foreach (ParameterInfo pi in m.GetParameters()) {
                    paramInfo.AppendFormat("{0} {1}, ", pi.ParameterType, pi.Name);
                }
                paramInfo.Append(" )");
                Console.WriteLine("->{0} {1} {2}", retVal, m.Name, paramInfo.ToString());
                
            }
            //var methodNames = from m in t.GetMethods() select m.Name;
            //foreach (var name in methodNames) {
            //    Console.WriteLine("->{0}", name);
            //}
            Console.WriteLine();
        }

        static void ListFields(Type t) {
            Console.WriteLine("***********Fields*************");
            
            var fieldNames = from f in t.GetFields() select f.Name;
            foreach (var name in fieldNames) {
                Console.WriteLine("->{0}", name);
            }
            Console.WriteLine();
        }

        static void ListProps(Type t) {
            Console.WriteLine("***********Properties*************");

            var propNames = from p in t.GetProperties() select p.Name;
            foreach (var name in propNames) {
                Console.WriteLine("->{0}", name);
            }
            Console.WriteLine();
        }

        static void ListInterfaces(Type t) {
            Console.WriteLine("***********Interfaces*************");

            var iNames = from i in t.GetInterfaces() select i.Name;
            foreach (var name in iNames) {
                Console.WriteLine("->{0}", name);
            }
            Console.WriteLine();
        }


        static void ListVariousStats(Type t) {
            Console.WriteLine("***********Various Statistics*************");
            Console.WriteLine("Base class is {0}", t.BaseType);
            Console.WriteLine("Is type abstract {0}", t.IsAbstract);
            Console.WriteLine("Is type sealed {0}", t.IsSealed);
            Console.WriteLine("Is type generic definition {0}", t.IsGenericTypeDefinition);
            Console.WriteLine("Is type generic {0}", t.IsGenericType);
            Console.WriteLine("Is type a class {0}", t.IsClass);
            
            Console.WriteLine();
        }
    }
}
