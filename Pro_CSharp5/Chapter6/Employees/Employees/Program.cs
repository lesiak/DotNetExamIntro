using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    class Program
    {
        static void Main(string[] args)
        {
            SalesPerson fred = new SalesPerson();
            fred.Age = 31;
            fred.Name = "Fred";
            fred.SalesNumber = 50;

            Manager chucky = new Manager("Chucky", 50, 92, 100000, "3-33-11", 9000);
            double cost = chucky.GetBenefitsCost();
            

            chucky.GiveBonus(300);
            chucky.DisplayStats();
            Console.WriteLine();

            SalesPerson fran = new SalesPerson("Fran", 43, 93, 3000, "3-22-22", 31);
            fran.GiveBonus(200);
            fran.DisplayStats();

            OuterClass.PublicInnerClass inner = new OuterClass.PublicInnerClass(); //OK

            //Employee e = new Employee(); ERROR, abstract class
            Console.ReadLine();
        }
    }

    public class OuterClass
    {
        int outMember = 10;

        private static int statMemb = 10;

        public class PublicInnerClass 
        { 
            public void DisplayOutMember()
            {
                //Console.WriteLine("Out member is {0}");
                //ERROR, implicitely static
                Console.WriteLine("Static Out member is {0}", statMemb);
            }
        }

        private class PrivateInnerClass { }
    }
}
