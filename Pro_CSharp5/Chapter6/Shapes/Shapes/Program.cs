using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            Hexagon hex = new Hexagon("Beth");
            hex.Draw();

            Circle cir = new Circle("Cindy");
            cir.Draw();
            Console.WriteLine();

            Shape[] myShapes = { new Hexagon(), new Circle(), new Hexagon("Mick"), new Circle("Beth"), new Hexagon("Linda") };
            foreach (Shape s in myShapes)
            {
                s.Draw();
            }

            Console.WriteLine();
            ThreDCircle c = new ThreDCircle();
            c.Draw();                                 //calls method form 3d circle

            Circle c1 = new ThreDCircle();
            c1.Draw();                                //calls method form  circle
            Console.ReadLine();
        }
    }

    

   
    
}
