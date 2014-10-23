using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterface {
    class Program {
        static void Main(string[] args) {
            // IPointy p = new IPointy(); ERROR
            Hexagon hex = new Hexagon();
            Console.WriteLine("Points: {0}", hex.Points);


            Circle c = new Circle("Lisa");
            try {
                IPointy cp = (IPointy)c;
                Console.WriteLine("Points: {0}", cp.Points);
            } catch (InvalidCastException ex) {
                Console.WriteLine(ex);
            }

            Hexagon hex2 = new Hexagon("Peter");
            IPointy itHex2 = hex2 as IPointy;
            if (itHex2 != null) {
                Console.WriteLine("Points: {0}", itHex2.Points);
            } else {
                Console.WriteLine("Oops, not a IPointy");
            }
            Console.WriteLine();

            Shape[] shapes = { new Hexagon(), new Circle(), new Triangle("Joe"), new Circle("Jojo") };
            foreach (Shape s in shapes) {
                //s.Draw();
                if (s is IDraw3D) {
                    DrawIn3D((IDraw3D)s);
                } else {
                    s.Draw();
                }
                if (s is IPointy) {
                    Console.WriteLine("Points: {0}", ((IPointy)s).Points);
                } else {
                    Console.WriteLine("{0} is not a IPointy", s.PetName);
                }
            }
            Console.WriteLine();

            IPointy firstPointyItem = FindFirstPointyShape(shapes);
            Console.WriteLine("Points: {0}", firstPointyItem.Points);

            Console.ReadLine();
        }

        static void DrawIn3D(IDraw3D itf3d) {
            Console.WriteLine("-> Drawing IDraw3D compatible type");
            itf3d.Draw3D();
        }

        static IPointy FindFirstPointyShape(Shape[] shapes) {
            foreach (Shape s in shapes) {
                if (s is IPointy) {
                    return s as IPointy;
                }                
            }
            return null;
        }
    }
}
