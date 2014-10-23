using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplyingAttributes {
    [Serializable]
    public class Motorcycle {
        [NonSerialized]
        float weightOfCurrentPassengers;

        bool hasRadioSystem;
        bool hasHeadSet;
        bool hasSissyBar;

    }

    [Serializable]
    [Obsolete("use sth different")]
    public class HorseAndBuggy { }
}
