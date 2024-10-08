﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JDRSportsAcademy.Migrations
{
    public partial class ColumnRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Feedback",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Feedback");
        }
    }
}
