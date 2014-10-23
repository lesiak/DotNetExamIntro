using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace FillDataSetUsingSqlDataAdapter {
    class Program {
        static void Main(string[] args) {
            string cnStr = @"Data Source=(local)\SQLExpress;Initial Catalog=AutoLot;Integrated Security=True";

            DataSet ds = new DataSet("AutoLot");

            SqlDataAdapter dAdapt = new SqlDataAdapter("Select * From Inventory", cnStr);

            DataTableMapping custMap = dAdapt.TableMappings.Add("Inventory", "Current Inventory");
            custMap.ColumnMappings.Add("CarID", "Car ID");
            custMap.ColumnMappings.Add("PetName", "Pet Name");

            dAdapt.Fill(ds, "Inventory");

            PrintDataSet(ds);
            Console.ReadLine();
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

                for (int curRow = 0; curRow < dt.Rows.Count; curRow++) {
                    for (int curCol = 0; curCol < dt.Columns.Count; curCol++) {
                        Console.Write(dt.Rows[curRow][curCol].ToString() + "\t");
                    }
                    Console.WriteLine();
                } 
                

            }

        }
    }
}
