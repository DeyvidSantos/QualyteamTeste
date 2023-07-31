using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QualyteamTeste.Migrations
{
    /// <inheritdoc />
    public partial class AlteracaoIngles2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VarProcesso",
                table: "Processos",
                newName: "Process");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Process",
                table: "Processos",
                newName: "VarProcesso");
        }
    }
}
