using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplicitlyTypedLocalVars
{
    class Program
    {
        
        static void Main(string[] args)
        {
            DeclareImplicitVars();
            LinqQueryOverInts();
            Console.ReadLine();
        }

        static void DeclareImplicitVars() 
        {
            var myInt = 0;
            var myBool = true;
            var myString = "AAA";
           // var z = null;
           // var y;
            Console.WriteLine(myInt.GetType());
            Console.WriteLine(myBool.GetType());
            Console.WriteLine(myString.GetType());

            var otheInt = myInt;
            Console.WriteLine(myString.ToUpper());
            //myString = 444;
        }

        static void LinqQueryOverInts()
        {
            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };

            var subset = from i in numbers where i < 10 select i;
            Console.WriteLine("Values in subset: ");
            foreach (int i in subset) 
            {
                Console.WriteLine("{0}", i);
            }
            Console.WriteLine();
            Console.WriteLine("subsert is a {0}", subset.GetType());
            
            Console.WriteLine("subsert type name {0}", subset.GetType().Name);
            Console.WriteLine("subsert is in namespace {0}", subset.GetType().Namespace);
            
        }
    }
}
