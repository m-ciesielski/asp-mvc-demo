using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspMVCDemo.Models
{
    public class Vehicle
    {
        public int ID {get; set;}

        [Required]
        [Display(Name = "Horsepower")]
        public int horsepower { get; set; }

        [Required]
        [Display(Name = "Engine spec")]
        public int engine { get; set; }

        [Required]
        [Display(Name = "Mileage")]
        public int mileage { get; set; }

        [Required]
        [Display(Name = "Model")]
        public string model { get; set; }

        [Required]
        [Display(Name = "Brand")]
        public string brand { get; set; }

        [Required]
        [Display(Name = "Vehicle Identification Number")]
        public string VIN { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Production Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime productionDate { get; set; }

        public bool available { get; set; }

        public Vehicle()
        {
            available = true;
        }
    }
}
