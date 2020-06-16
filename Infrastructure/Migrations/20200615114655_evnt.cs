using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class evnt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "events",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    actionName = table.Column<string>(nullable: true),
                    jsonRequest = table.Column<string>(nullable: true),
                    jsonResponse = table.Column<string>(nullable: true),
                    EntityName = table.Column<string>(nullable: true),
                    date = table.Column<DateTime>(nullable: false),
                    Issucces = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_events", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "events");
        }
    }
}
