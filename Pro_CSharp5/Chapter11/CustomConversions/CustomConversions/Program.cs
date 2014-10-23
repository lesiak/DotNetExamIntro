using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomConversions {
    class Program {
        static void Main(string[] args) {
            Rectangle r = new Rectangle(15, 4);
            Console.WriteLine(r);
            r.Draw();

            Console.WriteLine();

            Square s = (Square)r;
            Console.WriteLine(s);
            s.Draw();

            Console.WriteLine();
            Rectangle r2 = new Rectangle(4, 2);
            DrawSquare((Square)r2);


            //conversion to and from int
            Square sq2 = (Square)90;
            int side = (int)sq2;

            //implicit conversion;

            Rectangle rImpl = sq2;
            Console.WriteLine(rImpl);

            Console.ReadLine();
        }

        static void DrawSquare(Square sq) {
            Console.WriteLine(sq);
            sq.Draw();
        }
    }

    struct Rectangle {
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle(int w, int h)
            : this() { //chaining necessary for structures with auto backing fields
            Width = w;
            Height = h;
        }

        public void Draw() {
            for (int i = 0; i < Height; i++) {
                for (int j = 0; j < Width; j++) {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        public override string ToString() {
            return string.Format("[Width = {0}; Height = {1}]", Width, Height);
        }

        public static implicit operator Rectangle(Square sq) {
            Rectangle r = new Rectangle(sq.Length, sq.Length);
            return r;
        }
    }

    struct Square {
        public int Length { get; set; }

        public Square(int l)
            : this() {
            Length = l;
        }

        public void Draw() {
            for (int i = 0; i < Length; i++) {
                for (int j = 0; j < Length; j++) {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        public override string ToString() {
            return string.Format("[Length = {0}]", Length);
        }

        public static explicit operator Square(Rectangle r) {
            Square s = new Square();
            s.Length = r.Height;
            return s;
        }

        public static explicit operator Square(int sideLength) {
            Square s = new Square();
            s.Length = sideLength;
            return s;
        }



        public static explicit operator int(Square sq) {
            return sq.Length;
        }
    }
}
