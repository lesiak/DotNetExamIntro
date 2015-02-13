using System;
using System.Diagnostics;
using System.IO;
using System.Web;


namespace Mobile.Infrastructure {
    public class LogModule : IHttpModule {
        
        private static int sharedCounter = 0;
        private int requestCounter;

        private static object lockObject = new object();
        private Exception requestException = null;
        
        private const string traceCategory = "LogModule";

        public void Dispose() {
            //do nothing
        }

        public void Init(HttpApplication app) {
            app.BeginRequest += (src, args) => {
                HttpContext.Current.Trace.Write(traceCategory, "BeginRequest");
            };

            app.EndRequest += (src, args) => {
                HttpContext.Current.Trace.Write(traceCategory, "EndRequest");
            };

            app.PostMapRequestHandler += (src, args) => {
                HttpContext.Current.Trace.Write(traceCategory,
                    string.Format("Handler: {0}",
                        HttpContext.Current.Handler));
            };

            app.Error += (src, args) => {
                HttpContext.Current.Trace.Warn(traceCategory, string.Format("Error: {0}",
                    HttpContext.Current.Error.GetType().Name));
            };
        }

        
        public void Init2(HttpApplication app) {
            app.BeginRequest += (src, args) => {
                requestCounter = ++sharedCounter;
            };
            app.Error += (src, args) => {
                requestException = HttpContext.Current.Error;
            };
            app.LogRequest += (src, args) => WriteLogMessage(HttpContext.Current);
        }

        

        public void WriteLogMessage(HttpContext ctx) {
            StringWriter sw = new StringWriter();
            sw.WriteLine("--------------");
            sw.WriteLine("Request: {0} for {1}", requestCounter, ctx.Request.RawUrl);
            if (ctx.Handler != null) {
                sw.WriteLine("Handler: {0}", ctx.Handler.GetType());
            }
            sw.WriteLine("Status Code: {0}, Message: {1}", ctx.Response.StatusCode, ctx.Response.StatusDescription);
            sw.WriteLine("Elapsed Time: {0} ms", DateTime.Now.Subtract(ctx.Timestamp).Milliseconds);
            if (requestException != null) {
                sw.WriteLine("Error: {0}", requestException.GetType());
            }
            lock (lockObject) {
                Debug.Write(sw.ToString());
            }
        }
    }
}
