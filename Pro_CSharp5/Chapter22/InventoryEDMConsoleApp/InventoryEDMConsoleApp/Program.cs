using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core.EntityClient;

namespace InventoryEDMConsoleApp {
    class Program {
        static void Main(string[] args) {
            AddNewRecord();
            UpdateRecord();
            PrintAllInventory();
            RemoveRecord();
            FunWithLINQQUeries();
           // FunWithLINQQUeriesAllData();
            FunWithEntitySQL();
            FunWithEntityDataReader();
            Console.ReadLine();

        }

        private static void AddNewRecord() {
            using (AutoLotEntities context = new AutoLotEntities()) {
                try {
                    context.Cars.Add(new Car() { CarID = 2224, Make = "Yugo", Color = "Brown" });
                    context.SaveChanges();
                    Console.WriteLine("added 2224");
                } catch (DbUpdateException ex) {
                    Exception e = ex;
                    Console.WriteLine(ex == ex.InnerException);
                    while (e != null) {
                        Console.WriteLine(e.Message);
                        e = e.InnerException;
                    }
                    
                }
                
                catch (Exception ex) {
                    Console.WriteLine(ex);
                }

            }
        }

        public static void UpdateRecord() {
            using (AutoLotEntities context = new AutoLotEntities()) {
                //   EntityKey key = new EntityKey("AutoLotEntities.Cars", "CarID", 2224);
                Car c = context.Cars.Find(2224);
                Console.WriteLine(string.Format("Found : {0}", c));
                if (c != null) {
                    c.Color = "Blue";                    
                    context.SaveChanges();
                }
                Console.WriteLine("changed 2224 to blue");
                // Car carToDelete = context.
            }
        }

        public static void RemoveRecord() {
            using (AutoLotEntities context = new AutoLotEntities()) {
             //   EntityKey key = new EntityKey("AutoLotEntities.Cars", "CarID", 2224);
              //  Car c = context.Cars.Find(2224);
                Car c = (from car in context.Cars where car.CarID == 2224 select car).FirstOrDefault();
               Console.WriteLine(string.Format("Found : {0}" ,c));
               if (c != null) {
                   context.Cars.Remove(c);
                   context.SaveChanges();
               }
               Console.WriteLine("removed 2224");
               // Car carToDelete = context.
            }
        }

        private static void PrintAllInventory() {
            using (AutoLotEntities context = new AutoLotEntities()) {
                foreach (Car c in context.Cars) {
                    Console.WriteLine(c.ToString());
                }
            }
        }

        private static void FunWithLINQQUeries() {
            using (AutoLotEntities context = new AutoLotEntities()) {
                var colorMakes = from item in context.Cars
                                 select new { item.Color, item.Make };
                foreach (var item in colorMakes) {
                    Console.WriteLine(item);
                }

                var idsLessThan1000 = from item in context.Cars
                                      where item.CarID < 1000
                                      select item;
                foreach (var item in idsLessThan1000) {
                    Console.WriteLine(item);
                }
            }
        }

        private static void FunWithLINQQUeriesAllData() {
            using (AutoLotEntities context = new AutoLotEntities()) {
                var allData = context.Cars.ToArray();
                var colorMakes = from item in allData
                                 select new { item.Color, item.Make };
                foreach (var item in colorMakes) {
                    Console.WriteLine(item);
                }

                var idsLessThan1000 = from item in allData
                                      where item.CarID < 1000
                                      select item;
                foreach (var item in idsLessThan1000) {
                    Console.WriteLine(item);
                }
            }
        }

        private static void FunWithEntitySQL() {
            using (AutoLotEntities context = new AutoLotEntities()) {
                Console.WriteLine(context.Cars.ToString());
                string queryString = "SELECT VALUE car from AutoLotEntities.Cars as car WHERE car.Color='Black'";
                ObjectQuery<Car> contactQuery = new ObjectQuery<Car>(queryString, ((IObjectContextAdapter)context).ObjectContext);            
                foreach (var item in contactQuery) {
                    Console.WriteLine(item);
                }
            }
        }

        private static void FunWithEntityDataReader() {
            using (EntityConnection cn = new EntityConnection("name=AutoLotEntities")) {
                cn.Open();
                string queryString = "SELECT VALUE car from AutoLotEntities.Cars as car WHERE car.Color='Black'";
                using (EntityCommand cmd = cn.CreateCommand()) {
                    cmd.CommandText = queryString;

                    using (EntityDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.SequentialAccess)) {
                        while (dr.Read()) {
                            Console.WriteLine(dr["CarID"]);
                        }
                    }
                }
            }                
        }
    }
}
                                      