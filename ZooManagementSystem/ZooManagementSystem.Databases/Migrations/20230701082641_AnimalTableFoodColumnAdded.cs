using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZMS.Databases.Migrations
{
    /// <inheritdoc />
    public partial class AnimalTableFoodColumnAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Food",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Food",
                table: "Animals");
        }
    }
}
