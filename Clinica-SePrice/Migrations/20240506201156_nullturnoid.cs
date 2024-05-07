using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinica_SePrice.Migrations
{
    /// <inheritdoc />
    public partial class nullturnoid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turnos_SalaEspera_SalaEsperaId",
                table: "Turnos");

            migrationBuilder.AlterColumn<int>(
                name: "SalaEsperaId",
                table: "Turnos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Turnos_SalaEspera_SalaEsperaId",
                table: "Turnos",
                column: "SalaEsperaId",
                principalTable: "SalaEspera",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turnos_SalaEspera_SalaEsperaId",
                table: "Turnos");

            migrationBuilder.AlterColumn<int>(
                name: "SalaEsperaId",
                table: "Turnos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Turnos_SalaEspera_SalaEsperaId",
                table: "Turnos",
                column: "SalaEsperaId",
                principalTable: "SalaEspera",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
