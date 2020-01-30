using Microsoft.EntityFrameworkCore.Migrations;

namespace SIM_Lubricentro.Data.Migrations
{
    public partial class Migracion5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Reparaciones",
                table: "Reparacion",
                newName: "DescripcionReparacion");

            migrationBuilder.AddColumn<string>(
                name: "Celular",
                table: "Personal",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Celular",
                table: "Cliente",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Celular",
                table: "Personal");

            migrationBuilder.DropColumn(
                name: "Celular",
                table: "Cliente");

            migrationBuilder.RenameColumn(
                name: "DescripcionReparacion",
                table: "Reparacion",
                newName: "Reparaciones");
        }
    }
}
