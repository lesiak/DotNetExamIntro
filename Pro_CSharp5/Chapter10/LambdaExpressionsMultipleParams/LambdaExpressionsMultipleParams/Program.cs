using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExpressionsMultipleParams {
    class Program {

        public delegate string VerySimpleDelegate();

        static void Main(string[] args) {
            SimpleMath m = new SimpleMath();
            m.SetMathHandler((msg, result) => {
                Console.WriteLine("Message: {0}, Result: {1}", msg, result);
            });
            m.Add(10, 11);


            //VerySimpleDelegate d = new VerySimpleDelegate(() => "Enjoy your string");
            VerySimpleDelegate d = () => "Enjoy your string";
            Console.WriteLine(d());

            Console.ReadLine();
        }

    }

    class SimpleMath {
         public delegate void MathMessage(string msg, int result);
         private MathMessage mmDelegate;

         public void SetMathHandler(MathMessage target) {
             mmDelegate = target;
         }
         public void Add(int x, int y) {
             if (mmDelegate != null) {
                 mmDelegate("Adding was completed", x + y);
             }
         }
    }
}
