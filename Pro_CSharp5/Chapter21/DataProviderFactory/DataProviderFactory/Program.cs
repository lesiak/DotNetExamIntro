using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace DataProviderFactory {
    class Program {
        static void Main(string[] args) {
            string dp = ConfigurationManager.AppSettings["provider"];
            //string cnStr = ConfigurationManager.AppSettings["cnStr"];
            string cnStr = ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"].ConnectionString;
            Console.WriteLine(dp);
            Console.WriteLine(cnStr);

            DbProviderFactory df = DbProviderFactories.GetFactory(dp);

            using (DbConnection cn = df.CreateConnection()) {
                Console.WriteLine("Your connection object is a: {0}", cn.GetType().Name);
                cn.ConnectionString = cnStr;
                cn.Open();

                if (cn is SqlConnection) {
                    SqlConnection sqlCn = (SqlConnection)cn;
                    Console.WriteLine(sqlCn.ServerVersion);
                }

                DbCommand cmd = df.CreateCommand();
                Console.WriteLine("Your command object is a: {0}", cmd.GetType().Name);
                cmd.Connection = cn;
                cmd.CommandText = "Select * From Inventory";

                using (DbDataReader dr = cmd.ExecuteReader()) {
                    Console.WriteLine("Your data reader object is a: {0}", dr.GetType().Name);

                    Console.WriteLine("***** Inventory ***");
                    while (dr.Read()) {
                        Console.WriteLine("Car #{0} is a {1}.", dr["CarID"], dr["Make"]);
                    }
                }
            }

            Console.ReadLine();

        }
    }
}
