using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinica_SePrice.Migrations
{
    /// <inheritdoc />
    public partial class turnosestudios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstudioMedicoId",
                table: "Turnos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EstudiosMedicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Precio = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstudiosMedicos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EspecialidadesEstudiosMedicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EstudioMedicoId = table.Column<int>(type: "int", nullable: false),
                    EspecialidadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspecialidadesEstudiosMedicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EspecialidadesEstudiosMedicos_Especialidades_EspecialidadId",
                        column: x => x.EspecialidadId,
                        principalTable: "Especialidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EspecialidadesEstudiosMedicos_EstudiosMedicos_EstudioMedicoId",
                        column: x => x.EstudioMedicoId,
                        principalTable: "EstudiosMedicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_EstudioMedicoId",
                table: "Turnos",
                column: "EstudioMedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_EspecialidadesEstudiosMedicos_EspecialidadId",
                table: "EspecialidadesEstudiosMedicos",
                column: "EspecialidadId");

            migrationBuilder.CreateIndex(
                name: "IX_EspecialidadesEstudiosMedicos_EstudioMedicoId",
                table: "EspecialidadesEstudiosMedicos",
                column: "EstudioMedicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Turnos_EstudiosMedicos_EstudioMedicoId",
                table: "Turnos",
                column: "EstudioMedicoId",
                principalTable: "EstudiosMedicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turnos_EstudiosMedicos_EstudioMedicoId",
                table: "Turnos");

            migrationBuilder.DropTable(
                name: "EspecialidadesEstudiosMedicos");

            migrationBuilder.DropTable(
                name: "Especialidades");

            migrationBuilder.DropTable(
                name: "EstudiosMedicos");

            migrationBuilder.DropIndex(
                name: "IX_Turnos_EstudioMedicoId",
                table: "Turnos");

            migrationBuilder.DropColumn(
                name: "EstudioMedicoId",
                table: "Turnos");
        }
    }
}
