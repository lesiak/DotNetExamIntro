using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDataAndMembers
{
    class Program
    {
        static void Main(string[] args)
        {
            SavingsAccount s1 = new SavingsAccount(50);
            SavingsAccount s2 = new SavingsAccount(100);
            SavingsAccount.SetInterestRate(0.8);
            Console.WriteLine("Interest rate is: {0}", SavingsAccount.GetInterestRate());
            
            SavingsAccount s3 = new SavingsAccount(10000.75);


            Console.WriteLine("Interest rate is: {0}", SavingsAccount.GetInterestRate());
            Console.ReadLine();
        }
    }
}
