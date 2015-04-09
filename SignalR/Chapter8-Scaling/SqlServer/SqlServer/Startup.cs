using Microsoft.AspNet.SignalR;
using Owin;

namespace SqlServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var connectionString = @"Data Source=(localdb)\v11.0;Initial Catalog=SignalRBroadcastDb;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";              
            /* Example of connection string:
               @"server=.\SQLExpress;database=signalrscaleout;Trusted_Connection=yes";
            */
            var config = new SqlScaleoutConfiguration(connectionString)
                            {
                                TableCount = 5
                            };
            GlobalHost.DependencyResolver.UseSqlServer(config);
            app.MapSignalR();
        }
    }
}