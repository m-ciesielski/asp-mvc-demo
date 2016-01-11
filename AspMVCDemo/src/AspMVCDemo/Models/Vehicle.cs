using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspMVCDemo.Models
{
    public class Vehicle
    {
        public int ID {get; set;}

        public int horsepower { get; set; }
        public int engine { get; set; }
        public int mileage { get; set; }
        public string model { get; set; }
        public string brand { get; set; }
        public string VIN { get; set; }
        public DateTime productionDate { get; set; }
        public bool available { get; set; }
    }
}
