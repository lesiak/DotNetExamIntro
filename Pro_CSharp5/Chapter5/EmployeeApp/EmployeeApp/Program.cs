using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee("Marvin", 456, 30000, 40);
            emp.GiveBonus(1000);
            emp.DisplayStats();
            Console.WriteLine();

            emp.SetName("Marv");
            Console.WriteLine("Employee is named {0}", emp.GetName());

            // Use a property
            emp.Name = "Marv2";
            Console.WriteLine("Employee is named {0}", emp.Name);

            Console.WriteLine();
            emp.Age++;  //can use operators on properties
            emp.DisplayStats();

            Console.WriteLine();

            Console.WriteLine("Read only property {0}", emp.SocialSecurityNumber);

            Console.ReadLine();
        }
    }
}
