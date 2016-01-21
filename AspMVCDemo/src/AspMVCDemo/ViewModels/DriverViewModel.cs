using AspMVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspMVCDemo.ViewModels
{
    public class DriverViewModel
    {
        public Driver driver { get; set; }
        public int addressId { get; set; }
        
        public DriverViewModel() { }

        public DriverViewModel(Driver driver, int addressId) 
        {
            this.driver = driver;
            this.addressId = addressId;
        }
    }
}
