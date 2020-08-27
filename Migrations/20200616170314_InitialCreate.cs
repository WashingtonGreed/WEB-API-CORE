using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WEB_API_CORE.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CATEGORIAS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORIAS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LOTES",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    REMESSA = table.Column<int>(nullable: false),
                    NOME = table.Column<string>(nullable: false),
                    DATA = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOTES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "REMESSAS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    B1_FILIAL = table.Column<string>(nullable: false),
                    DATA_EMISSAO = table.Column<string>(nullable: false),
                    B1_GRUPO = table.Column<string>(nullable: false),
                    ZZJ_CODCLI = table.Column<string>(nullable: false),
                    ZZJ_CODPRO = table.Column<string>(nullable: false),
                    B1_DESC = table.Column<string>(nullable: false),
                    B1_YMODELO = table.Column<string>(nullable: false),
                    B1_EDICAO = table.Column<string>(nullable: false),
                    ZZJ_FILIAL = table.Column<string>(nullable: false),
                    ZZJ_SERIE = table.Column<string>(nullable: false),
                    ZZJ_LOJA = table.Column<string>(nullable: false),
                    ZZJ_ITEMNF = table.Column<string>(nullable: false),
                    ZZJ_QTDFAT = table.Column<string>(nullable: false),
                    ZZJ_SALDO = table.Column<string>(nullable: false),
                    B1_TAMANHO = table.Column<string>(nullable: false),
                    IMAGEM_0 = table.Column<string>(nullable: false),
                    IMAGEM_1 = table.Column<string>(nullable: true),
                    IMAGEM_2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REMESSAS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USUARIOS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME_SOBRENOME = table.Column<string>(maxLength: 60, nullable: false),
                    CPF_CNPJ = table.Column<string>(maxLength: 14, nullable: false),
                    EMAIL = table.Column<string>(maxLength: 60, nullable: false),
                    SENHA = table.Column<string>(maxLength: 20, nullable: false),
                    ACESSO = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PRODUTOS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(maxLength: 60, nullable: false),
                    DESCRICAO = table.Column<string>(maxLength: 1024, nullable: true),
                    PRECO = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    CATEGORIAID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUTOS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PRODUTOS_CATEGORIAS_CATEGORIAID",
                        column: x => x.CATEGORIAID,
                        principalTable: "CATEGORIAS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTOS_CATEGORIAID",
                table: "PRODUTOS",
                column: "CATEGORIAID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LOTES");

            migrationBuilder.DropTable(
                name: "PRODUTOS");

            migrationBuilder.DropTable(
                name: "REMESSAS");

            migrationBuilder.DropTable(
                name: "USUARIOS");

            migrationBuilder.DropTable(
                name: "CATEGORIAS");
        }
    }
}
