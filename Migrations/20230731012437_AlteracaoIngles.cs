using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QualyteamTeste.Migrations
{
    /// <inheritdoc />
    public partial class AlteracaoIngles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "Documentos",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Processo",
                table: "Documentos",
                newName: "Process");

            migrationBuilder.RenameColumn(
                name: "Codigo",
                table: "Documentos",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "Categoria",
                table: "Documentos",
                newName: "Category");

            migrationBuilder.RenameColumn(
                name: "CaminhoArquivo",
                table: "Documentos",
                newName: "FilePath");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Documentos",
                newName: "Titulo");

            migrationBuilder.RenameColumn(
                name: "Process",
                table: "Documentos",
                newName: "Processo");

            migrationBuilder.RenameColumn(
                name: "FilePath",
                table: "Documentos",
                newName: "CaminhoArquivo");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Documentos",
                newName: "Codigo");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Documentos",
                newName: "Categoria");
        }
    }
}
