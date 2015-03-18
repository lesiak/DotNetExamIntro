using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClientFeatures.Models;

namespace ClientFeatures.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ViewResult MakeBooking()
        {
            return View(new Appointment {
                ClientName = "Adam",
                TermsAccepted = true
            });
        }

        [HttpPost]
        public JsonResult MakeBooking(Appointment appt) {
            //in real project, add code to store appointment here
            return Json(appt, JsonRequestBehavior.AllowGet);
        }
    }
}