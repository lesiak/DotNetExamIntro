using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullableTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            //bool myBool = null; ERROR: non-nullable value type

            string myString = null; //OK, Strings are reference types

            LacalNullableVariables();

            DatabaseReader dr = new DatabaseReader();
            int? i = dr.GetIntFromDatabase();
            if (i.HasValue)
            {
                Console.WriteLine("Value of i is: {0}", i.Value);
            }
            else
            {
                Console.WriteLine("Value of i is undefined");
            }

            bool? b = dr.GetBoolFromDatabase();
            if (b == null) {
                Console.WriteLine("b in undefined");
            }
            else
            {
                Console.WriteLine("Value of b is: {0}", b.Value);
            }

            int myData = dr.GetIntFromDatabase() ?? 100;
            Console.WriteLine("Value of myData: {0}", myData);
            
            
            Console.ReadLine();


        }

        static void LacalNullableVariables()
        {
            int? nullableInt = 10;
            int? nullableInt1 = null;
            Nullable<int> nInt2 = 11;
            char? nullableChar = 'a';

            int?[] arrayOfNullableInts = new int?[10];

            //string? s = "aaa";      Error: System.Nullable must use non-nullable value type


        }
    }

    class DatabaseReader
    {
        public int? numericValue = null;
        public bool? boolValue = true;

        public int? GetIntFromDatabase()
        {
            return numericValue;
        }

        public bool? GetBoolFromDatabase()
        {
            return boolValue;
        }
    }
}
