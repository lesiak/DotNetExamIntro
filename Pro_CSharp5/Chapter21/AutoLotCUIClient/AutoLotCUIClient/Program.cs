using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoLotConnectedLayer;
using System.Configuration;
using System.Data;

namespace AutoLotCUIClient {
    class Program {
        static void Main(string[] args) {
            string cnStr = ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"].ConnectionString;
            //  Console.WriteLine(dp);
            Console.WriteLine(cnStr);


            InventoryDAL invDAL = new InventoryDAL();
            invDAL.OpenConnection(cnStr);
            try {
                DeleteCar(invDAL, 44);
                NewCar c = new NewCar { CarID = 44, Color = "Yellow", Make = "FIAT", PetName = "Bąbel" };
                InsertNewCar(invDAL, c);
                UpdateCarPetName(invDAL, 44, "Bombel");

                ListInventoryAsTable(invDAL);
                ListInventoryAsList(invDAL);
                LookupPetName(invDAL, 44);
                DeleteCar(invDAL, 44);
                
            } finally {
                invDAL.CloseConnection();
            }

            Console.ReadLine();
        }

        static void ShowInstructions() {

        }

        static void InsertNewCar(InventoryDAL invDal, NewCar c) {
            invDal.InsertAuto(c);
        }

        static void UpdateCarPetName(InventoryDAL invDal, int carID, string newCarName) {
            invDal.UpdateCarPetName(carID, newCarName);
        }

        static void DeleteCar(InventoryDAL invDal, int carID) {
            try {
                invDal.DeleteCar(carID);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        static void ListInventoryAsTable(InventoryDAL invDal) {
            Console.WriteLine("************* ListInventoryAsTable *********");
            DataTable dt = invDal.GetAllInventoryAsDataTable();
            DisplayTable(dt);
        }

        static void DisplayTable(DataTable dt) {
            for (int curCol = 0; curCol < dt.Columns.Count; curCol++) {
                Console.Write(dt.Columns[curCol].ColumnName + "\t");
            }
            Console.WriteLine("\n--------------------------------------");

            for (int curRow = 0; curRow < dt.Rows.Count; curRow++) {
                for (int curCol = 0; curCol < dt.Columns.Count; curCol++) {
                    Console.Write(dt.Rows[curRow][curCol].ToString() + "\t");
                }
                Console.WriteLine();
            }
        }

        static void ListInventoryAsList(InventoryDAL invDal) {
            Console.WriteLine("************* ListInventoryAsList *********");
            List<NewCar> data = invDal.GetAllInventoryAsList();
            foreach (NewCar c in data) {
                Console.WriteLine("CarID: {0}, Make: {1}, Color: {2}, PetName: {3}",
                    c.CarID, c.Make, c.Color, c.PetName);
            }
        }

        static void LookupPetName(InventoryDAL invDal, int id) {
            string petName = invDal.LookupPetName(id);
            Console.WriteLine("pet Name of {0} is {1}", id, petName);
        }
    }
}
