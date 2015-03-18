using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ControllerExtensibility.Models;

namespace ControllerExtensibility.Controllers {
    public class RemoteDataController : Controller {

        public async Task<ActionResult> Data() {
            RemoteService service = new RemoteService();
            string data = await Task<string>.Factory.StartNew(() => {
                return service.GetRemoteData();
            });

            return View((object)data);
        }

        public async Task<ActionResult> ConsumeAsync() {
            string data = await new RemoteService().GetRemoteDataAsync();
            return View("Data", (object) data);
        }
    }
}