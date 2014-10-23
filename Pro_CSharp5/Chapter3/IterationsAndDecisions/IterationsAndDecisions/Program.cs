using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterationsAndDecisions
{
    class Program
    {
        static void Main(string[] args)
        {
            ForLoopExample();
            ForEachLoopExample();
            LinqQueryOverInts();
            WhileLoopExample();
            DoWhileLoopExample();
            SwithcExample();
            SwitchOnStringExample();
            SwitchOnEnumExample();
            Console.ReadLine();
        }

        static void ForLoopExample()
        {
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Number is {0}", i);
            }
        }

        static void ForEachLoopExample()
        {
            string[] carTypes = { "Ford", "BMW", "Yugo", "Toyotoa" };
            foreach (string c in carTypes)
            {
                Console.WriteLine(c);
                break;
            }
        }

        static void LinqQueryOverInts()
        {
            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };

            var subset = from i in numbers where i < 10 select i;
            Console.WriteLine("Values in subset: ");
            foreach (int i in subset) //both int and var
            {
                Console.WriteLine("{0}", i);
            }


        }

        static void WhileLoopExample()
        {
            Console.WriteLine("=> WhileLoopExample: ");
            int i = 0;
            while (i < 2)
            {
                Console.WriteLine(i++);
            }
        }


        static void DoWhileLoopExample()
        {
            Console.WriteLine("=> DoWhileLoopExample: ");
            int i = 0;
            do
            {
                Console.WriteLine(i++);
            } while (i < 2); // note the semicolon

        }

        static void SwithcExample()
        {
            Console.WriteLine("=> Switch Example: ");
            int i = 7;
            switch (i)
            {
                case 1:
                    Console.WriteLine("Picked 1");
                    break;//cannot omit break/goto, no fall through forced :), even on last/default case
                default:    //default case can go anywhere
                    Console.WriteLine("Default");
                    break;
                case 2:
                    Console.WriteLine("Picked 2");
                    break;
            }
        }

        static void SwitchOnStringExample()
        {
            Console.WriteLine("=> SwitchOnStringExample Example: ");
            string s = "7";
            switch (s)
            {
                case "1":
                    Console.WriteLine("Picked 1");
                    break;
                case "2":
                    Console.WriteLine("Picked 2");
                    break;
                default:
                    Console.WriteLine("Default");
                    break;
            }
        }


        static void SwitchOnEnumExample()
        {
            Console.WriteLine("=> SwitchOnEnum Example: ");
            //DayOfWeek favDay = DayOfWeek.Saturday;
            DayOfWeek favDay = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), "Saturday");

            switch (favDay)
            {
                case DayOfWeek.Saturday:
                    Console.WriteLine("Saturday");
                    break;
                case DayOfWeek.Sunday:
                    Console.WriteLine("Sunday");
                    break;
                default:
                    Console.WriteLine("Other day");
                    break;
            }
        }
    }
}
