using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using AspMVCDemo.Models;

namespace AspMVCDemo.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20160108100344_add_driver_constraints")]
    partial class add_driver_constraints
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AspMVCDemo.Models.Address", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("code");

                    b.Property<string>("country");

                    b.Property<string>("houseNumber");

                    b.Property<string>("street");

                    b.Property<string>("town");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("AspMVCDemo.Models.Driver", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PESEL")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 11);

                    b.Property<int?>("adddressID")
                        .IsRequired();

                    b.Property<bool>("available");

                    b.Property<bool>("deleted");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 30);

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<decimal>("salary");

                    b.Property<decimal>("salaryBonus");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("AspMVCDemo.Models.Driver", b =>
                {
                    b.HasOne("AspMVCDemo.Models.Address")
                        .WithMany()
                        .HasForeignKey("adddressID");
                });
        }
    }
}
