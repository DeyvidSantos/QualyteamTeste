using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QualyteamTeste.Migrations
{
    /// <inheritdoc />
    public partial class MigrationCriacaoCaminhoArquivo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArquivoDoc",
                table: "Documentos");

            migrationBuilder.RenameColumn(
                name: "FilePath",
                table: "Documentos",
                newName: "CaminhoArquivo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CaminhoArquivo",
                table: "Documentos",
                newName: "FilePath");

            migrationBuilder.AddColumn<byte[]>(
                name: "ArquivoDoc",
                table: "Documentos",
                type: "longblob",
                nullable: false);
        }
    }
}
