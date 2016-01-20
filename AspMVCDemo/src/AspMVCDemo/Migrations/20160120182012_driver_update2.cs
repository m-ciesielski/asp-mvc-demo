using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace AspMVCDemo.Migrations
{
    public partial class driver_update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Driver_Address_addressID", table: "Driver");
            migrationBuilder.AlterColumn<string>(
                name: "model",
                table: "Vehicle",
                nullable: false);
            migrationBuilder.AlterColumn<string>(
                name: "brand",
                table: "Vehicle",
                nullable: false);
            migrationBuilder.AlterColumn<string>(
                name: "VIN",
                table: "Vehicle",
                nullable: false);
            migrationBuilder.AlterColumn<string>(
                name: "PESEL",
                table: "Driver",
                nullable: true);
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
            migrationBuilder.AlterColumn<string>(
                name: "model",
                table: "Vehicle",
                nullable: true);
            migrationBuilder.AlterColumn<string>(
                name: "brand",
                table: "Vehicle",
                nullable: true);
            migrationBuilder.AlterColumn<string>(
                name: "VIN",
                table: "Vehicle",
                nullable: true);
            migrationBuilder.AlterColumn<string>(
                name: "PESEL",
                table: "Driver",
                nullable: false);
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
