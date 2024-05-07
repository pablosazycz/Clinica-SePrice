using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinica_SePrice.Migrations
{
    /// <inheritdoc />
    public partial class cambiotablasala : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TurnoId",
                table: "SalaEspera",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TurnoId",
                table: "SalaEspera");
        }
    }
}
