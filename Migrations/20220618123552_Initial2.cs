using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Techs_Techs_TechId",
                table: "Techs");

            migrationBuilder.DropIndex(
                name: "IX_Techs_TechId",
                table: "Techs");

            migrationBuilder.DropColumn(
                name: "TechId",
                table: "Techs");

            migrationBuilder.AddColumn<string>(
                name: "AboutMe",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutMe",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "TechId",
                table: "Techs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Techs_TechId",
                table: "Techs",
                column: "TechId");

            migrationBuilder.AddForeignKey(
                name: "FK_Techs_Techs_TechId",
                table: "Techs",
                column: "TechId",
                principalTable: "Techs",
                principalColumn: "Id");
        }
    }
}
