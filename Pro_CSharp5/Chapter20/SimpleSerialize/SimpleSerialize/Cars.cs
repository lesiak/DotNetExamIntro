﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SimpleSerialize {
    [Serializable]
    public class Car {
        public Radio theRadio = new Radio();
        public bool isHatchBack;
    }

    [Serializable, XmlRoot(Namespace = "http://www.MyCompany.com")]
    public class JamesBondCar : Car {
        [XmlAttribute]
        public bool canFly;
        [XmlAttribute]
        public bool canSubmerge;

        public JamesBondCar() {

        }

        public JamesBondCar(bool canFly, bool canSubmerge) {
            this.canFly = canFly;
            this.canSubmerge = canSubmerge;

        }
    }
}
