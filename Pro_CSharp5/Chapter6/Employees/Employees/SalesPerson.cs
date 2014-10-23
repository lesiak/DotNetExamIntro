using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    class SalesPerson : Employee
    {
        public int SalesNumber { get; set; }

        public SalesPerson()
        {

        }

        public SalesPerson(string fullName, int age, int empID, float currPay, string ssn, int numberOfSales) 
            : base(fullName, age, empID, currPay, ssn)
        {
            SalesNumber = numberOfSales;
        }

        public void TestProtectedViaDot() {
            SalesPerson s = new SalesPerson();
            s.empName = "aaa";

            Employee e = new SalesPerson();
            //e.empName = "aaa"; //ERROR, but it workjs fine in Java
        }

        public override sealed void GiveBonus(float amount)
        {
            int salesBonus = 0;
            if (SalesNumber >= 0  && SalesNumber <= 100)
            {
                salesBonus = 10;
            }
            else if (SalesNumber >= 101 && SalesNumber <= 200) 
            {
                salesBonus = 15;
            }
            else 
            {
                salesBonus = 20;
            }
            base.GiveBonus(amount * salesBonus);
        }

    }
}
