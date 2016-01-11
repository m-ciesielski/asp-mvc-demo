using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using AspMVCDemo.Models;

namespace AspMVCDemo.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int?>("addressID")
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

            modelBuilder.Entity("AspMVCDemo.Models.Vehicle", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("VIN");

                    b.Property<bool>("available");

                    b.Property<string>("brand");

                    b.Property<int>("engine");

                    b.Property<int>("horsepower");

                    b.Property<int>("mileage");

                    b.Property<string>("model");

                    b.Property<DateTime>("productionDate");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("AspMVCDemo.Models.Driver", b =>
                {
                    b.HasOne("AspMVCDemo.Models.Address")
                        .WithMany()
                        .HasForeignKey("addressID");
                });
        }
    }
}
