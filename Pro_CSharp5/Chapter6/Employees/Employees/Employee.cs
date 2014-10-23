using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    abstract partial class Employee
    {
        
        public virtual void GiveBonus(float amount)
        {
            currPay += amount;
        }

        public void DisplayStats()
        {
            Console.WriteLine("Name: {0}", empName);
            Console.WriteLine("ID: {0}", empID);
            Console.WriteLine("Pay: {0}", currPay);
            Console.WriteLine("Age: {0}", Age); //use property
        }

        public string GetName()
        {
            return empName;
        }

        public void SetName(string name)
        {
            if (name.Length > 15)
            {
                Console.WriteLine("Error! Must be less than 16 characters");
            }
            else
            {
                empName = name;
            }
        }


        public string Name
        {
            get
            { return empName; }

            set
            {
                if (value.Length > 15)
                {
                    Console.WriteLine("Error! Must be less than 16 characters");
                }
                else
                {
                    empName = value;
                }
            }
        }

        public float ID   // Note another type, it forces a cast in setter.
        {
            get { return empID; }
            set { empID = (int)value; }
        }

        public float Pay
        {
            get { return currPay;  }
            set { currPay = value; }
        }


        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string SocialSecurityNumber
        {
            get { return empSSN; }
            
        }

        public double GetBenefitsCost()
        {
            return empBenefits.ComputePayDeduction();

        }
        
        public BenefitPackage Benefits
        {
            get { return empBenefits; }
            set { empBenefits = value; }
        }

    }
}
