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
        [Display(Name = "Town")]
        public string town { get; set; }
        [Display(Name = "Street")]
        public string street { get; set; }
        [Display(Name = "Postal code")]
        public string code { get; set; }
        [Display(Name = "number")]
        public string houseNumber { get; set; }
        [Display(Name = "Country")]
        public string country { get; set; }
    }
}
