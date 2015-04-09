using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Server.Middleware;

namespace Server {
    public class Startup {
        public void Configuration(IAppBuilder app) {
            app.UseCors(CorsOptions.AllowAll);
            var options = new CookieAuthenticationOptions {
                CookieName = "Token"
            };
            app.UseCookieAuthentication(options);
            app.Use<CustomLoginMiddleware>();
            app.MapSignalR(new HubConfiguration {EnableDetailedErrors = true});
        }
    }
}