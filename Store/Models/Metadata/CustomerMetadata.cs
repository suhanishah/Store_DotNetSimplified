using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Store.Models
{
    [MetadataType(typeof(customer.Metadata))]
    public partial class customer
    {
        sealed class Metadata
        {
            [Required]
            [Display(Name ="First Name")]
            public string first_name { get; set; }

            [Required]
            [Display(Name = "Last Name")]
            public string last_name { get; set; }

            [Display(Name ="Birth Date")]
            public System.DateTime birth_date { get; set; }

            [Phone]
            [Required]
            [Display(Name ="Phone")]
            public string phone { get; set; }

            [Required]
            [Display(Name ="Address")]
            public string address { get; set; }

            [Required]
            [Display(Name = "City")]
            public string city { get; set; }

            [Required]
            [Display(Name = "State")]
            public string state { get; set; }
        }
    }
}