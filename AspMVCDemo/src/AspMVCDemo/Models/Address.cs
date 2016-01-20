using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspMVCDemo.Models
{
    public class Address
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Town")]
        [StringLength(80, MinimumLength = 2)]
        public string town { get; set; }

        [Required]
        [Display(Name = "Street")]
        [StringLength(80, MinimumLength = 2)]
        public string street { get; set; }

        [Display(Name = "Postal code")]
        public string code { get; set; }

        [Required]
        [Display(Name = "number")]
        public string houseNumber { get; set; }

        [Required]
        [Display(Name = "Country")]
        [StringLength(50, MinimumLength = 2)]
        public string country { get; set; }

        public override string ToString()
        {
            return String.Format("{0} {1}, {2} {3}, {4}", street, houseNumber, code, town, country );
        }
    }
}
