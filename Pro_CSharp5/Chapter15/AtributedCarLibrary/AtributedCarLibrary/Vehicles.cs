using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtributedCarLibrary {

    [Serializable]
    [VehicleDescription(Description="Harley")]
    public class Motorcycle {
    }

    [Serializable]
    [Obsolete("Dadadaa")]
    [VehicleDescription("Old horse")]
    public class HorseAndBuggy {
    }

    [VehicleDescription("Slow but feature rich")]
    public class WinneBaggo {
        public ulong notCompliant;
    }
}
