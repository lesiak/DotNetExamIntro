using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLotDAL.Properties;
using AutoLotDAL.Properties.AutoLotDataSetTableAdapters;

namespace StronglyTypedDataSetConsoleClient {
    class Program {
        static void Main(string[] args) {
            AutoLotDataSet.InventoryDataTable table = new AutoLotDataSet.InventoryDataTable();
            InventoryTableAdapter dAdapt = new InventoryTableAdapter();

            AddRecords(table, dAdapt);
            table.Clear();
            
            dAdapt.Fill(table);


            RemoveRecords(table, dAdapt);

            PrintInventory(table);
            CallStoreProc();
            Console.ReadLine();
        }

        private static void PrintInventory(AutoLotDataSet.InventoryDataTable dt) {
            for (int curCol = 0; curCol < dt.Columns.Count; curCol++) {
                Console.Write(dt.Columns[curCol].ColumnName + "\t");
            }
            Console.WriteLine("\n-------------------------------------------");

            for (int curRow = 0; curRow < dt.Rows.Count; curRow++) {
                for (int curCol = 0; curCol < dt.Columns.Count; curCol++) {
                    Console.Write(dt.Rows[curRow][curCol].ToString() + "\t");
                }
                Console.WriteLine();
            }
        }

        private static void AddRecords(AutoLotDataSet.InventoryDataTable dt, InventoryTableAdapter dAdapt) {
            try {
                AutoLotDataSet.InventoryRow newRow = dt.NewInventoryRow();

                newRow.CarID = 999;
                newRow.Color = "Purple";
                newRow.Make = "BMW";
                newRow.PetName = "Seku";

                dt.AddInventoryRow(newRow);


                dt.AddInventoryRow(995, "Yugo", "Green", "Zippy");

                dAdapt.Update(dt);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        private static void RemoveRecords(AutoLotDataSet.InventoryDataTable dt, InventoryTableAdapter dAdapt) {
            try {
                AutoLotDataSet.InventoryRow rowToDelete = dt.FindByCarID(999);
                dAdapt.Delete(rowToDelete.CarID, rowToDelete.Make, rowToDelete.Color, rowToDelete.PetName);

                rowToDelete = dt.FindByCarID(995);
                dAdapt.Delete(rowToDelete.CarID, rowToDelete.Make, rowToDelete.Color, rowToDelete.PetName);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        private static void CallStoreProc() {
            try {
                QueriesTableAdapter q = new QueriesTableAdapter();
                int carID = 1000;
                string carName = "";
                q.GetPetName(carID, ref carName);
                Console.WriteLine("Car {0} has name: {1}", carID, carName);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
