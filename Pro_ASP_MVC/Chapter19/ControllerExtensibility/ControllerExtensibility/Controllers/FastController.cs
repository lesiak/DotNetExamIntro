using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using ControllerExtensibility.Models;

namespace ControllerExtensibility.Controllers {

    [SessionState(SessionStateBehavior.Disabled)]
    public class FastController : Controller {
        public ActionResult Index() {
            return View("Result", new Result {
                ControllerName = "Fase",
                ActionName = "Index"
            });
        }
    }
}