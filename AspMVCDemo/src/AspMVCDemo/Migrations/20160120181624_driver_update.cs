using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace AspMVCDemo.Migrations
{
    public partial class driver_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Driver_Address_addressID", table: "Driver");
            migrationBuilder.AlterColumn<string>(
                name: "town",
                table: "Address",
                nullable: false);
            migrationBuilder.AlterColumn<string>(
                name: "street",
                table: "Address",
                nullable: false);
            migrationBuilder.AlterColumn<string>(
                name: "houseNumber",
                table: "Address",
                nullable: false);
            migrationBuilder.AlterColumn<string>(
                name: "country",
                table: "Address",
                nullable: false);
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
                name: "town",
                table: "Address",
                nullable: true);
            migrationBuilder.AlterColumn<string>(
                name: "street",
                table: "Address",
                nullable: true);
            migrationBuilder.AlterColumn<string>(
                name: "houseNumber",
                table: "Address",
                nullable: true);
            migrationBuilder.AlterColumn<string>(
                name: "country",
                table: "Address",
                nullable: true);
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
