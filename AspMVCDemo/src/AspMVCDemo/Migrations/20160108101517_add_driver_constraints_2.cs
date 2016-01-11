using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace AspMVCDemo.Migrations
{
    public partial class add_driver_constraints_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Driver_Address_adddressID", table: "Driver");
            migrationBuilder.DropColumn(name: "adddressID", table: "Driver");
            migrationBuilder.AddColumn<int>(
                name: "addressID",
                table: "Driver",
                nullable: false,
                defaultValue: 1);
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
            migrationBuilder.DropColumn(name: "addressID", table: "Driver");
            migrationBuilder.AddColumn<int>(
                name: "adddressID",
                table: "Driver",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddForeignKey(
                name: "FK_Driver_Address_adddressID",
                table: "Driver",
                column: "adddressID",
                principalTable: "Address",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
