using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace SimpleApp.Infrastructure {

    public class RequestTimerEventArgs : EventArgs {
        public float Duration { get; set; }
    }

    public class TimerModule : IHttpModule {
        public event EventHandler<RequestTimerEventArgs> RequestTimed;
        private Stopwatch timer;
            
        public void Init(HttpApplication app) {
            app.BeginRequest += HandleEvent;
            app.EndRequest += HandleEvent;
        }

        private void HandleEvent(object src, EventArgs args) {
            HttpContext ctx = HttpContext.Current;
            if (ctx.CurrentNotification == RequestNotification.BeginRequest) {
                timer = Stopwatch.StartNew();
            } else {
                float elapsed = (float) timer.ElapsedTicks / Stopwatch.Frequency;
                string msg = string.Format("<div class='alert alert-success'>Elapsed: {0:F5} seconds</div>", elapsed);
                if (RequestTimed != null) {
                    RequestTimed(this, new RequestTimerEventArgs { Duration = elapsed });
                }
                ctx.Response.Write(msg);
            }
        }

        public void Dispose() {
            // do nothing
        }

    }
}