using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant.Management.System.Repository.Data.Migrations
{
    public partial class Addstatustocurrendishe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "CurrentDishes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "CurrentDishes");
        }
    }
}
