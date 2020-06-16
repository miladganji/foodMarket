using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class createOrder1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tblOrder_User_Mobile",
                table: "tblOrder");

            migrationBuilder.DropColumn(
                name: "User_CreateDate",
                table: "tblOrder");

            migrationBuilder.DropColumn(
                name: "User_FirsName",
                table: "tblOrder");

            migrationBuilder.DropColumn(
                name: "User_LastName",
                table: "tblOrder");

            migrationBuilder.DropColumn(
                name: "User_Mobile",
                table: "tblOrder");

            migrationBuilder.DropColumn(
                name: "User_Password",
                table: "tblOrder");

            migrationBuilder.DropColumn(
                name: "User_state",
                table: "tblOrder");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "tblOrder",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tblUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirsName = table.Column<string>(maxLength: 300, nullable: false),
                    LastName = table.Column<string>(maxLength: 600, nullable: false),
                    Password = table.Column<string>(maxLength: 300, nullable: false),
                    Mobile = table.Column<string>(maxLength: 15, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    state = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUser", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblOrder_UserId",
                table: "tblOrder",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUser_Mobile",
                table: "tblUser",
                column: "Mobile",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tblOrder_tblUser_UserId",
                table: "tblOrder",
                column: "UserId",
                principalTable: "tblUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblOrder_tblUser_UserId",
                table: "tblOrder");

            migrationBuilder.DropTable(
                name: "tblUser");

            migrationBuilder.DropIndex(
                name: "IX_tblOrder_UserId",
                table: "tblOrder");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "tblOrder");

            migrationBuilder.AddColumn<DateTime>(
                name: "User_CreateDate",
                table: "tblOrder",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "User_FirsName",
                table: "tblOrder",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "User_LastName",
                table: "tblOrder",
                maxLength: 600,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "User_Mobile",
                table: "tblOrder",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "User_Password",
                table: "tblOrder",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "User_state",
                table: "tblOrder",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tblOrder_User_Mobile",
                table: "tblOrder",
                column: "User_Mobile",
                unique: true);
        }
    }
}
