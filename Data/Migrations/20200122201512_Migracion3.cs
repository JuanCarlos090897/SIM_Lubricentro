using Microsoft.EntityFrameworkCore.Migrations;

namespace SIM_Lubricentro.Data.Migrations
{
    public partial class Migracion3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carro_Cliente_Cliente_ID",
                table: "Carro");

            migrationBuilder.DropForeignKey(
                name: "FK_Reparacion_Carro_Carro_ID",
                table: "Reparacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Reparacion_Personal_Personal_ID",
                table: "Reparacion");

            migrationBuilder.AlterColumn<int>(
                name: "Personal_ID",
                table: "Reparacion",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Carro_ID",
                table: "Reparacion",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Cliente_ID",
                table: "Carro",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Carro_Cliente_Cliente_ID",
                table: "Carro",
                column: "Cliente_ID",
                principalTable: "Cliente",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reparacion_Carro_Carro_ID",
                table: "Reparacion",
                column: "Carro_ID",
                principalTable: "Carro",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reparacion_Personal_Personal_ID",
                table: "Reparacion",
                column: "Personal_ID",
                principalTable: "Personal",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carro_Cliente_Cliente_ID",
                table: "Carro");

            migrationBuilder.DropForeignKey(
                name: "FK_Reparacion_Carro_Carro_ID",
                table: "Reparacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Reparacion_Personal_Personal_ID",
                table: "Reparacion");

            migrationBuilder.AlterColumn<int>(
                name: "Personal_ID",
                table: "Reparacion",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Carro_ID",
                table: "Reparacion",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Cliente_ID",
                table: "Carro",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Carro_Cliente_Cliente_ID",
                table: "Carro",
                column: "Cliente_ID",
                principalTable: "Cliente",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reparacion_Carro_Carro_ID",
                table: "Reparacion",
                column: "Carro_ID",
                principalTable: "Carro",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reparacion_Personal_Personal_ID",
                table: "Reparacion",
                column: "Personal_ID",
                principalTable: "Personal",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
