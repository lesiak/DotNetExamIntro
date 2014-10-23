using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace CarLibrary {
    public class SportsCar : Car {
        public SportsCar() { }

        public SportsCar(string name, int maxSp, int currSp) : base(name, maxSp, currSp) { }

        public override void TurboBoost() {
            MessageBox.Show("Sports car TurboBoost");
        }
    }


    public class MiniVan : Car {
        public MiniVan() { }

        public MiniVan(string name, int maxSp, int currSp) : base(name, maxSp, currSp) { }

        public override void TurboBoost() {
            engState = EngineState.EngineDead;
            MessageBox.Show("MiniVan TurboBoost");
        }
    }
}
