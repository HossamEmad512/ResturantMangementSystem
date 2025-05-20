using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant.Management.System.Repository.Data.Migrations
{
    public partial class updatesalestable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Sales_SalesId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_SalesId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SalesId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "SalesOrdersId",
                table: "OrderItem",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SalesOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResturantId = table.Column<int>(type: "int", nullable: false),
                    TableNumber = table.Column<int>(type: "int", nullable: false),
                    DateOfCreation = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    SalesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesOrders_Sales_SalesId",
                        column: x => x.SalesId,
                        principalTable: "Sales",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_SalesOrdersId",
                table: "OrderItem",
                column: "SalesOrdersId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_SalesId",
                table: "SalesOrders",
                column: "SalesId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_SalesOrders_SalesOrdersId",
                table: "OrderItem",
                column: "SalesOrdersId",
                principalTable: "SalesOrders",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_SalesOrders_SalesOrdersId",
                table: "OrderItem");

            migrationBuilder.DropTable(
                name: "SalesOrders");

            migrationBuilder.DropIndex(
                name: "IX_OrderItem_SalesOrdersId",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "SalesOrdersId",
                table: "OrderItem");

            migrationBuilder.AddColumn<int>(
                name: "SalesId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SalesId",
                table: "Orders",
                column: "SalesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Sales_SalesId",
                table: "Orders",
                column: "SalesId",
                principalTable: "Sales",
                principalColumn: "Id");
        }
    }
}
