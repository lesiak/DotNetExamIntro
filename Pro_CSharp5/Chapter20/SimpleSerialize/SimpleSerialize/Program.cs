using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;

namespace SimpleSerialize {
    class Program {
        static void Main(string[] args) {
            JamesBondCar jbCar = new JamesBondCar();
            jbCar.canFly = true;
            jbCar.isHatchBack = true;
            jbCar.theRadio.hasSubWoofers = true;
            jbCar.theRadio.stationPresets = new double[] { 99.7, 101.44 };
            SaveAsBinaryFormat(jbCar, "CarData.dat");
            SaveAsSoapFormat(jbCar, "CarDataSoap.xml");
            SaveAsXMLFormat(jbCar, "CarData.xml");
            SaveListOfCars("CarCollection.xml");
            LoadFromBinaryFile("CarData.dat");
            Console.ReadLine();
        }

        static void SaveAsBinaryFormat(object objGraph, string fileName) {
            BinaryFormatter binFormat = new BinaryFormatter();

            using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None)) {
                binFormat.Serialize(fStream, objGraph);
            }
            Console.WriteLine("Saved object in binary format");
        }

        static void SaveAsSoapFormat(object objGraph, string fileName) {
            SoapFormatter binFormat = new SoapFormatter();

            using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None)) {
                binFormat.Serialize(fStream, objGraph);
            }
            Console.WriteLine("Saved object in SOAP format");
        }

        static void SaveAsXMLFormat(object objGraph, string fileName) {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(JamesBondCar));
            using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None)) {
                xmlFormat.Serialize(fStream, objGraph);
            }
            Console.WriteLine("Saved object in XML format");
        }

        static void SaveListOfCars(String fileName) {
            List<JamesBondCar> myCars = new List<JamesBondCar>();
            myCars.Add(new JamesBondCar(true, true));
            myCars.Add(new JamesBondCar(true, false));
            myCars.Add(new JamesBondCar(false, true));
            myCars.Add(new JamesBondCar(false, false));

            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<JamesBondCar>));
            using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None)) {
                xmlFormat.Serialize(fStream, myCars);
            }
            Console.WriteLine("Saved list of cars in XML format");
        }

        static void LoadFromBinaryFile(string fileName) {
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fStream = File.OpenRead(fileName)) {
                JamesBondCar carFromDisk = (JamesBondCar)binFormat.Deserialize(fStream);
                Console.WriteLine("Can fly: {0}", carFromDisk.canFly);
            }
        } 
    }
}
