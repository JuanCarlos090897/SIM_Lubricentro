using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SIM_Lubricentro.Data.Migrations
{
    public partial class Migracion2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personal",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Telofono = table.Column<string>(nullable: true),
                    Correo = table.Column<string>(nullable: true),
                    Cedula = table.Column<string>(nullable: true),
                    TipoPersonal = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personal", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Reparacion",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Realizado = table.Column<bool>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Carro_ID = table.Column<int>(nullable: true),
                    Personal_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reparacion", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reparacion_Carro_Carro_ID",
                        column: x => x.Carro_ID,
                        principalTable: "Carro",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reparacion_Personal_Personal_ID",
                        column: x => x.Personal_ID,
                        principalTable: "Personal",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reparacion_Carro_ID",
                table: "Reparacion",
                column: "Carro_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Reparacion_Personal_ID",
                table: "Reparacion",
                column: "Personal_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reparacion");

            migrationBuilder.DropTable(
                name: "Personal");
        }
    }
}
