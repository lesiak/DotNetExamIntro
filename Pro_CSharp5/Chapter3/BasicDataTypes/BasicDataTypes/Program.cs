using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace BasicDataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            LocalVarDeclarations();
            NewingDataTypes();
            ObjectFunctionality();
            DataTypeFunctionality();
            CharTypeFunctionality();
            ParseFromStrings();
            UseDatesAndTimes();
            UseBigInteger();
            Console.ReadLine();
        }

        static void LocalVarDeclarations() 
        {
            Console.WriteLine("Data declarations:");
            int myInt = 0;
            string myString;

            bool b1 = false, b2 = true, b3 = b1;
            System.Boolean b4 = false;

            Console.WriteLine(myInt);
            Console.WriteLine();
        }

        static void NewingDataTypes()
        {
            Console.WriteLine("=> using new to create variables:");
            bool b = new bool();
            int i = new int();
            double d = new double();
            DateTime dt = new DateTime();
            Console.WriteLine("{0}, {1}, {2}, {3}", b, i, d, dt);
            Console.WriteLine();

        }

        static void ObjectFunctionality() 
        {
            Console.WriteLine("=> Object Functionality:");
            Console.WriteLine("12.GetHashCode() = {0}", 12.GetHashCode());
            Console.WriteLine("12.Equals(23) = {0}", 12.Equals(23));
            Console.WriteLine("12.ToString() = {0}", 12.ToString());
            Console.WriteLine("12.GetType() = {0}", 12.GetType());
        }

        static void DataTypeFunctionality()
        {
            Console.WriteLine("=> DataType Functionality:");
            Console.WriteLine("Max of int: {0}", int.MaxValue);
            Console.WriteLine("Min of int: {0}", int.MinValue);
            Console.WriteLine("Max of double: {0}", double.MaxValue);
            Console.WriteLine("Min of double: {0}", double.MinValue);
            Console.WriteLine("double.Epsilon: {0}", double.Epsilon);
            Console.WriteLine("double.PositiveInfinity: {0}", double.PositiveInfinity);
            Console.WriteLine("double.NegativeInfinity: {0}", double.NegativeInfinity);


            Console.WriteLine("bool.FalseString: {0}", bool.FalseString);
            Console.WriteLine("bool.TrueString: {0}", bool.TrueString);
            
            
            Console.WriteLine();

            
        }

        static void CharTypeFunctionality()
        {
            Console.WriteLine("=> char Type Functionality:");
            Console.WriteLine("char.IsDigit('a'): {0}", char.IsDigit('a'));
            Console.WriteLine("char.IsLetter('a'): {0}", char.IsLetter('a'));            
            Console.WriteLine("char.IsWhiteSpace(\"aaa a\", 3): {0}", char.IsWhiteSpace("aaa a", 3));
            Console.WriteLine("char.IsWhiteSpace(\"aaa a\", 4): {0}", char.IsWhiteSpace("aaa a", 4));
            Console.WriteLine("char.IsPunctuation('?'): {0}", char.IsPunctuation('?'));            
            Console.WriteLine();
        }

        static void ParseFromStrings()
        {
            Console.WriteLine("=> Data Type Parsing:");
            bool b = bool.Parse("true");
            Console.WriteLine("Value of b: {0}", b);
            double d = double.Parse("99.884");
            Console.WriteLine("Value of d: {0}", d);
            int i = int.Parse("9");
            Console.WriteLine("Value of i: {0}", i);
            char c = char.Parse("w");
            Console.WriteLine("Value of c: {0}", c);            
            Console.WriteLine();
        }

        static void UseDatesAndTimes()
        {
            DateTime dt = new DateTime(2011, 10, 17);
            Console.WriteLine("The day of {0} is {1}", dt.Date, dt.DayOfWeek);

            dt = dt.AddMonths(2);
            Console.WriteLine("Daylight Savings {0}", dt.IsDaylightSavingTime());

            TimeSpan ts = new TimeSpan(4, 30, 0);
            Console.WriteLine(ts);

            Console.WriteLine(ts.Subtract(new TimeSpan(0, 15, 0)));


            Console.WriteLine();
        }


        static void UseBigInteger()
        {
            Console.WriteLine("=> BigInteger:");
            BigInteger bigNum = BigInteger.Parse("99999999999999999999999999999999999999999999999999999");
            Console.WriteLine("Value if bigNum is {0}", bigNum);
            Console.WriteLine("Is bigNum even? {0}", bigNum.IsEven);
            Console.WriteLine("Is bigNum poewf of two? {0}", bigNum.IsPowerOfTwo);
            BigInteger reallyBig = bigNum * bigNum;
            Console.WriteLine("Value if reallyBig is {0}", reallyBig);
            Console.WriteLine();
        }

    }
}
