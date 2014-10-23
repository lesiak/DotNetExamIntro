using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyShapes;
using My3DShapes;
using Chapter14.NewShapes;

using TheSquare = My3DShapes.Square;
using bfHome = System.Runtime.Serialization.Formatters.Binary;

namespace Customnamespaces {
    class Program {
        static void Main(string[] args) {
            MyShapes.Square s = new MyShapes.Square();
            TheSquare s2 = new TheSquare();

            bfHome.BinaryFormatter bf = new bfHome.BinaryFormatter();

            Rectangle r = new Rectangle();
        }
    }
}
