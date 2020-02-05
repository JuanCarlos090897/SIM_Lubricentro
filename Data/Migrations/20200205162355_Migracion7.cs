using Microsoft.EntityFrameworkCore.Migrations;

namespace SIM_Lubricentro.Data.Migrations
{
    public partial class Migracion7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comentario",
                table: "Reparacion",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Realizado",
                table: "Reparacion",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comentario",
                table: "Reparacion");

            migrationBuilder.DropColumn(
                name: "Realizado",
                table: "Reparacion");
        }
    }
}
