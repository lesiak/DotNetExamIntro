using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

namespace LateDynamicWithBinding {
    class Program {
        static void Main(string[] args) {
            AddWithReflection();
            AddWithDynamic();

            Console.ReadLine();
        }

        private static void AddWithReflection() {
            Assembly asm = Assembly.Load("MathLibrary");
            try {
                Type math = asm.GetType("MathLibrary.SimpleMath");

                object obj = Activator.CreateInstance(math);

                MethodInfo mi = math.GetMethod("Add");

                object[] args = { 10, 70 };
                Console.WriteLine("result is {0}", mi.Invoke(obj, args));
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

        }

        private static void AddWithDynamic() {
            Assembly asm = Assembly.Load("MathLibrary");
            try {
                Type math = asm.GetType("MathLibrary.SimpleMath");

                dynamic obj = Activator.CreateInstance(math);
                              
                Console.WriteLine("result is {0}", obj.Add(10, 70));
            } catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException ex) {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
