using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace contosopizza.Migrations
{
    /// <inheritdoc />
    public partial class updatetoppingfields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Calories",
                table: "Toppings",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Calories",
                table: "Toppings");
        }
    }
}
