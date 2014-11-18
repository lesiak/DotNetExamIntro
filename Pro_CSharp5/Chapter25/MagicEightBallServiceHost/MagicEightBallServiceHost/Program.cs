﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using MagicEightBallServiceLib;

namespace MagicEightBallServiceHost {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("***** Console based WCF Host *****");
            using (ServiceHost serviceHost = new ServiceHost(typeof(MagicEightBallService))) {
                serviceHost.Open();
                DisplayHostInfo(serviceHost);

                Console.WriteLine("The service is ready");
                Console.WriteLine("Press enter to terminate service");
                Console.ReadLine();
            }
            
        }

        static void DisplayHostInfo(ServiceHost host) {
            Console.WriteLine();
            Console.WriteLine("**** Host Info ****");
            foreach (System.ServiceModel.Description.ServiceEndpoint se in host.Description.Endpoints) {
                Console.WriteLine("Address: {0}", se.Address);
                Console.WriteLine("Binding: {0}", se.Binding.Name);
                Console.WriteLine("Contract: {0}", se.Contract.Name);
                Console.WriteLine();                
            }
            Console.WriteLine("****************************");
        }
    }
}
