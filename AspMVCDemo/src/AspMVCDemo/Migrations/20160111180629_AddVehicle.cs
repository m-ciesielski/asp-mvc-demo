using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace AspMVCDemo.Migrations
{
    public partial class AddVehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Driver_Address_addressID", table: "Driver");
            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VIN = table.Column<string>(nullable: true),
                    available = table.Column<bool>(nullable: false),
                    brand = table.Column<string>(nullable: true),
                    engine = table.Column<int>(nullable: false),
                    horsepower = table.Column<int>(nullable: false),
                    mileage = table.Column<int>(nullable: false),
                    model = table.Column<string>(nullable: true),
                    productionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.ID);
                });
            migrationBuilder.AddForeignKey(
                name: "FK_Driver_Address_addressID",
                table: "Driver",
                column: "addressID",
                principalTable: "Address",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Driver_Address_addressID", table: "Driver");
            migrationBuilder.DropTable("Vehicle");
            migrationBuilder.AddForeignKey(
                name: "FK_Driver_Address_addressID",
                table: "Driver",
                column: "addressID",
                principalTable: "Address",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
