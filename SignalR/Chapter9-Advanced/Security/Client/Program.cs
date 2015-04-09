using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;

namespace Client {
    internal class Program {
        private static void Main(string[] args) {
            Console.Clear();
            Console.WriteLine("(Enter port number");
            var port = Console.ReadLine();
            string host = "http://localhost:" + port;
            while (true) {
                var connection = new HubConnection(host);
                Console.Clear();
                Console.WriteLine("(Enter 'adam' or 'admin' as username to access private methods)");
                Console.Write("Enter your username: ");
                var username = Console.ReadLine();
                Console.Write("Enter your password: ");
                var password = Console.ReadLine();

                var authCookie = GetAuthCookie(host + "/account/login", username, password).Result;

                if (authCookie == null) {
                    Console.WriteLine("Impossible to get the token. Press a key to try again.");
                    Console.ReadKey();
                    continue;
                }

                Console.WriteLine("Token obtained");
                connection.CookieContainer = new CookieContainer();
                connection.CookieContainer.Add(authCookie);
                var proxy = connection.CreateHubProxy("EchoHub");
                proxy.On<string>("Message", msg => Console.WriteLine("    Received: " + msg));
                connection.Start().Wait();

                Invoke(proxy, "PublicMessage", username);
                Invoke(proxy, "MembersMessage", username);
                Invoke(proxy, "AdminsMessage", username);
                Invoke(proxy, "PrivateMessage", username);
                Console.WriteLine("\n\nPress any key to try again, Ctrl-C to exit");
                Console.ReadKey();
                connection.Stop();

            }
        }

        private static void Invoke(IHubProxy proxy, string method, string username) {
            Console.WriteLine("\nCalling server method " + method + " as " + username);
            try {
                proxy.Invoke(method, username + " invoked " + method + "() from console!").Wait();
            } catch (AggregateException ex) {
                foreach (var innerException in ex.InnerExceptions) {
                    Console.WriteLine("    * " + innerException.Message);
                }
            }
        }

        private static async Task<Cookie> GetAuthCookie(string loginUrl, string user, string pass) {
            var postData = string.Format("username={0}&password={1}", user, pass);
            var httpHandler = new HttpClientHandler();
            httpHandler.CookieContainer = new CookieContainer();
            using (var httpClient = new HttpClient(httpHandler)) {
                var response = await httpClient.PostAsync(loginUrl,
                    new StringContent(postData, Encoding.UTF8, "application/x-www-form-urlencoded"));
                var cookies = httpHandler.CookieContainer.GetCookies(new Uri(loginUrl));
                return cookies["Token"];
            }
        }
    }
}