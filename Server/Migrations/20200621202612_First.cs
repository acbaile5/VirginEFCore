using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Сущности0",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Параметр0 = table.Column<bool>(nullable: false),
                    Параметр1 = table.Column<DateTime>(type: "DATETIME2(0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Сущности0", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Сущности0");
        }
    }
}
