using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QualyteamTeste.Migrations
{
    /// <inheritdoc />
    public partial class MigrationCriacaoFilepath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Documentos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Documentos");
        }
    }
}
