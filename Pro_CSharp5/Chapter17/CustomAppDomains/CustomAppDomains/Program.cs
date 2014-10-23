using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using System.IO;

namespace CustomAppDomains {
    class Program {
        static void Main(string[] args) {
            AppDomain defaultAD = AppDomain.CurrentDomain;
            defaultAD.ProcessExit += (o, s) =>
            {
                Console.WriteLine("Default AD unloaded");
            };
            
            ListAllAssembilesInAppDomain(defaultAD);

            MakeNewAppDomain();

            Console.ReadLine();
        }

        private static void MakeNewAppDomain() {
            AppDomain newAD = AppDomain.CreateDomain("SecondAppDomain");

            try {
                newAD.Load("CarLibrary");
            } catch (FileNotFoundException ex) {
                Console.WriteLine(ex.Message);
            }
            ListAllAssembilesInAppDomain(newAD);

            AppDomain.Unload(newAD);

        }

        private static void ListAllAssembilesInAppDomain(AppDomain appDomain) {            
            var loadedAssemblies = from asm in appDomain.GetAssemblies()
                                       orderby asm.GetName().Name
                                       select asm;
            Console.WriteLine("************************* Assembiles loaded in {0} **", appDomain.FriendlyName);

            foreach (Assembly a in loadedAssemblies) {
                Console.WriteLine("-> Name: {0}", a.GetName().Name);
                Console.WriteLine("-> Version: {0}\n", a.GetName().Version);
            }
        }
    }
}
