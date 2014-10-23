using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosureCapture {
    class Program {
        static void Main(string[] args) {
            List<Action> actions = new List<Action>();

            for (int i = 0; i < 10; ++i)
                actions.Add(() => Console.WriteLine(i));

            foreach (Action a in actions)
                a();


            /*
            int i = 0;
            Action a = () => Console.WriteLine(i);
            i = 1;
            a();*/

            int iTemp = 100;
            Action dlg = delegate
            {
                Console.WriteLine(iTemp);
            };
            //string x = null;
            //Console.WriteLine(x is string); //false
            iTemp = 200;
            dlg();
            Console.ReadLine();
        }
    }
}
