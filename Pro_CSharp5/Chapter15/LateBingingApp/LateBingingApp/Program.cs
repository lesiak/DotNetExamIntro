using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using System.IO;

namespace LateBingingApp {
    class Program {
        static void Main(string[] args) {
            
            try {
                Assembly a = Assembly.Load("CarLibrary");
                Console.WriteLine(a.GlobalAssemblyCache);
                CreateusinglateBinding(a);
                InvokeMethodWithArgsUsingLateBinding(a);
            } catch (FileNotFoundException ex) {
                Console.WriteLine(ex);
            }
            Console.ReadLine();
        }
        static void CreateusinglateBinding(Assembly asm) {
            try {
                Type miniVan = asm.GetType("CarLibrary.MiniVan");
                object obj = Activator.CreateInstance(miniVan);
                Console.WriteLine("Created {0} using late binding", obj);

                MethodInfo mi = miniVan.GetMethod("TurboBoost");
                mi.Invoke(obj, null);

            } catch (Exception ex) {
                Console.WriteLine(ex);
            }
        }

        static void InvokeMethodWithArgsUsingLateBinding(Assembly asm) {
            try {
                Type sport = asm.GetType("CarLibrary.SportsCar");

                object obj = Activator.CreateInstance(sport);

                MethodInfo mi = sport.GetMethod("TurnOnRadio");
                mi.Invoke(obj, new object[] { true, 2 });

            } catch (Exception ex) {
                Console.WriteLine(ex);
                
            }
        }
    }
}
