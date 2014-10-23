using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneablePoint {
    class Program {
        static void Main(string[] args) {
            Point p1 = new Point(50, 50);
            Point p2 = p1;
            p2.X = 0;
            Console.WriteLine(p1);
            Console.WriteLine(p2);


            Point p3 = new Point(100, 100);
            Point p4 = (Point)p3.Clone();

            Console.WriteLine("Before modification");
            Console.WriteLine(p3);
            Console.WriteLine(p4);


            p4.X = 0;
            p4.desc.PetName = "My new point";

            Console.WriteLine("After modification");
            Console.WriteLine(p3);
            Console.WriteLine(p4);

            Console.ReadLine();
        }
    }

    public class Point : ICloneable {
        public int X { get; set; }
        public int Y { get; set; }
        public PointDescription desc = new PointDescription();

        public Point(int xPos, int yPos, string petName) {
            X = xPos;
            Y = yPos;
            desc.PetName = petName;
        }

        public Point(int xPos, int yPos) {
            X = xPos;
            Y = yPos;            
        }

        public Point() {
        }

        public override string ToString() {
            return string.Format("[X = {0}, Y = {1}, Name = {2},\nID = {3}]", X, Y, desc.PetName, desc.PointID);
        }

        public object Clone() {
            //return new Point(this.X, this.Y);
            Point newPoint = (Point) this.MemberwiseClone();
            PointDescription newDesc = new PointDescription();
            newDesc.PetName = this.desc.PetName;
            newPoint.desc = newDesc;
            return newPoint;

        }
    }

    public class PointDescription {
        public string PetName { get; set; }
        public Guid PointID { get; set; }

        public PointDescription() {
            PetName = "No-name";
            PointID = Guid.NewGuid();
        }
    }
}
