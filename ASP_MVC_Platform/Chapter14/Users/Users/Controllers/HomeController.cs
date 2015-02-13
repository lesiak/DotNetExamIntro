using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Users.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [Authorize]
        public ActionResult Index() {            
            return View(GetData("Index"));
        }

        [Authorize(Roles = "UserRole")]
        public ActionResult OtherAction() {
            return View("Index", GetData("OtherAction"));
        }

        private Dictionary<string, object> GetData(string actionName) {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("Action", actionName);
            data.Add("User", HttpContext.User.Identity.Name);
            data.Add("Authenticated", HttpContext.User.Identity.IsAuthenticated);
            data.Add("Auth Type", HttpContext.User.Identity.AuthenticationType);
            data.Add("In UserRole Role", HttpContext.User.IsInRole("UserRole"));
            return data;
        }
    }
}