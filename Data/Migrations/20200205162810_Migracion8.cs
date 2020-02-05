using Microsoft.EntityFrameworkCore.Migrations;

namespace SIM_Lubricentro.Data.Migrations
{
    public partial class Migracion8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Realizado",
                table: "Reparacion",
                newName: "Realizar");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Realizar",
                table: "Reparacion",
                newName: "Realizado");
        }
    }
}
