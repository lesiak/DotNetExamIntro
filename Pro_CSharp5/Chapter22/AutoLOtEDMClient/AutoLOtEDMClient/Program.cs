using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLotDAL;
using System.Data.Entity.Core.Objects;

namespace AutoLOtEDMClient {
    class Program {
        static void Main(string[] args) {
            PrintCurtomerOrders("4");
            CallStoredProc();
            Console.ReadLine();
        }

        private static void PrintCurtomerOrders(string custID) {
            int id = int.Parse(custID);

            using (AutoLotEntities context = new AutoLotEntities()) {
                var carsOnOrder = from o in context.Orders
                                  where o.CustID == id
                                  select o.Inventory;
                Console.WriteLine(string.Format("Customer has {0} orders pending", carsOnOrder.Count()));
                foreach (var item in carsOnOrder) {
                    Console.WriteLine("-> {0} {1} named {2}.", item.Color, item.Make, item.PetName);
                }               
            }
        }

        private static void CallStoredProc() {
            using (AutoLotEntities context = new AutoLotEntities()) {
                ObjectParameter outParam = new ObjectParameter("petName", typeof(string));
                context.GetPetName(83, outParam);
                Console.WriteLine(outParam.Value);
            }
        }
    }
}
