using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QualyteamTeste.Migrations
{
    /// <inheritdoc />
    public partial class AlteracaoIngles4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Processos",
                table: "Processos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Documentos",
                table: "Documentos");

            migrationBuilder.RenameTable(
                name: "Processos",
                newName: "Process");

            migrationBuilder.RenameTable(
                name: "Documentos",
                newName: "Document");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Process",
                table: "Process",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Document",
                table: "Document",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Process",
                table: "Process");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Document",
                table: "Document");

            migrationBuilder.RenameTable(
                name: "Process",
                newName: "Processos");

            migrationBuilder.RenameTable(
                name: "Document",
                newName: "Documentos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Processos",
                table: "Processos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Documentos",
                table: "Documentos",
                column: "Id");
        }
    }
}
