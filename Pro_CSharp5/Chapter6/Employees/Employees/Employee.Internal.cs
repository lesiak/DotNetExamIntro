using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    partial class Employee
    {
        protected string empName;
        private int empID;
        private float currPay;
        private int age;
        public string empSSN;
        protected BenefitPackage empBenefits = new BenefitPackage();

        public Employee()
        {

        }

        public Employee(string name, int age, int id, float pay, string empSSN)
        {
            Name = name;  //use a property, this may be recommended
            empID = id;
            currPay = pay;
            this.age = age;
            //SocialSecurityNumber = "empSSN";  //ERROR: property is read only
            this.empSSN = empSSN;
        }

    }
}
