using System;
using System.Web;
using System.Web.Routing;

namespace RequestFlow.Infrastructure {
    public class HandlerSelectionModule : IHttpModule {

        

        public void Dispose() {
            //do nothing
        }

        public void Init(HttpApplication app) {
            app.PostResolveRequestCache += (src, args) => {
                 RouteValueDictionary rvd = app.Context.Request.RequestContext.RouteData.Values;
                 if (!Compare(rvd, "controller", "Home")) {
                     app.Context.RemapHandler(new InfoHandler());
                 }
            };
            
        }

        private bool Compare(RouteValueDictionary rvd, string key, string value) {
            return string.Equals((string)rvd[key], value, StringComparison.OrdinalIgnoreCase);
        }
       
    }
}
