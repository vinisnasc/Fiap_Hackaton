using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap_Hackaton.Identity.API.Migrations
{
    /// <inheritdoc />
    public partial class tornaidentificacaoUnica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Identificacao",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Identificacao",
                table: "AspNetUsers",
                column: "Identificacao",
                unique: true,
                filter: "[Identificacao] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Identificacao",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Identificacao",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
