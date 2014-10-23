using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleUtilityClass
{
    class Program
    {
        static void Main(string[] args)
        {
            TimeUtilClass.PrintDate();
            TimeUtilClass.PrintTime();

            //TimeUtilClass u;                       ERROR: cannot declare a variable of static class
            //TimeUtilClass u = new TimeUtilClass(); ERROR: cannot declare a variable of static class

            Console.ReadLine();
        }
    }
}

