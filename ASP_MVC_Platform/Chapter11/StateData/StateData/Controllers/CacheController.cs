using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using StateData.Infrastructure;

namespace StateData.Controllers
{
    public class CacheController : Controller
    {
        // GET: Cache
        public ActionResult Index() {
            SelfExpiringData<long?> seData = (SelfExpiringData<long?>)HttpContext.Cache["pageLength"];
            return View(seData == null ? null : seData.Value);
        }

        [HttpPost]
        public async Task<ActionResult> PopulateCache() {
            HttpResponseMessage result = await new HttpClient().GetAsync("http://apress.com");
            long? data = result.Content.Headers.ContentLength;
            //DateTime expiryTime = DateTime.Now.AddSeconds(30);
            //HttpContext.Cache.Insert("pageLength", data, null, expiryTime, Cache.NoSlidingExpiration);
           // TimeSpan idleDuration = new TimeSpan(0, 0, 30);
            //HttpContext.Cache.Insert("pageLength", data, null, Cache.NoAbsoluteExpiration, idleDuration);
            


      
            SelfExpiringData<long?> seData = new SelfExpiringData<long?>(data, 3);


            //CacheDependency fileDep = new CacheDependency(Request.MapPath("~/data.txt"));
            //AggregateCacheDependency aggDep = new AggregateCacheDependency();
            //aggDep.Add(seData, fileDep);

          //  HttpContext.Cache.Insert("pageLength", seData, seData, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration,
            //    CacheItemPriority.Normal, HandleRemovalNotification);

            HttpContext.Cache.Insert("pageLength", seData, seData,
                Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration, HandleUpdateNotification);
                


            //DateTime timestamp = DateTime.Now;
            //CacheDependency timestampDependency = new CacheDependency(null, new[] { "pageLength" });
            //HttpContext.Cache.Insert("pageTimestamp", timestamp, timestampDependency);



            return RedirectToAction("Index");
        }

        private void HandleUpdateNotification(string key, CacheItemUpdateReason reason, out object expensiveObject, out CacheDependency dependency, 
            out DateTime absoluteExpiration, out TimeSpan slidingExpiration) {
            System.Diagnostics.Debug.WriteLine("Item {0} removed ({1})", key, Enum.GetName(typeof(CacheItemUpdateReason), reason));
            expensiveObject = dependency = new SelfExpiringData<long?>(GetData(false).Result, 3);

            absoluteExpiration = Cache.NoAbsoluteExpiration;
            slidingExpiration = Cache.NoSlidingExpiration;
            
        }

        private async Task<long?> GetData(bool awaitCon = true) {
            HttpResponseMessage response = await new HttpClient().GetAsync("http://apress.com").ConfigureAwait(awaitCon);
            return response.Content.Headers.ContentLength;
        }

        private void HandleRemovalNotification(string key, object value, CacheItemRemovedReason reason) {
            System.Diagnostics.Debug.WriteLine("Item {0} removed ({1})", key, Enum.GetName(typeof(CacheItemRemovedReason), reason));
        }
    }
}