using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class orderChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tblOrderLine_Food_FoodName",
                table: "tblOrderLine");

            migrationBuilder.DropColumn(
                name: "Food_FoodName",
                table: "tblOrderLine");

            migrationBuilder.DropColumn(
                name: "Food_IsExist",
                table: "tblOrderLine");

            migrationBuilder.DropColumn(
                name: "Food_foodType",
                table: "tblOrderLine");

            migrationBuilder.DropColumn(
                name: "Food_state",
                table: "tblOrderLine");

            migrationBuilder.DropColumn(
                name: "Food_price_val",
                table: "tblOrderLine");

            migrationBuilder.AddColumn<Guid>(
                name: "FoodId",
                table: "tblOrderLine",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tblFood",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FoodName = table.Column<string>(maxLength: 200, nullable: false),
                    foodType = table.Column<int>(nullable: false),
                    price_val = table.Column<decimal>(nullable: false),
                    IsExist = table.Column<bool>(nullable: false),
                    state = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFood", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblOrderLine_FoodId",
                table: "tblOrderLine",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFood_FoodName",
                table: "tblFood",
                column: "FoodName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tblOrderLine_tblFood_FoodId",
                table: "tblOrderLine",
                column: "FoodId",
                principalTable: "tblFood",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblOrderLine_tblFood_FoodId",
                table: "tblOrderLine");

            migrationBuilder.DropTable(
                name: "tblFood");

            migrationBuilder.DropIndex(
                name: "IX_tblOrderLine_FoodId",
                table: "tblOrderLine");

            migrationBuilder.DropColumn(
                name: "FoodId",
                table: "tblOrderLine");

            migrationBuilder.AddColumn<string>(
                name: "Food_FoodName",
                table: "tblOrderLine",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Food_IsExist",
                table: "tblOrderLine",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Food_foodType",
                table: "tblOrderLine",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Food_state",
                table: "tblOrderLine",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Food_price_val",
                table: "tblOrderLine",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_tblOrderLine_Food_FoodName",
                table: "tblOrderLine",
                column: "Food_FoodName",
                unique: true);
        }
    }
}
