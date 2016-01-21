using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace AspMVCDemo.Migrations
{
    public partial class sec : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Driver_Address_addressID", table: "Driver");
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
