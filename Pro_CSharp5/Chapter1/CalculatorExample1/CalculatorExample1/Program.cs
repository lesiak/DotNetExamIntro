using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Windows.Forms;

using System.Threading.Tasks;

namespace CalculatorExample1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Calc c = new Calc();
            int ans = c.Add1(10, 84);
            Console.WriteLine("10 + 84 is " + ans);
            Console.ReadLine();
  //          MsgBox.Show("aa");
        }
    }

    class Calc {
        public int Add1(int x, int y) 
        {
            return x + y;
        }
    }
}
