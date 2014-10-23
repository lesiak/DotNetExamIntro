using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceHierarchy {
    class Program {
        static void Main(string[] args) {
            BitmapImage myBitmap = new BitmapImage();
            myBitmap.Draw();
            myBitmap.DrawInBoundingBox(10, 10, 100, 150);
            myBitmap.DrawUpsideDown();

            IAdvancedDraw iAdvDraw = myBitmap as IAdvancedDraw;
            if (iAdvDraw != null) {
                iAdvDraw.DrawUpsideDown();
            }

            Console.ReadLine();
        }
    }

    public interface IDrawable {
        void Draw();
    }

    public interface IAdvancedDraw : IDrawable {
        void DrawInBoundingBox(int top, int left, int bottom, int right);
        void DrawUpsideDown();
    }

    public class BitmapImage : IAdvancedDraw {

        public void DrawInBoundingBox(int top, int left, int bottom, int right) {
            Console.WriteLine("Drawing in a box...");
        }

        public void DrawUpsideDown() {
            Console.WriteLine("Drawing upside down...");
        }

        public void Draw() {
            Console.WriteLine("Drawing...");
        }
    }
}
