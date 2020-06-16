using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class createOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblOrder",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OrderNumber = table.Column<Guid>(nullable: false),
                    OrderState = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    TotalPrice = table.Column<double>(nullable: false),
                    totalAmount = table.Column<double>(nullable: false),
                    Tax = table.Column<double>(nullable: false),
                    User_FirsName = table.Column<string>(maxLength: 300, nullable: false),
                    User_LastName = table.Column<string>(maxLength: 600, nullable: false),
                    User_Password = table.Column<string>(maxLength: 300, nullable: false),
                    User_Mobile = table.Column<string>(maxLength: 15, nullable: false),
                    User_CreateDate = table.Column<DateTime>(nullable: false),
                    User_state = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOrder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblOrderLine",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Food_FoodName = table.Column<string>(maxLength: 200, nullable: false),
                    Food_foodType = table.Column<int>(nullable: false),
                    Food_price_val = table.Column<decimal>(nullable: false),
                    Food_IsExist = table.Column<bool>(nullable: false),
                    Food_state = table.Column<int>(nullable: false),
                    Qty = table.Column<int>(nullable: false),
                    OrderId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOrderLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblOrderLine_tblOrder_OrderId",
                        column: x => x.OrderId,
                        principalTable: "tblOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblOrder_User_Mobile",
                table: "tblOrder",
                column: "User_Mobile",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblOrderLine_Food_FoodName",
                table: "tblOrderLine",
                column: "Food_FoodName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblOrderLine_OrderId",
                table: "tblOrderLine",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblOrderLine");

            migrationBuilder.DropTable(
                name: "tblOrder");
        }
    }
}
