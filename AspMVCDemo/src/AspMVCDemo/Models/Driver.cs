using AspMVCDemo.Validators;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspMVCDemo.Models
{
    public class Driver
    {
        public int ID { get; set; }

        [Display(Name = "First Name")]
        [StringLength(30, MinimumLength = 2)]
        [Required]
        public string firstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(50, MinimumLength = 2)]
        [Required]
        public string lastName { get; set; }

        [Display(Name = "Salary")]
        public decimal salary { get; set; }

        [Pesel]
        public string PESEL { get; set; }

        [Display(Name = "Salary Bonus")]
        public decimal salaryBonus { get; set; }

        public bool available { get; set; }
        public bool deleted { get; set; }

        [Required]
        public virtual Address address { get; set; }

        public Driver()
        {
            deleted = false;
            available = true;
        }
    }
}
