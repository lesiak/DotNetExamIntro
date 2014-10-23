using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    class Manager : Employee
    {
        public int StockOptions { get; set; }

        public Manager(string fullName, int age, int empID, float currPay, string ssn, int numberOfOpts) 
            : base(fullName, age, empID, currPay, ssn)
        {
            StockOptions = numberOfOpts;
        }       

        public override void GiveBonus(float amount)
        {
            base.GiveBonus(amount);
            Random r = new Random();
            StockOptions += r.Next(500);
        }
    }
}
