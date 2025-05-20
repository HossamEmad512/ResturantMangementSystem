using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant.Management.System.Repository.Data.Migrations
{
    public partial class Addteblenumberandphonenumbertocurrentdishandorder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "CurrentDishes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TableNumber",
                table: "CurrentDishes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "CurrentDishes");

            migrationBuilder.DropColumn(
                name: "TableNumber",
                table: "CurrentDishes");
        }
    }
}
