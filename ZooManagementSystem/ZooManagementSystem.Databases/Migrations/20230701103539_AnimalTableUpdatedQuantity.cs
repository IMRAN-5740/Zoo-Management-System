﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZMS.Databases.Migrations
{
    /// <inheritdoc />
    public partial class AnimalTableUpdatedQuantity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Quantity",
                table: "Animals",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Animals");
        }
    }
}
