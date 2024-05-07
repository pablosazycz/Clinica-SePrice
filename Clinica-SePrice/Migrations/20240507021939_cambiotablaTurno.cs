using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinica_SePrice.Migrations
{
    /// <inheritdoc />
    public partial class cambiotablaTurno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Validado",
                table: "Turnos",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Validado",
                table: "Turnos");
        }
    }
}
