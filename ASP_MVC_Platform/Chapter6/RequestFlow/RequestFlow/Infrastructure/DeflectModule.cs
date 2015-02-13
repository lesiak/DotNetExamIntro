using System;
using System.Web;
using System.Collections.Generic;

namespace RequestFlow.Infrastructure {
    public class DeflectModule : IHttpModule {        

        public void Dispose() {
           // do nothing
        }

        public void Init(HttpApplication app) {
            app.BeginRequest += (src, args) => {
                if (app.Request.RawUrl.ToLower().StartsWith("/home")) {
                    app.Response.StatusCode = 500;
                    app.CompleteRequest();
                }
            };
        }
    }
}
