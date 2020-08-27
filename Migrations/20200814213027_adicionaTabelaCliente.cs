using Microsoft.EntityFrameworkCore.Migrations;

namespace WEB_API_CORE.Migrations
{
    public partial class adicionaTabelaCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CLIENTES",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODIGO = table.Column<int>(nullable: false),
                    CPF_CNPJ = table.Column<string>(maxLength: 14, nullable: false),
                    EMAIL = table.Column<string>(maxLength: 60, nullable: true),
                    NOME = table.Column<string>(maxLength: 60, nullable: false),
                    EXCLUIDO = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTES", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CLIENTES");
        }
    }
}
