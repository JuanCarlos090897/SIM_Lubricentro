using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SIM_Lubricentro.Data.Migrations
{
    public partial class Migracion4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reparacion_Carro_Carro_ID",
                table: "Reparacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Reparacion_Personal_Personal_ID",
                table: "Reparacion");

            migrationBuilder.DropIndex(
                name: "IX_Reparacion_Carro_ID",
                table: "Reparacion");

            migrationBuilder.DropIndex(
                name: "IX_Reparacion_Personal_ID",
                table: "Reparacion");

            migrationBuilder.DropColumn(
                name: "Carro_ID",
                table: "Reparacion");

            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Reparacion");

            migrationBuilder.DropColumn(
                name: "Personal_ID",
                table: "Reparacion");

            migrationBuilder.DropColumn(
                name: "Realizado",
                table: "Reparacion");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Reparacion",
                newName: "Reparaciones");

            migrationBuilder.RenameColumn(
                name: "TipoPersonal",
                table: "Personal",
                newName: "PuestoDeTrabajo");

            migrationBuilder.RenameColumn(
                name: "Modelo",
                table: "Carro",
                newName: "Vehiculo");

            migrationBuilder.RenameColumn(
                name: "Color",
                table: "Carro",
                newName: "Kms");

            migrationBuilder.AddColumn<int>(
                name: "HistorialID",
                table: "Reparacion",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RealizarReparacionID",
                table: "Reparacion",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Año",
                table: "Carro",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Estilo",
                table: "Carro",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Historial",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Carro_ID = table.Column<int>(nullable: false),
                    Personal_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historial", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Historial_Carro_Carro_ID",
                        column: x => x.Carro_ID,
                        principalTable: "Carro",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Historial_Personal_Personal_ID",
                        column: x => x.Personal_ID,
                        principalTable: "Personal",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RealizarReparacion",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Realizado = table.Column<bool>(nullable: false),
                    Carro_ID = table.Column<int>(nullable: false),
                    Personal_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealizarReparacion", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RealizarReparacion_Carro_Carro_ID",
                        column: x => x.Carro_ID,
                        principalTable: "Carro",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RealizarReparacion_Personal_Personal_ID",
                        column: x => x.Personal_ID,
                        principalTable: "Personal",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PiezaAgregada",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodigoProducto = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    FechaPiezaAgregada = table.Column<DateTime>(nullable: false),
                    Carro_ID = table.Column<int>(nullable: false),
                    HistorialID = table.Column<int>(nullable: true),
                    RealizarReparacionID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PiezaAgregada", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PiezaAgregada_Carro_Carro_ID",
                        column: x => x.Carro_ID,
                        principalTable: "Carro",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PiezaAgregada_Historial_HistorialID",
                        column: x => x.HistorialID,
                        principalTable: "Historial",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PiezaAgregada_RealizarReparacion_RealizarReparacionID",
                        column: x => x.RealizarReparacionID,
                        principalTable: "RealizarReparacion",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reparacion_HistorialID",
                table: "Reparacion",
                column: "HistorialID");

            migrationBuilder.CreateIndex(
                name: "IX_Reparacion_RealizarReparacionID",
                table: "Reparacion",
                column: "RealizarReparacionID");

            migrationBuilder.CreateIndex(
                name: "IX_Historial_Carro_ID",
                table: "Historial",
                column: "Carro_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Historial_Personal_ID",
                table: "Historial",
                column: "Personal_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PiezaAgregada_Carro_ID",
                table: "PiezaAgregada",
                column: "Carro_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PiezaAgregada_HistorialID",
                table: "PiezaAgregada",
                column: "HistorialID");

            migrationBuilder.CreateIndex(
                name: "IX_PiezaAgregada_RealizarReparacionID",
                table: "PiezaAgregada",
                column: "RealizarReparacionID");

            migrationBuilder.CreateIndex(
                name: "IX_RealizarReparacion_Carro_ID",
                table: "RealizarReparacion",
                column: "Carro_ID");

            migrationBuilder.CreateIndex(
                name: "IX_RealizarReparacion_Personal_ID",
                table: "RealizarReparacion",
                column: "Personal_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reparacion_Historial_HistorialID",
                table: "Reparacion",
                column: "HistorialID",
                principalTable: "Historial",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reparacion_RealizarReparacion_RealizarReparacionID",
                table: "Reparacion",
                column: "RealizarReparacionID",
                principalTable: "RealizarReparacion",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reparacion_Historial_HistorialID",
                table: "Reparacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Reparacion_RealizarReparacion_RealizarReparacionID",
                table: "Reparacion");

            migrationBuilder.DropTable(
                name: "PiezaAgregada");

            migrationBuilder.DropTable(
                name: "Historial");

            migrationBuilder.DropTable(
                name: "RealizarReparacion");

            migrationBuilder.DropIndex(
                name: "IX_Reparacion_HistorialID",
                table: "Reparacion");

            migrationBuilder.DropIndex(
                name: "IX_Reparacion_RealizarReparacionID",
                table: "Reparacion");

            migrationBuilder.DropColumn(
                name: "HistorialID",
                table: "Reparacion");

            migrationBuilder.DropColumn(
                name: "RealizarReparacionID",
                table: "Reparacion");

            migrationBuilder.DropColumn(
                name: "Año",
                table: "Carro");

            migrationBuilder.DropColumn(
                name: "Estilo",
                table: "Carro");

            migrationBuilder.RenameColumn(
                name: "Reparaciones",
                table: "Reparacion",
                newName: "Descripcion");

            migrationBuilder.RenameColumn(
                name: "PuestoDeTrabajo",
                table: "Personal",
                newName: "TipoPersonal");

            migrationBuilder.RenameColumn(
                name: "Vehiculo",
                table: "Carro",
                newName: "Modelo");

            migrationBuilder.RenameColumn(
                name: "Kms",
                table: "Carro",
                newName: "Color");

            migrationBuilder.AddColumn<int>(
                name: "Carro_ID",
                table: "Reparacion",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "Reparacion",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Personal_ID",
                table: "Reparacion",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Realizado",
                table: "Reparacion",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Reparacion_Carro_ID",
                table: "Reparacion",
                column: "Carro_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Reparacion_Personal_ID",
                table: "Reparacion",
                column: "Personal_ID");

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
    }
}
