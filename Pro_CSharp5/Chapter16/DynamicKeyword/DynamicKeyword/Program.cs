using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicKeyword {
    class Program {
        static void Main(string[] args) {
            PrintThreeStrings();
            ChangeDynamicDataType();
            InvokeMembersOnDynamicData();

            Console.ReadLine();
            
        }

        static void PrintThreeStrings() {
            var s1 = "Greetings";
            
            object s2 = "From";
            dynamic s3 = "Minneapolis";

            Console.WriteLine("s1 is of type: {0}", s1.GetType());
            Console.WriteLine("s2 is of type: {0}", s2.GetType());
            Console.WriteLine("s3 is of type: {0}", s3.GetType());
            
            Console.WriteLine();
        }

        static void ChangeDynamicDataType() {
            dynamic t = "Hello";
            Console.WriteLine("t is of type: {0}", t.GetType());

            t = false;
            Console.WriteLine("t is of type: {0}", t.GetType());

            t = new List<int>();
            Console.WriteLine("t is of type: {0}", t.GetType());

            Console.WriteLine();
        }

        static void InvokeMembersOnDynamicData() {
            dynamic textData1 = "Hello";
            Console.WriteLine(textData1.ToUpper());
            try {
                Console.WriteLine(textData1.toupper());
            } catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException ex) {
                Console.WriteLine(ex.Message);
            }

            
        }
    }
}


