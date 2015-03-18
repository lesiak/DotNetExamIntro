using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Filters.Infrastructure;

namespace Filters.Controllers {
    public class HomeController : Controller {

        private Stopwatch timer;
        
        //[CustomAuth(false)]
        [Authorize(Users = "admin")]
        public string Index() {
            return "This is the Index action of the Home controller";
        }


        [GoogleAuth]
        [Authorize(Users = "bob@google.com")]
        public string List() {
            return "This is the List action of the Home controller";
        }

        //[RangeException]
        [HandleError(ExceptionType = typeof(ArgumentOutOfRangeException), View = "RangeError")]
        public string RangeTest(int id) {
            if (id > 100) {
                return string.Format("The id value is: {0}", id);
            } else {
                throw new ArgumentOutOfRangeException("id", id, "message");
            }
        }

        //[CustomAction]
        //[ProfileAction]
        //[ProfileResult]
        //[ProfileAll]
        public string FilterTest() {
            return "This is the FilterTest action";
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext) {
            timer = Stopwatch.StartNew();
        }

        protected override void OnResultExecuted(ResultExecutedContext filterContext) {
            timer.Stop();
            filterContext.HttpContext.Response.Write(
                    string.Format("<div>Total elapsed time: {0:F6}</div>",
                        timer.Elapsed.TotalSeconds));
        }
    }
}