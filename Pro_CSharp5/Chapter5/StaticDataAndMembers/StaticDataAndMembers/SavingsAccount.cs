using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDataAndMembers
{
    class SavingsAccount
    {
        public double currBalance;

        //public static double currInterestRate = GetInitInterestRate(); works fine
        public static double currInterestRate;

        public SavingsAccount(double balance)
        {
            
            currBalance = balance;
        }

        /*public */static SavingsAccount() //AERROR: Access modifieer not allowed
        {
            Console.WriteLine("Ins static ctor");
            currInterestRate = 0.04;
        }

        static double GetInitInterestRate() 
        {
            return 0.04;
        }


        public static void SetInterestRate(double newRate)
        {
            currInterestRate = newRate;
        }

        public static double GetInterestRate()
        {
            return currInterestRate;
        }
    }
}
