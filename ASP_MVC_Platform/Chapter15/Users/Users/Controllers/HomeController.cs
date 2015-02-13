using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Users.Infrastructure;
using Users.Models;

namespace Users.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [Authorize]
        public ActionResult Index() {            
            return View(GetData("Index"));
        }

        [Authorize(Roles = "Users")]
        public ActionResult OtherAction() {
            return View("Index", GetData("OtherAction"));
        }

        [Authorize]
        public ActionResult UserProps() {
            return View(CurrentUser);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> UserProps(Cities city) {
            AppUser user = CurrentUser;
            user.City = city;
            user.SetCountryFromCity(city);
            await UserManager.UpdateAsync(user);
            return View(user);
        }

        private Dictionary<string, object> GetData(string actionName) {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("Action", actionName);
            data.Add("User", HttpContext.User.Identity.Name);
            data.Add("Authenticated", HttpContext.User.Identity.IsAuthenticated);
            data.Add("Auth Type", HttpContext.User.Identity.AuthenticationType);
            data.Add("In Users Role", HttpContext.User.IsInRole("Users"));
            return data;
        }

        private AppUser CurrentUser {
            get {
                return UserManager.FindByName(HttpContext.User.Identity.Name);                
            }
        }

        private AppUserManager UserManager {
            get { return HttpContext.GetOwinContext().GetUserManager<AppUserManager>(); }
        }
    }
}