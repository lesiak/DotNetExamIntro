using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    partial class Employee
    {
        private string empName;
        private int empID;
        private float currPay;
        private int age;
        public string empSSN;

        public Employee()
        {

        }

        public Employee(string name, int id, float pay, int age)
        {
            Name = name;  //use a property, this may be recommended
            empID = id;
            currPay = pay;
            this.age = age;
            //SocialSecurityNumber = "empSSN";  //ERROR: property is read only
            empSSN = "empSSN";
        }

    }
}
