using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using System.IO;

namespace ExternalAssemblyReflector {
    class Program {
        static void Main(string[] args) {
            //string asmName = "CarLibrary";
            try {
                //Assembly asm = Assembly.Load(asmName); <- Local
                //Assembly asm = Assembly.LoadFrom(asmName); <- CodeBase
                //Assembly asm = Assembly.Load(@"CarLibrary, Version=1.0.0.0, PublicKeyToken=null, Culture="""); must be not shared
                Assembly asm = Assembly.Load(@"CarLibrary, Version=2.0.0.0, PublicKeyToken=12b5e8df9551d760, Culture="""); // shared
                
                DisplayTypesInAsm(asm);
            } catch (Exception ex) {
                Console.WriteLine(ex);
            }
            Console.ReadLine();
        }

        static void DisplayTypesInAsm(Assembly asm) {
            Console.WriteLine("********** Types in Assembly ***********");
            Console.WriteLine("->{0}", asm.FullName);
            Console.WriteLine("Loaded from GAC {0}", asm.GlobalAssemblyCache);
            Console.WriteLine("Asm name {0}", asm.GetName().Name);
            Console.WriteLine("Asm Version {0}", asm.GetName().Version);
            Console.WriteLine("Asm Culture {0}", asm.GetName().CultureInfo.DisplayName);
            Type[] types = asm.GetTypes();

            foreach (Type t in types) {
                Console.WriteLine("Type: {0}" ,t);
            }
            Console.WriteLine();
        }
    }
}
