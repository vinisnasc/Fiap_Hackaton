using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fiap_Hackaton.Identity.API.Migrations
{
    /// <inheritdoc />
    public partial class defaultroles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1d7c3e7b-2fbc-4a1b-8a45-1e2eae6f9d8a", null, "Medico", "MEDICO" },
                    { "2e8b9d3c-3fac-4c2b-9d56-2f4c4e7e8d9b", null, "Paciente", "PACIENTE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d7c3e7b-2fbc-4a1b-8a45-1e2eae6f9d8a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e8b9d3c-3fac-4c2b-9d56-2f4c4e7e8d9b");
        }
    }
}
