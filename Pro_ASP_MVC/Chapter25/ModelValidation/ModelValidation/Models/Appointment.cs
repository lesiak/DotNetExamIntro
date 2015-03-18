using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ModelValidation.Models {
    //[NoJoeIn2015]
    public class Appointment {
        [Required]
        [StringLength(10, MinimumLength = 3)]
        public string ClientName { get; set; }

        [DataType(DataType.Date)]
        //[Required(ErrorMessage = "Please enter a date")]
        //[FutureDate(ErrorMessage = "Please enter a future date")]
        [Remote("ValidateDate", "Home")]
        public DateTime Date { get; set; }

        //[MustBeTrue(ErrorMessage = "You must accept the terms")]
        public bool TermsAccepted { get; set; }
    }
}