using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Techs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TechId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Techs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Techs_Techs_TechId",
                        column: x => x.TechId,
                        principalTable: "Techs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KnownTechs = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InterestTechs = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WannaMention = table.Column<bool>(type: "bit", nullable: false),
                    WannaBeMentioned = table.Column<bool>(type: "bit", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Techs_TechId",
                table: "Techs",
                column: "TechId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Techs");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
