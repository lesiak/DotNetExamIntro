using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControllersAndActions.Controllers {
    public class ExampleController : Controller {
        // GET: Example
        public ViewResult Index() {
            DateTime date = DateTime.Now;
            return View(date);
        }

        public RedirectToRouteResult Redirect() {
            //return Redirect("/Example/Index");
             return RedirectToRoute(new {
                 controller = "Example",
                 action = "Index",
                 ID= "MyID"
             });
        }

        public RedirectToRouteResult Redirect2() {            
            return RedirectToAction("Index");
        }

        public HttpStatusCodeResult StatusCode() {
            
            //return new HttpStatusCodeResult(404, "URL cannot be serviced");
            //return HttpNotFound();
            return new HttpUnauthorizedResult();
        }
    }
}