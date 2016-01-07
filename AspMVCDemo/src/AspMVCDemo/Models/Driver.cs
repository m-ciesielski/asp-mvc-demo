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
        public string firstName { get; set; }
        [Display(Name = "Last Name")]
        public string lastName { get; set; }
        public decimal salary { get; set; }
        public string PESEL { get; set; }
        [Display(Name = "Salary Bonus")]
        public decimal salaryBonus { get; set; }
        public bool available { get; set; }
        public bool deleted { get; set; }
        public Address adddress { get; set; }
    }
}
