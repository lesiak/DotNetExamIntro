using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLambdaExpressions {
    class Program {
        static void Main(string[] args) {
            TraditionalDelegateSyntax();
            AnonymousMethodSyntax();
            LambdaExpressionSyntax();
            Console.ReadLine();
        }

        static void TraditionalDelegateSyntax() {
            //List<int> list = new List<int>();
            //list.AddRange(new int[] { 20, 1, 4, 8, 8, 44 });
            List<int> list = new List<int>() { 20, 1, 4, 8, 9, 44 };

            Predicate<int> callback = new Predicate<int>(IsEvenNumber);
            List<int> evenNumbers = list.FindAll(callback);

            Console.WriteLine("Even numbers");
            foreach (int n in evenNumbers) {
                Console.Write("{0}\t", n);
            }
            Console.WriteLine();
        }

        static void AnonymousMethodSyntax() {            
            List<int> list = new List<int>() { 20, 1, 4, 8, 9, 44 };


            List<int> evenNumbers = list.FindAll(delegate(int i) {
                return (i % 2) == 0;
            });

            Console.WriteLine("Even numbers");
            foreach (int n in evenNumbers) {
                Console.Write("{0}\t", n);
            }
            Console.WriteLine();
        }


        static void LambdaExpressionSyntax() {
            List<int> list = new List<int>() { 20, 1, 4, 8, 9, 44 };

            //List<int> evenNumbers = list.FindAll((int i) => (i % 2) == 0); //with explicit types
            //List<int> evenNumbers = list.FindAll(i => (i % 2) == 0);  //single implicately typedparam -> parentheses can be ommited
            List<int> evenNumbers = list.FindAll(i => {
                Console.WriteLine("Value of i is currently {0}", i);
                return (i % 2) == 0;                                    //must use retyrn
            }); 


            Console.WriteLine("Even numbers");
            foreach (int n in evenNumbers) {
                Console.Write("{0}\t", n);
            }
            Console.WriteLine();
        }

        static bool IsEvenNumber(int i) {
            return (i % 2) == 0;
        }
    }
}
