using Microsoft.EntityFrameworkCore.Migrations;

namespace WEB_API_CORE.Migrations
{
    public partial class mudaColunasExcluido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EXCLUIDO",
                table: "USUARIOS",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "B1_TAMANHO",
                table: "REMESSAS",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "EXCLUIDO",
                table: "REMESSAS",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EXCLUIDO",
                table: "PRODUTOS",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EXCLUIDO",
                table: "LOTES",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EXCLUIDO",
                table: "CATEGORIAS",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EXCLUIDO",
                table: "USUARIOS");

            migrationBuilder.DropColumn(
                name: "EXCLUIDO",
                table: "REMESSAS");

            migrationBuilder.DropColumn(
                name: "EXCLUIDO",
                table: "PRODUTOS");

            migrationBuilder.DropColumn(
                name: "EXCLUIDO",
                table: "LOTES");

            migrationBuilder.DropColumn(
                name: "EXCLUIDO",
                table: "CATEGORIAS");

            migrationBuilder.AlterColumn<string>(
                name: "B1_TAMANHO",
                table: "REMESSAS",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
