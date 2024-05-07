using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinica_SePrice.Migrations
{
    /// <inheritdoc />
    public partial class TablaSalaEspera : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turnos_Medicos_MedicoId",
                table: "Turnos");

            migrationBuilder.DropForeignKey(
                name: "FK_Turnos_Pacientes_PacienteId",
                table: "Turnos");

            migrationBuilder.AlterColumn<int>(
                name: "PacienteId",
                table: "Turnos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MedicoId",
                table: "Turnos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SalaEsperaId",
                table: "Turnos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "EnSalaEspera",
                table: "Pacientes",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "SalaEspera",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaEspera", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_SalaEsperaId",
                table: "Turnos",
                column: "SalaEsperaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Turnos_Medicos_MedicoId",
                table: "Turnos",
                column: "MedicoId",
                principalTable: "Medicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turnos_Pacientes_PacienteId",
                table: "Turnos",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turnos_SalaEspera_SalaEsperaId",
                table: "Turnos",
                column: "SalaEsperaId",
                principalTable: "SalaEspera",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turnos_Medicos_MedicoId",
                table: "Turnos");

            migrationBuilder.DropForeignKey(
                name: "FK_Turnos_Pacientes_PacienteId",
                table: "Turnos");

            migrationBuilder.DropForeignKey(
                name: "FK_Turnos_SalaEspera_SalaEsperaId",
                table: "Turnos");

            migrationBuilder.DropTable(
                name: "SalaEspera");

            migrationBuilder.DropIndex(
                name: "IX_Turnos_SalaEsperaId",
                table: "Turnos");

            migrationBuilder.DropColumn(
                name: "SalaEsperaId",
                table: "Turnos");

            migrationBuilder.DropColumn(
                name: "EnSalaEspera",
                table: "Pacientes");

            migrationBuilder.AlterColumn<int>(
                name: "PacienteId",
                table: "Turnos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MedicoId",
                table: "Turnos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Turnos_Medicos_MedicoId",
                table: "Turnos",
                column: "MedicoId",
                principalTable: "Medicos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Turnos_Pacientes_PacienteId",
                table: "Turnos",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id");
        }
    }
}
