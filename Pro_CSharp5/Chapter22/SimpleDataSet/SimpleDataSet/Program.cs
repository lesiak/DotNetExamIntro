using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SimpleDataSet {
    class Program {
        static void Main(string[] args) {
            DataSet carsInventoryDS = new DataSet("Car Inventory");

            carsInventoryDS.ExtendedProperties["TimeStamp"] = DateTime.Now;
            carsInventoryDS.ExtendedProperties["DataSetID"] = Guid.NewGuid();
            carsInventoryDS.ExtendedProperties["Company"] = "MyCompany";

            ManipulateDataRowState();
            BuildDataSet(carsInventoryDS);
            PrintDataSet(carsInventoryDS);
            SaveAndLoadAsXml(carsInventoryDS);
            SaveAndLoadAsBinary(carsInventoryDS);
            Console.ReadLine();

        }

        static void BuildDataSet(DataSet ds) {
            DataColumn carIDColumn = new DataColumn("CarID", typeof(int));
            carIDColumn.Caption = "Car ID";
            carIDColumn.ReadOnly = true;
            carIDColumn.AllowDBNull = false;
            carIDColumn.Unique = true;
            carIDColumn.AutoIncrement = true;
            carIDColumn.AutoIncrementSeed = 0;
            carIDColumn.AutoIncrementStep = 1;

            DataColumn carMakeColumn = new DataColumn("Make", typeof(string));
            DataColumn carColorColumn = new DataColumn("Color", typeof(string));
            DataColumn carPetNameColumn = new DataColumn("PetName", typeof(string));
            carPetNameColumn.Caption = "Pet Name";

            DataTable inventoryTable = new DataTable("Inventory");
            inventoryTable.Columns.AddRange(new DataColumn[] { carIDColumn, carMakeColumn, carColorColumn, carPetNameColumn });
            inventoryTable.PrimaryKey = new DataColumn[] { carIDColumn };

            DataRow carRow = inventoryTable.NewRow();
            carRow["Make"] = "BMW";
            carRow["Color"] = "Black";
            carRow["PetName"] = "Hamlet";
            inventoryTable.Rows.Add(carRow);

            carRow = inventoryTable.NewRow();
            carRow["Make"] = "Saab";
            carRow["Color"] = "Red";
            carRow["PetName"] = "Sea Breeze";
            inventoryTable.Rows.Add(carRow);

            ds.Tables.Add(inventoryTable);
        }

        static void ManipulateDataRowState() {
            DataTable temp = new DataTable("Temp");
            temp.Columns.Add(new DataColumn("TempColumn", typeof(int)));

            DataRow row = temp.NewRow();
            Console.WriteLine("After calling NewRow(): {0}", row.RowState);

            temp.Rows.Add(row);
            Console.WriteLine("After calling Add(): {0}", row.RowState);

            row["TempColumn"] = 10;
            Console.WriteLine("After first assigment: {0}", row.RowState);

            temp.AcceptChanges();
            Console.WriteLine("After calling AcceptChanges(): {0}", row.RowState);

            row["TempColumn"] = 11;
            Console.WriteLine("After first assigment: {0}", row.RowState);

            temp.Rows[0].Delete();
            Console.WriteLine("After calling Delete(): {0}", row.RowState);

            Console.WriteLine();

        }


        static void PrintDataSet(DataSet ds) {
            Console.WriteLine("DataSet is named: {0}", ds.DataSetName);
            foreach (System.Collections.DictionaryEntry de in ds.ExtendedProperties) {
                Console.WriteLine("Key = {0}, Velue = {1}", de.Key, de.Value);
            }
            Console.WriteLine();
            foreach (DataTable dt in ds.Tables) {
                Console.WriteLine("=> {0} Table:", dt.TableName);

                for (int curCol = 0; curCol < dt.Columns.Count; curCol++) {
                    Console.Write(dt.Columns[curCol].ColumnName + "\t");
                }
                Console.WriteLine("\n----------------------------------------------");
                 
                /*for (int curRow = 0; curRow < dt.Rows.Count; curRow++) {
                    for (int curCol = 0; curCol < dt.Columns.Count; curCol++) {
                        Console.Write(dt.Rows[curRow][curCol].ToString() + "\t");
                    }
                    Console.WriteLine();
                } */
                PrintTable(dt);

            }

        }

        static void PrintTable(DataTable dt) {
            DataTableReader dtReader = dt.CreateDataReader();
            while (dtReader.Read()) {
                for (int i = 0; i < dtReader.FieldCount; i++) {
                    Console.Write("{0}\t", dtReader.GetValue(i).ToString().Trim());
                }
                Console.WriteLine();
            }
            dtReader.Close();
        }

        static void SaveAndLoadAsXml(DataSet carsInventoryDS) {
            carsInventoryDS.WriteXml("carsDataSet.xml");
            carsInventoryDS.WriteXmlSchema("carsDataSet.xsd");

            carsInventoryDS.Clear();
            carsInventoryDS.ReadXml("carsDataSet.xml");
        }

        static void SaveAndLoadAsBinary(DataSet carsInventoryDS) {
            carsInventoryDS.RemotingFormat = SerializationFormat.Binary;

            FileStream fs = new FileStream("BinaryCars.bin", FileMode.Create);
            BinaryFormatter bFormat = new BinaryFormatter();
            bFormat.Serialize(fs, carsInventoryDS);
            fs.Close();
            
            
            carsInventoryDS.Clear();

            fs = new FileStream("BinaryCars.bin", FileMode.Open);
            DataSet data = (DataSet)bFormat.Deserialize(fs);

        }
    }
}
