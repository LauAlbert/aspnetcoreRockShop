using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RockShop.Migrations
{
    public partial class UpdateRock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LongDescription",
                table: "Rocks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Rocks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "Rocks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LongDescription",
                table: "Rocks");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Rocks");

            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "Rocks");
        }
    }
}
