using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicInheritance
{
    sealed class MiniVan : Car
    {
        public void TestNoPrivateAccess()
        {
            Speed = 10;

            //currSpeed = 10; //ERROR: currSpeed is inaccessible due to its protection level
        }
    }

    //class DeluxeMiniVan : MiniVan { } ERROR: cannot derive from sealed type

    // structures are implicitely sealed!!

    //struct MyStruct : Car {} can only implement interfaces

    struct MyStruct2 : ICloneable {
        public Object Clone() {return null;}
    }
}
