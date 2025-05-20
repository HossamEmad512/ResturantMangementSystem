using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant.Management.System.Repository.Data.Migrations
{
    public partial class CurrentDishesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TableNumber",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrentDisheId",
                table: "OrderItem",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CurrentDishes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResturantId = table.Column<int>(type: "int", nullable: false),
                    DateOfCreation = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentDishes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_CurrentDisheId",
                table: "OrderItem",
                column: "CurrentDisheId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_CurrentDishes_CurrentDisheId",
                table: "OrderItem",
                column: "CurrentDisheId",
                principalTable: "CurrentDishes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_CurrentDishes_CurrentDisheId",
                table: "OrderItem");

            migrationBuilder.DropTable(
                name: "CurrentDishes");

            migrationBuilder.DropIndex(
                name: "IX_OrderItem_CurrentDisheId",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "TableNumber",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CurrentDisheId",
                table: "OrderItem");
        }
    }
}
