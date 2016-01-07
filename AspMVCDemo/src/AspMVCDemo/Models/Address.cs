using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspMVCDemo.Models
{
    public class Address
    {
        public int ID { get; set; }
        public string town { get; set; }
        public string street { get; set; }
        public string code { get; set; }
        public string houseNumber { get; set; }
        public string country { get; set; }
    }

    public class AddressDBContext : ApplicationDbContext
    {
        public DbSet<Address> Addresses { get; set; }
    }
}
