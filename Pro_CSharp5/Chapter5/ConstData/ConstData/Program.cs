using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstData
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The value of Pi is {0}, can be accessed like a static", MyMathClass.PI);
            //MyMathClass.PI = 22; left hand must be a variable, property or indexer, is a const instead

            LocalConstStringVariablbe();

            MyMathClass mc = new MyMathClass();
            Console.WriteLine("ReadOnly val {0}",  mc.readOnlyVal);

            Console.WriteLine("ReadOnly is not implicitely static. Value of static readonly {0}", MyMathClass.STATIC_RO_PI);
            Console.ReadLine();
        }

        static void LocalConstStringVariablbe()
        {
            const string fixedStr = "Fixed string";
            Console.WriteLine(fixedStr);

            //fixedStr = "aaa";  ERROR
        }
    }

    class MyMathClass
    {
        ///public const double PI; ERROR: must be provided
        public const double PI = 3.14;  //implicitely static

        public static readonly double STATIC_RO_PI = 3.14; 

        //public const double SOME_VAL = someVal(); ERROR, nust be a compile-time constant

        static double someVal() {
            return 10.0;
        }

        public readonly double readOnlyVal;

        public MyMathClass() 
        {
            //PI = 12; eoorr;
            readOnlyVal = someVal();
            readOnlyVal = 1;  //OD, can be assigned multiple times in constructor
        }

        public void SetReadOnlyVal() {
            //readOnlyVal = 3; ERROR cannot be assigned to except constructore and variable initializer
        }
    }
}
