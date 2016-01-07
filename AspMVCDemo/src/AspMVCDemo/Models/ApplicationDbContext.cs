using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using AspMVCDemo.Models;
using Microsoft.Data.Entity.Infrastructure;

namespace AspMVCDemo.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base()
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\\mssqllocaldb;Database=aspnet5-AspMVCDemo-fe4c5c38-1a53-4ce3-aa22-4f99d5943433;Trusted_Connection=True;MultipleActiveResultSets=true;");
        }
        */
        public DbSet<Address> Address { get; set; }
        public DbSet<Driver> Driver { get; set; }
    }
}
