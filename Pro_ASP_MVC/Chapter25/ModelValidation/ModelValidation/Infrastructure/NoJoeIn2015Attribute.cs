using System.ComponentModel.DataAnnotations;
using ModelValidation.Models;

namespace ModelValidation.Infrastructure {
    public class NoJoeIn2015Attribute : ValidationAttribute {
        public NoJoeIn2015Attribute() {
            ErrorMessage = "Joe cannot book meetings in 2015";
        }

        public override bool IsValid(object value) {
            Appointment app = value as Appointment;
            if (app == null || string.IsNullOrEmpty(app.ClientName) || app.Date == null) {
                return true;
            } else {
                return !(app.ClientName == "Joe" && app.Date.Year == 2015);
            }
        }
    }
}