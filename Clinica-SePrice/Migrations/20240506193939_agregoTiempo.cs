using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinica_SePrice.Migrations
{
    /// <inheritdoc />
    public partial class agregoTiempo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "HoraEntrada",
                table: "SalaEspera",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "HoraLlamado",
                table: "SalaEspera",
                type: "datetime(6)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HoraEntrada",
                table: "SalaEspera");

            migrationBuilder.DropColumn(
                name: "HoraLlamado",
                table: "SalaEspera");
        }
    }
}
