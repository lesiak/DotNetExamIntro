using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnsafeCode {
    class Program {
        static void Main(string[] args) {
            unsafe {
                int myInt = 10;
                SquareIntPointer(&myInt);
            }

            int myInt2 = 5;
            unsafe {             
                SquareIntPointer(&myInt2);
            }
            Console.WriteLine("myInt2: {0}", myInt2);
            PrintValueAndAddress();
            Console.WriteLine();

            int i = 10, j = 20;
            Console.WriteLine("Values before swap {0}, {1}", i ,j);
            SafeSwap(ref i, ref j);
            Console.WriteLine("Values after swap {0}, {1}", i, j);
            Console.WriteLine();

            Console.WriteLine("Values before unsafe swap {0}, {1}", i, j);
            unsafe {
                UnsafeSwap(&i, &j);
            }
            Console.WriteLine("Values after unsafe swap {0}, {1}", i, j);
            Console.WriteLine();

            UsePointerToPoint();

            UnsafeStackAlloc(); 
            Console.WriteLine();
            UseAndPinPointRef();

            Console.WriteLine();
            UseSizeofOperator();
            Console.ReadLine();
        }

        unsafe static void SquareIntPointer(int* myIntPointer) {
            *myIntPointer *= *myIntPointer;
        }

        unsafe static void PrintValueAndAddress() {
            int myInt;
            int* ptrToMyInt = &myInt;
            *ptrToMyInt = 123;

            Console.WriteLine("Value of myInt {0}", myInt);
            Console.WriteLine("Address of myInt {0:X}", (int)ptrToMyInt);
        }

        unsafe public static void UnsafeSwap(int* i, int* j) {
            int temp = *i;
            *i = *j;
            *j = temp;
        }

        public static void SafeSwap(ref int i, ref int j) {
            int temp = i;
            i = j;
            j = temp;
        }

        unsafe static void UsePointerToPoint() {
            Point point;
            Point* p = &point;
            p->x = 100;
            p->y = 200;
            Console.WriteLine(p->ToString());

            Point point2;
            Point* p2 = &point2;
            (*p2).x = 100;
            (*p2).y = 200;
            Console.WriteLine((*p2).ToString());
        }

        unsafe static void UnsafeStackAlloc() {
            char* p = stackalloc char[256];
            for (int k = 0; k < 256; k++) {
                p[k] = (char)k;
            }
        }

        unsafe static void UseAndPinPointRef() {
            PointRef pt = new PointRef();
            pt.x = 5;
            pt.y = 6;

            //ERROR int* p = &pt.x;         
            fixed (int* p = &pt.x) {
                Console.WriteLine("p: {0:X}", (int)p);
            }

            //fixed (PointRef* pPref = &pt) { ERROR
            //    Console.WriteLine("p: {0:X}", (int)p);
            //}
        }

        unsafe static void UseSizeofOperator() {
            Console.WriteLine("short: {0}" , sizeof(short));
            Console.WriteLine("int: {0}", sizeof(int));
            Console.WriteLine("long: {0}", sizeof(long));
            Console.WriteLine("Point: {0}", sizeof(Point));
           // Console.WriteLine("PointRef: {0}", sizeof(PointRef));
        }
    }

    unsafe struct Node {
        public int Value;
        public Node* Left;
        public Node* Right;
    }

    public struct Node2 {
        public int Value;
        public unsafe Node2* Left;
        public unsafe Node2* Right;
    }

    struct Point {
        public int x;
        public int y;

        public override string ToString() {
            return string.Format("[{0}, {1}]", x, y);
        }
    }

    class PointRef {
        public int x;
        public int y;

        public override string ToString() {
            return string.Format("[{0}, {1}]", x, y);
        }
    }
}
