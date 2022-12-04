﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoApplication.Migrations
{
    public partial class Navbar_Subnavbar_Relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
             name: "IX_SubNavbars_NavbarId",
             table: "SubNavbars",
             column: "NavbarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
