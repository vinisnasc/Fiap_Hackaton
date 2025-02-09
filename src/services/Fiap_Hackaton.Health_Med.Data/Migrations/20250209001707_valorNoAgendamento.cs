using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap_Hackaton.Health_Med.Data.Migrations
{
    /// <inheritdoc />
    public partial class valorNoAgendamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Valor",
                table: "Agendamentos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Agendamentos");
        }
    }
}
