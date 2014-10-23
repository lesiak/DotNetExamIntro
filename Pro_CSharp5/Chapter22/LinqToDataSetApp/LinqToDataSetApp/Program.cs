using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLotDAL.Properties;
using AutoLotDAL.Properties.AutoLotDataSetTableAdapters;
using System.Data;

namespace LinqToDataSetApp {
    class Program {
        static void Main(string[] args) {
            AutoLotDataSet ds = new AutoLotDataSet();
            InventoryTableAdapter da = new InventoryTableAdapter();
            AutoLotDataSet.InventoryDataTable data = da.GetData();
            PrintAllCarIDs(data);

            ShowBlackCars(data);
            ShowBlackCars2(data);
            ShowBlackCarsStronglyTyped(data);
            BuildDataTableFromQuery(data);
            Console.ReadLine();
        }

        static void PrintAllCarIDs(DataTable data) {
            EnumerableRowCollection enumData = data.AsEnumerable();

            foreach (DataRow r in enumData) {
                Console.WriteLine("CarID = {0}", r["CarID"]);
            }
        }

        static void ShowBlackCars(DataTable data) {
            var cars = from car in data.AsEnumerable()
                       where (string)car["Color"] == "Black"
                       select new { ID = (int)car["CarID"], Make = (string)car["Make"] };
            Console.WriteLine("Black cars:");
            foreach (var item in cars) {
                Console.WriteLine("-> CarID = {0} is {1}", item.ID, item.Make);
            }
        }


        static void ShowBlackCars2(DataTable data) {
            var cars = from car in data.AsEnumerable()
                       where car.Field<string>("Color") == "Black"
                       select new { ID = car.Field<int>("CarID"), Make = car.Field<string>("Make") };
            Console.WriteLine("Black cars:");
            foreach (var item in cars) {
                Console.WriteLine("-> CarID = {0} is {1}", item.ID, item.Make);
            }
        }

        static void ShowBlackCarsStronglyTyped(AutoLotDataSet.InventoryDataTable data) {
            var cars = from car in data.AsEnumerable()
                       where car.Color == "Black"
                       select new { ID = car.CarID, Make = car.Make };
            Console.WriteLine("Black cars:");
            foreach (var item in cars) {
                Console.WriteLine("-> CarID = {0} is {1}", item.ID, item.Make);
            }
        }

        static void BuildDataTableFromQuery(DataTable data) {
            var cars = from car in data.AsEnumerable()
                       where car.Field<int>("CarID") > 50
                       select car;

            DataTable newTable = cars.CopyToDataTable();
            for (int curRow = 0; curRow < newTable.Rows.Count; curRow++) {
                for (int curCol = 0; curCol < newTable.Columns.Count; curCol++) {
                    Console.Write(newTable.Rows[curRow][curCol].ToString().Trim() + "\t");
                }
                Console.WriteLine();

            }
        }
    }
}
