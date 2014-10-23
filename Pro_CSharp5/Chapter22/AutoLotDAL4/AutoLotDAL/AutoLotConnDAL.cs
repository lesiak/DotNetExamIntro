using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AutoLotConnectedLayer {
    public class InventoryDAL {
        private SqlConnection sqlCn = null;

        public void OpenConnection(string connectionString) {
            sqlCn = new SqlConnection(connectionString);
            sqlCn.Open();
        }

        public void CloseConnection() {
            if (sqlCn != null) {
                sqlCn.Close();
            }
        }

        public void InsertAuto(int id, string color, string make, string petName) {
            /*string sql = string.Format("Insert into Inventory (CarID, Make, Color, PetName)"
                + " values ('{0}', '{1}', '{2}', '{3}')",
                id, make, color, petName);

            using (SqlCommand cmd = new SqlCommand(sql, this.sqlCn)) {
                cmd.ExecuteNonQuery();
            }*/

            string sql = "Insert into Inventory (CarID, Make, Color, PetName)"
                + " values (@CarID, @Make, @Color, @PetName)";

            using (SqlCommand cmd = new SqlCommand(sql, this.sqlCn)) {
                SqlParameter pCarID = new SqlParameter();
                pCarID.ParameterName = "@CarID";
                pCarID.Value = id;
                pCarID.SqlDbType = SqlDbType.Int;
                cmd.Parameters.Add(pCarID);

                SqlParameter pMake = new SqlParameter();
                pMake.ParameterName = "@Make";
                pMake.Value = make;
                pMake.SqlDbType = SqlDbType.Char;
                cmd.Parameters.Add(pMake);

                SqlParameter pColor = new SqlParameter();
                pColor.ParameterName = "@Color";
                pColor.Value = color;
                pColor.SqlDbType = SqlDbType.Char;
                cmd.Parameters.Add(pColor);

                SqlParameter pPetName = new SqlParameter();
                pPetName.ParameterName = "@PetName";
                pPetName.Value = petName;
                pPetName.SqlDbType = SqlDbType.Char;
                cmd.Parameters.Add(pPetName);
                cmd.ExecuteNonQuery();
            }
        }

        public void InsertAuto(NewCar car) {
            InsertAuto(car.CarID, car.Color, car.Make, car.PetName);
        }

        public void DeleteCar(int id) {
            string sql = string.Format("Delete from Inventory where CarID = '{0}'", id);

            using (SqlCommand cmd = new SqlCommand(sql, this.sqlCn)) {
                try {
                    cmd.ExecuteNonQuery();
                } catch (SqlException ex) {
                    Exception error = new Exception("Sorry!, That car is on order!", ex);
                    throw error;
                }
            }
        }


        public void UpdateCarPetName(int id, string newPetName) {
            string sql = string.Format("Update Inventory set Petname = '{0}' where CarID = '{1}'", newPetName, id);

            using (SqlCommand cmd = new SqlCommand(sql, this.sqlCn)) {
                cmd.ExecuteNonQuery();
            }
        }

        public List<NewCar> GetAllInventoryAsList() {
            List<NewCar> ret = new List<NewCar>();
            string sql = "Select * From Inventory";
            using (SqlCommand cmd = new SqlCommand(sql, this.sqlCn)) {
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    ret.Add(new NewCar
                    {
                        CarID = (int)dr["CarID"],
                        Color = (string)dr["Color"],
                        Make = (string)dr["Make"],
                        PetName = (string)dr["PetName"]
                    });
                }
                dr.Close();
            }
            return ret;

        }
        public DataTable GetAllInventoryAsDataTable() {
            DataTable inv = new DataTable();
            string sql = "Select * From Inventory";
            using (SqlCommand cmd = new SqlCommand(sql, this.sqlCn)) {
                SqlDataReader dr = cmd.ExecuteReader();
                inv.Load(dr);                
                dr.Close();
            }
            return inv;

        }

        public string LookupPetName(int carID) {
            string carPetName = string.Empty;
            using (SqlCommand cmd = new SqlCommand("GetPetName", this.sqlCn)) {
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter pCarID = new SqlParameter();
                pCarID.ParameterName = "@carID";
                pCarID.Value = carID;
                pCarID.SqlDbType = SqlDbType.Int;
                pCarID.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(pCarID);

                SqlParameter pPetName = new SqlParameter();
                pPetName.ParameterName = "@petName";                
                pPetName.SqlDbType = SqlDbType.Char;
                pPetName.Size = 10;
                pPetName.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pPetName);

                cmd.ExecuteNonQuery();

                carPetName = (string)cmd.Parameters["@petName"].Value;

            }
            return carPetName;
        }

        public void ProcessCreditRisk(bool throwEx, int custID) {
            string fName = string.Empty;
            string lName = string.Empty;

            string cmdSelStr = string.Format("select * from Customers where CustID = {0}", custID);
            SqlCommand cmdSelect = new SqlCommand(cmdSelStr, sqlCn);
            using (SqlDataReader dr = cmdSelect.ExecuteReader()) {
                if (dr.HasRows) {
                    dr.Read();
                    fName = (string)dr["FirstName"];
                    lName = (string)dr["LastName"];
                } else {
                    return;
                }

            }

            string cmdRemStr = string.Format("Delete from Customers where CustID = {0}", custID);
            string cmdInsStr = string.Format("Insert into CreditRisks (CustID, Firstname, LastName) Values ('{0}', '{1}', '{2}')", custID, fName, lName);
            SqlCommand cmdRemove = new SqlCommand(cmdRemStr, sqlCn);
            SqlCommand cmdInsert = new SqlCommand(cmdInsStr, sqlCn);

            SqlTransaction tx = null;
            try {
                tx = sqlCn.BeginTransaction();
                cmdInsert.Transaction = tx;
                cmdRemove.Transaction = tx;

                cmdInsert.ExecuteNonQuery();
                cmdRemove.ExecuteNonQuery();

                if (throwEx) {
                    throw new Exception("Sorry, simulated db error");
                }

                tx.Commit();

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                tx.Rollback();
            }


        }

    }


    public class NewCar {
        public int CarID { get; set; }
        public string Color { get; set; }
        public string Make { get; set; }
        public string PetName { get; set; }
    }
}
