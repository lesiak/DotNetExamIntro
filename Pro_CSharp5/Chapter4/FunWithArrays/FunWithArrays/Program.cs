using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleArrays();
            ArrayInitialization();
            DeclareImplicitArrays();
            ArrayOfObjects();
            RectMultidimensionalArray();
            JaggedMultidimensionalArray();
            PassAndReceiveArrays();
            SystemArrayFunctionality();
            Console.ReadLine();
        }

        static void SimpleArrays()
        {
            Console.WriteLine("=> Simple Array Creation");
            int[] myInts = new int[3];
            myInts[0] = 100;
            myInts[1] = 200;
            myInts[2] = 300;

            foreach (int i in myInts)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            string[] books = new string[100];
            Console.WriteLine();
        }

        static void ArrayInitialization()
        {
            Console.WriteLine("=> Array Initialization");
            
            // without new keyword
            string[] nums = { "one", "two", "three" };
            Console.WriteLine("Nums has {0} elements", nums.Length);

            // with new keyword
            string[] nums1 = new string[] { "one", "two", "three" };
            Console.WriteLine("Nums1 has {0} elements", nums1.Length);

            string[] nums2 = new string[3] { "one", "two", "three" }; //Works fine, but size must match
            Console.WriteLine("Nums2 has {0} elements", nums2.Length);
            Console.WriteLine();
        }

        static void DeclareImplicitArrays()
        {
            Console.WriteLine("=> DeclareImplicitArrays");

            var a = new[] { 1, 2, 100, 1000 };
            Console.WriteLine("a is a: {0}", a);


            //var a1 = { 1, 2, 100, 1000 }; wont compile


            var b = new[] { 1.4, 2.4, 100, 1000 };
            Console.WriteLine("b is a: {0}", b);

            var c = new[] { "aaa", "bbb", null, "eee" };
            Console.WriteLine("c without toString: {0}", c);
            Console.WriteLine("c is a: {0}", c.ToString());


            //var mixed = new[] { 1.4, "2.4"}; won't compile, no best type found
            Console.WriteLine();

        }

        static void ArrayOfObjects()
        {
            Console.WriteLine("=> Array Of Objects");
            object[] myObjects = new object[4];
            myObjects[0] = 10;
            myObjects[1] = false;
            myObjects[2] = new DateTime(1969, 3, 24);
            myObjects[3] = "asasa";
            foreach (object obj in myObjects)
            {
                Console.WriteLine("Type: {0}, Value: {1}", myObjects, obj.GetType(), obj);
            }
            Console.WriteLine();

        }

        static void RectMultidimensionalArray()
        {
            Console.WriteLine("=> Rectangular Multidimensional Array");
            int[,] myMatrix = new int[6, 6];
            for (int i = 0; i < 6; ++i)
            {
                for (int j = 0; j < 6; ++j)
                {
                    myMatrix[i, j] = i * j;
                }
            }


            for (int i = 0; i < 6; ++i)
            {
                for (int j = 0; j < 6; ++j)
                {
                    Console.Write(myMatrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }


        static void JaggedMultidimensionalArray()
        {
            Console.WriteLine("=> Jagged Multidimensional Array");
            int[][] myJagArray = new int[5][];
            for (int i = 0; i < myJagArray.Length; i++)
            {
                myJagArray[i] = new int[i + 7];
            }

            for (int i = 0; i < myJagArray.Length; i++)
            {
                for (int j = 0; j < myJagArray[i].Length; j++) {
                    Console.Write(myJagArray[i][j] + " ");
                }
                Console.WriteLine();                
            }
            Console.WriteLine();
        }

        

        static void PassAndReceiveArrays() {
            Console.WriteLine("=> Arrays as Params and return values");
            int[] ages = { 20, 23, 34 };
            PrintArray(ages);

            string[] stings = GetStringArray();
            foreach (var str in stings)
            {
                Console.WriteLine(str);
                
            }
            Console.WriteLine();
        }

        static void PrintArray(int[] myInts)
        {
            Console.WriteLine(string.Join(",", myInts));
        }

        static string[] GetStringArray()
        {
            //return {"one", "two"};
            //Only assignment, call, increment, decrement, await, and new object expressions can be used as a statement	

            //return new string[]{"one", "two"}; OK

            string[] ret = { "one", "two" };
            return ret;
        }

        static void SystemArrayFunctionality() {
            Console.WriteLine("=> System.Array Functionality");
            string[] gothicBands = { "band1", "band2", "band3" };
            Console.WriteLine("array:");
            for(int i = 0; i < gothicBands.Length; ++i)
            {
                Console.Write(gothicBands[i] + ", ");
            }
            Console.WriteLine();

            Array.Reverse(gothicBands);
            Console.WriteLine("reversed array:");
            for (int i = 0; i < gothicBands.Length; ++i)
            {
                Console.Write(gothicBands[i] + ", ");
            }
            Console.WriteLine();

            Console.WriteLine("clear all but one:");
            Array.Clear(gothicBands, 0, 2);
            for (int i = 0; i < gothicBands.Length; ++i)
            {
                Console.Write(gothicBands[i] + ", ");
            }
            Console.WriteLine();

            

        }

    }
}
