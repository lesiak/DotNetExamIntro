using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelValidation.Models;

namespace ModelValidation.Controllers {
    public class HomeController : Controller {
        public ViewResult MakeBooking() {
            return View(new Appointment { Date = DateTime.Now });
        }

        [HttpPost]
        public ViewResult MakeBooking(Appointment appt) {
           // if (string.IsNullOrEmpty(appt.ClientName)) {
           //     ModelState.AddModelError("ClientName", "Please enter your name1");
           // }
            //if (ModelState.IsValidField("Date") && DateTime.Now > appt.Date) {
            //    ModelState.AddModelError("Date", "Please entewr a date in the future");
           // }
            //if (!appt.TermsAccepted) {
             //   ModelState.AddModelError("TermsAccepted", "You must accept the terms");
           // }
          //  if (ModelState.IsValidField("ClientName") && ModelState.IsValidField("Date")
          //      && appt.ClientName == "Joe" && appt.Date.Year == 2016) {
         //       ModelState.AddModelError("", "Joe cannot cook appointments in 2016");
          //  }

            if (ModelState.IsValid) {
                // statements to store new Appointment in a
                // repository would go here in a real project
                return View("Completed", appt);
            } else {
                return View();
            }
        }

        public JsonResult ValidateDate(string date) {
            DateTime parsedDate;
            if (!DateTime.TryParse(date, out parsedDate)) {
                return Json("Please enter a valid date", JsonRequestBehavior.AllowGet);
            } else if (DateTime.Now > parsedDate) {
                return Json("Please enter a date in the future", JsonRequestBehavior.AllowGet);
            } else {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
    }
}