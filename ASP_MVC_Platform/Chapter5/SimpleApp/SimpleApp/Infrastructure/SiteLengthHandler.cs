using System;
using System.Web;
using System.Net.Http;

namespace SimpleApp.Infrastructure {
    public class SiteLengthHandler : HttpTaskAsyncHandler {

        public override async System.Threading.Tasks.Task ProcessRequestAsync(HttpContext context) {
            string data = await new HttpClient().GetStringAsync("http://www.apress.com");
            context.Response.ContentType = "text/html";
            context.Response.Write(string.Format("<span>Length: {0}</span>", data.Length));
        }
      


    }
}
