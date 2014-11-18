using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConstructingXmlDocs
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateFullXDocument();
            CreateRootAndChildren();
            MakeXElementFromArray();
            ParseAndLoadExistingXml();
            Console.WriteLine("...");
            Console.ReadLine();
        }

        static void CreateFullXDocument() {
            XDocument inventoryDoc = 
                new XDocument(
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XComment("Current Inventory of Cars"),
                    new XProcessingInstruction("xml-stylesheet", "href='MyStyles.css' title='Compact' type='text/css'"),
                    new XElement("Inventory", 
                        new XElement("Car", new XAttribute("ID", "1"),
                            new XElement("Color", "Green"),
                            new XElement("Make", "BMW"),
                            new XElement("PetName", "Jimbo")                                                
                        ),
                        new XElement("Car", new XAttribute("ID", "2"),
                            new XElement("Color", "Pink"),
                            new XElement("Make", "Yugo"),
                            new XElement("PetName", "Melvin")
                        )
                    )
                );
            inventoryDoc.Save("SimpleInventory.xml");
        }

        static void CreateRootAndChildren()
        {
            XElement inventoryDoc =                
                new XElement("Inventory",
                    new XElement("Car", new XAttribute("ID", "1"),
                        new XElement("Color", "Green"),
                        new XElement("Make", "BMW"),
                        new XElement("PetName", "Jimbo")
                    ),
                    new XElement("Car", new XAttribute("ID", "2"),
                        new XElement("Color", "Pink"),
                        new XElement("Make", "Yugo"),
                        new XElement("PetName", "Melvin")
                    )
                );
                
            inventoryDoc.Save("SimpleInventory2.xml");
        }

        static void MakeXElementFromArray() {
            var people = new[] {
                new { FirstName = "Mandy", Age = 32 },
                new { FirstName = "Andrew", Age = 40 },
                new { FirstName = "Dave", Age = 41 },
                new { FirstName = "Sara", Age = 31 }
            };
            
            XElement peopleDoc = new XElement("People",
                 from p in people
                 select
                     new XElement("Person",
                     new XAttribute("Age", p.Age),
                     new XElement("FirstName", p.FirstName)
                     )
            );
            Console.WriteLine(peopleDoc);
            Console.WriteLine();
        }

        static void ParseAndLoadExistingXml() {
            string myElement =
                @"<Car ID='3'>
                    <Color>Yellow</Color>
                    <Make>Yugo</Make>
                </Car>";
            XElement newElement = XElement.Parse(myElement);
            Console.WriteLine(newElement);
            Console.WriteLine();

            XDocument myDoc = XDocument.Load("SimpleInventory.xml");
            Console.WriteLine(myDoc);
            Console.WriteLine();
        }
    }
}
