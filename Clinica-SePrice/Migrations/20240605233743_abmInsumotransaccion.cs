using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinica_SePrice.Migrations
{
    /// <inheritdoc />
    public partial class abmInsumotransaccion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Insumos_Turnos_TurnoId",
                table: "Insumos");

            migrationBuilder.DropIndex(
                name: "IX_Insumos_TurnoId",
                table: "Insumos");

            migrationBuilder.DropColumn(
                name: "TurnoId",
                table: "Insumos");

            migrationBuilder.CreateTable(
                name: "TransaccionesInsumos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    InsumoId = table.Column<int>(type: "int", nullable: false),
                    CantidadUtilizada = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TurnoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransaccionesInsumos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransaccionesInsumos_Insumos_InsumoId",
                        column: x => x.InsumoId,
                        principalTable: "Insumos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransaccionesInsumos_Turnos_TurnoId",
                        column: x => x.TurnoId,
                        principalTable: "Turnos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_TransaccionesInsumos_InsumoId",
                table: "TransaccionesInsumos",
                column: "InsumoId");

            migrationBuilder.CreateIndex(
                name: "IX_TransaccionesInsumos_TurnoId",
                table: "TransaccionesInsumos",
                column: "TurnoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransaccionesInsumos");

            migrationBuilder.AddColumn<int>(
                name: "TurnoId",
                table: "Insumos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Insumos_TurnoId",
                table: "Insumos",
                column: "TurnoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Insumos_Turnos_TurnoId",
                table: "Insumos",
                column: "TurnoId",
                principalTable: "Turnos",
                principalColumn: "Id");
        }
    }
}
