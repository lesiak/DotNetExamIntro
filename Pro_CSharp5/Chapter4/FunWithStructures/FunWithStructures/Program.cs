using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithStructures {
    class Program {
        static void Main(string[] args) {
            Point myPoint;
            myPoint.X = 12;
            myPoint.Y = 2;   //all fields must be assigned, compiler error otherwise
            myPoint.Display();

            myPoint.Increment();
            myPoint.Display();

            Point p1 = new Point();     //default constructor, exists even if custom constructor is defined
            p1.Display();

            Point p2 = new Point(50, 60);
            p2.Display();

            Console.ReadLine();

        }
    }
}

struct Point {
    public int X;
    public int Y;

    public Point(int xPos, int yPos) {
        X = xPos;
        Y = yPos; // must be fully assigned
    }

    public void Increment() {
        X++;
        Y++;
    }

    public void Decrement() {
        X--;
        Y--;
    }

    public void Display() {
        Console.WriteLine("X = {0}, Y = {1}", X, Y);

    }

}
