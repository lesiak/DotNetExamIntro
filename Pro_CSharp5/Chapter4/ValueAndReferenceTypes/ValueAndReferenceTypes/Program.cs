using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueAndReferenceTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            ValueTypeAssignment();
            ReferenceTypeAssignment();
            ValueTypeContainingRefType();
            Console.ReadLine();
        }

        static void ValueTypeAssignment()
        {
            Console.WriteLine("=> value type assignment");
            Point p1 = new Point(10, 10);
            Point p2 = p1;

            p1.Display();
            p2.Display();

            p1.X = 100;
            Console.WriteLine("=> changed p1.X");
            p1.Display();
            p2.Display();
            Console.WriteLine();
        }


        static void ReferenceTypeAssignment()
        {
            Console.WriteLine("=> ref type assignment");
            PointRef p1 = new PointRef(10, 10);
            PointRef p2 = p1;

            p1.Display();
            p2.Display();

            p1.X = 100;
            Console.WriteLine("=> changed p1.X");
            p1.Display();
            p2.Display();
            Console.WriteLine();
        }

        static void ValueTypeContainingRefType()
        {
            Console.WriteLine("=> value type containing ref type");
            Console.WriteLine("Creating r1");
            Rectangle r1 = new Rectangle("Firct Rect", 10, 10, 50, 50);

            Console.WriteLine("Assingning r1 to r2");
            Rectangle r2 = r1;
            Console.WriteLine("Change r2");
            r2.rectInfo.infoString = "New Info";
            r2.Bottom = 4444;

            r1.Display();
            r2.Display();


            Console.WriteLine();
        }
    }
}


struct Point
{
    public int X;
    public int Y;

    public Point(int xPos, int yPos)
    {
        X = xPos;
        Y = yPos; // must be fully assigned
    }

    public void Increment()
    {
        X++;
        Y++;
    }

    public void Decrement()
    {
        X--;
        Y--;
    }

    public void Display()
    {
        Console.WriteLine("X = {0}, Y = {1}", X, Y);

    }

}


class PointRef
{
    public int X;
    public int Y;

    public PointRef(int xPos, int yPos)
    {
        X = xPos;
        Y = yPos; // must be fully assigned
    }

    public void Increment()
    {
        X++;
        Y++;
    }

    public void Decrement()
    {
        X--;
        Y--;
    }

    public void Display()
    {
        Console.WriteLine("X = {0}, Y = {1}", X, Y);

    }

}

class ShapeInfo
{
    public string infoString;

    public ShapeInfo(string info)
    {
        infoString = info;
    }
}

struct Rectangle
{
    //ref type in a structure
    public ShapeInfo rectInfo;

    public int Top, Left, Bottom, Right;

    public Rectangle(String info, int top, int left, int bottom, int right)
    {
        rectInfo = new ShapeInfo(info);
        Top = top;
        Left = left;
        Bottom = bottom;
        Right = right;
    }

    public void Display()
    {
        Console.WriteLine("String = {0}, Top = {1}, Left = {2}, Bottom = {3}, Right = {4}", rectInfo.infoString, Top, Bottom, Left, Right);
    }
}