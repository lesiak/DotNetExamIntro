using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterface {
    interface IPointy {
        //public byte GetNumberOfPoints(); ERROR
       // public int aField; ERROR
       // byte GetNumberOfPoints1() { return 4; } ERROR
       
        
        // byte GetNumberOfPoints();  OK
        byte Points { get; }


    }
}
