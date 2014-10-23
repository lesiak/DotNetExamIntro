using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Remoting.Contexts;
using System.Threading;

namespace ObjectContextApp {
    class Program {
        static void Main(string[] args) {

            SportsCar sport1 = new SportsCar();
            Console.WriteLine();

            SportsCar sport2 = new SportsCar();
            Console.WriteLine();

            SportsCarTS synchroSport = new SportsCarTS();


            Console.ReadLine();
        }
    }

    class SportsCar {

        public SportsCar() {
            Context ctx = Thread.CurrentContext;
            Console.WriteLine("{0} object in context {1}", this.ToString(), ctx.ContextID);
            foreach (IContextProperty prop in ctx.ContextProperties) {
                Console.WriteLine("-> Ctx Prop: {0}", prop.Name);
            }
        }
    }

    [Synchronization]
    class SportsCarTS : ContextBoundObject {
        public SportsCarTS() {
            Context ctx = Thread.CurrentContext;
            Console.WriteLine("{0} object in context {1}", this.ToString(), ctx.ContextID);
            foreach (IContextProperty prop in ctx.ContextProperties) {
                Console.WriteLine("-> Ctx Prop: {0}", prop.Name);
            }
        }
    }
}
