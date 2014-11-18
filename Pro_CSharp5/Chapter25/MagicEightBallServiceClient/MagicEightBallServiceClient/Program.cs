using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicEightBallServiceClient.ServiceReference1;

namespace MagicEightBallServiceClient {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Ask the magic 8 Ball");
            using (EightBallClient ballClient = new EightBallClient("NetTcpBinding_IEightBall")) {
                Console.WriteLine("Your question");
                string question = Console.ReadLine();
                string answer = ballClient.ObtainAnswerToQuestion(question);
                Console.WriteLine("8-ball says: {0}", answer);
            }
            Console.ReadLine();
        }
    }
}
