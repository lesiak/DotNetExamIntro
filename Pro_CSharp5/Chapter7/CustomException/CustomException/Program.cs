using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomException
{
    class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car("Zippy", 20);
            myCar.CrankTunes(true);
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    myCar.Accelerate(10);
                }
            }
            catch (CarIsDeadException e)
            {
                Console.WriteLine("Error!");
                Console.WriteLine("TargetSite: {0}", e.TargetSite);
                Console.WriteLine("Class defining: {0}", e.TargetSite.DeclaringType);
                Console.WriteLine("Member type: {0}", e.TargetSite.MemberType);
                Console.WriteLine();
                Console.WriteLine("Message: {0}", e.Message);
                Console.WriteLine("CauseOfError: {0}", e.CauseOfError);
                Console.WriteLine("ErrorTimeStamp: {0}", e.ErrorTimeStamp);
                Console.WriteLine();
                Console.WriteLine("Source: {0}", e.Source);
                Console.WriteLine("StackTrace: {0}", e.StackTrace);
                Console.WriteLine("HelpLink: {0}", e.HelpLink);

            }

            Console.ReadLine();
        }
    }
}
