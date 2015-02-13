using System;
using System.Diagnostics;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using ContentCache.Infrastructure;

namespace ContentCache.Controllers {
    public class HomeController : Controller {
        // GET: Home
        /*[OutputCache(Duration = 30,
            VaryByHeader = "user-agent",
            VaryByParam = "name;city",
            VaryByCustom = "mobile",
            Location = OutputCacheLocation.Server)]*/
        //[OutputCache(CacheProfile = "cp1")]
        public ActionResult Index() {
            /*   if (Request.RawUrl == "/Home/Index") {
                Response.Cache.SetNoServerCaching();
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
            }
            else {
                Response.Cache.SetExpires(DateTime.Now.AddSeconds(30));
                Response.Cache.SetCacheability(HttpCacheability.Public);
            }*/
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(30));
            Response.Cache.SetCacheability(HttpCacheability.Server);
            Response.Cache.AddValidationCallback(CheckCachedItem, Request.UserAgent);
            Thread.Sleep(1000);
            var counterValue = AppStateHelper.IncrementAndGet(AppStateKeys.INDEX_COUNTER);
            Debug.WriteLine("INDEX_COUNTER: {0}", counterValue);
            return View(counterValue);
        }

        private void CheckCachedItem(HttpContext context, object data, ref HttpValidationStatus validationStatus) {
            validationStatus = data.ToString() == context.Request.UserAgent
                ? HttpValidationStatus.Valid
                : HttpValidationStatus.Invalid;
            Debug.WriteLine("Cache Status: " + validationStatus);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 60)]
        public PartialViewResult GetTime() {
            return PartialView((object) DateTime.Now.ToShortTimeString());
        }
    }
}