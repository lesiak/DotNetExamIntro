using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectInitializers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=> set properties manually");
            Point p = new Point();
            p.X = 10;
            p.Y = 11;
            p.DisplayStats();

            Console.WriteLine("=> set properties via constructor");
            Point p1 = new Point(20, 21);
            p1.DisplayStats();

            Console.WriteLine("=> set properties via  object init syntax");
            Point p3 = new Point { X = 30, Y = 31, Z = 32 }; // can use any property
            p3.DisplayStats();

            Console.WriteLine("=> new Point() { init list } syntax");
            Point p4 = new Point() { X = 30, Y = 31, Z = 32 }; // can use any property
            p4.DisplayStats();


            Console.WriteLine("=> new Point(args) { init list } syntax");
            Point p5 = new Point(30, 31) { Y = 33, Z = 32 }; // can use any property
            p5.DisplayStats();
            Console.WriteLine();

            Console.WriteLine("=> Initialize Inner Types");
            Rectangle rect = new Rectangle
            {
                TopLeft = new Point { X = 10, Y = 10 },
                BottomRight = new Point { X = 20, Y =22 }
            };
            rect.DisplayStats();
            Console.ReadLine();

        }

        class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Z { get; set; }

            public Point(int xVal, int yVal)
            {
                Console.WriteLine("ctor");
                X = xVal;
                Y = yVal;
            }

            public Point()
            {
                Console.WriteLine("default ctor");
            }

            public void DisplayStats()
            {
                Console.WriteLine("[{0}, {1}, {2}]", X, Y, Z);
            }
        }

        class Rectangle
        {
            private Point topLeft = new Point();
            private Point bottomRight = new Point();

            public Point TopLeft
            {
                get { return topLeft; }
                set { topLeft = value; }
            }

            public Point BottomRight
            {
                get { return bottomRight; }
                set { bottomRight = value; }
            }

            public void DisplayStats()
            {
                Console.WriteLine("TopLeft {0}, {1}, BottomRight {2}, {3}", topLeft.X, topLeft.Y, bottomRight.X, bottomRight.Y);
            }
        }
    }
}
