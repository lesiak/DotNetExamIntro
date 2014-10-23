using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AutoLotDataReader {
    class Program {
        static void Main(string[] args) {
            SqlConnectionStringBuilder cnStrBuilder = new SqlConnectionStringBuilder();
            cnStrBuilder.InitialCatalog = "AutoLot";
            cnStrBuilder.DataSource = @"(local)\SQLExpress";
            cnStrBuilder.IntegratedSecurity = true;
            cnStrBuilder.ConnectTimeout = 30;

            using (SqlConnection cn = new SqlConnection()) {
                //cn.ConnectionString = @"Data Source=(local)\SQLExpress;Initial Catalog=AutoLot;Integrated Security=True";
                cn.ConnectionString = cnStrBuilder.ConnectionString;
                cn.Open();

                ShowConnectionStatus(cn);

                ReadInventoryFromDB(cn);
                ReadTwoTablesInOneCommand(cn);
        
            }
            Console.ReadLine();

        }

        static void ReadInventoryFromDB(SqlConnection cn) {
            string strSQL = "Select * From Inventory";
            SqlCommand myCommand = new SqlCommand(strSQL, cn);

            using (SqlDataReader myDataReader = myCommand.ExecuteReader()) {
                while (myDataReader.Read()) {
                    Console.WriteLine("Make: {0}, PetName: {1}, Color: {2}",
                        myDataReader["Make"],
                        myDataReader["PetName"].ToString(),
                        myDataReader["Color"]);
                }
            }
        }


        static void ReadTwoTablesInOneCommand(SqlConnection cn) {
            string strSQL = "Select * From Inventory;Select * from Customers";
            SqlCommand myCommand = new SqlCommand(strSQL, cn);

            using (SqlDataReader myDataReader = myCommand.ExecuteReader()) {
                do {
                    while (myDataReader.Read()) {
                        Console.WriteLine("** Record **");
                        for (int i = 0; i < myDataReader.FieldCount; i++) {
                            Console.WriteLine("{0} = {1}",
                                myDataReader.GetName(i),
                                myDataReader.GetValue(i));
                        }
                        Console.WriteLine();
                    }
                } while (myDataReader.NextResult());
            }
        }

        static void ShowConnectionStatus(SqlConnection cn) {
            Console.WriteLine("**** Connection Info ****");
            Console.WriteLine("Database location: {0}", cn.DataSource);
            Console.WriteLine("Database name: {0}", cn.Database);
            Console.WriteLine("Timeout: {0}", cn.ConnectionTimeout);
            Console.WriteLine("Connection state: {0}", cn.State);
            Console.WriteLine();
        }
    }
}
