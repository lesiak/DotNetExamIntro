using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

namespace DefaultAppDomainApp {
    class Program {
        static void Main(string[] args) {
            InitDAD();
            DisplayDADStats();
            ListAllAssembilesInAppDomain();
            Console.ReadLine();
        }

        private static void InitDAD() {
            AppDomain defaultAD = AppDomain.CurrentDomain;
            defaultAD.AssemblyLoad += (o, s) =>
            {
                Console.WriteLine("{0} has been loaded!", s.LoadedAssembly.GetName().Name);
            };
        }

        private static void DisplayDADStats() {
            AppDomain defaultAD = AppDomain.CurrentDomain;

            Console.WriteLine("Name of this domain: {0}", defaultAD.FriendlyName);
            Console.WriteLine("Id of domain in this process: {0}", defaultAD.Id);
            Console.WriteLine("Is default domain: {0}", defaultAD.IsDefaultAppDomain());
            Console.WriteLine("Base directory of domain: {0}", defaultAD.BaseDirectory);
            Console.WriteLine();
        }

        private static void ListAllAssembilesInAppDomain() {
            AppDomain defaultAD = AppDomain.CurrentDomain;
            Assembly[] loadedAssemblies = defaultAD.GetAssemblies();
            Console.WriteLine("** Assembiles loaded in {0} **", defaultAD.FriendlyName);

            foreach (Assembly a in loadedAssemblies) {
                Console.WriteLine("-> Name: {0}", a.GetName().Name);
                Console.WriteLine("-> Version: {0}\n", a.GetName().Version);
            }
        }
    }
}
