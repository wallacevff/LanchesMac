using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LanchesMac.Migrations
{
    public partial class Pedidos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhoCompraItems_Lanches_LancheId",
                table: "CarrinhoCompraItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarrinhoCompraItems",
                table: "CarrinhoCompraItems");

            migrationBuilder.RenameTable(
                name: "CarrinhoCompraItems",
                newName: "CarrinhoCompraItens");

            migrationBuilder.RenameIndex(
                name: "IX_CarrinhoCompraItems_LancheId",
                table: "CarrinhoCompraItens",
                newName: "IX_CarrinhoCompraItens_LancheId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarrinhoCompraItens",
                table: "CarrinhoCompraItens",
                column: "CarrinhoCompraItemId");

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    PedidoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Sobrenome = table.Column<string>(maxLength: 50, nullable: false),
                    Endereco1 = table.Column<string>(maxLength: 100, nullable: false),
                    Endereco2 = table.Column<string>(maxLength: 100, nullable: false),
                    Cep = table.Column<string>(maxLength: 10, nullable: false),
                    Estado = table.Column<string>(maxLength: 10, nullable: false),
                    Cidade = table.Column<string>(maxLength: 50, nullable: true),
                    Telefone = table.Column<string>(maxLength: 25, nullable: false),
                    Email = table.Column<string>(maxLength: 80, nullable: false),
                    PedidoTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PedidoEnviado = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.PedidoId);
                });

            migrationBuilder.CreateTable(
                name: "PedidoDetalhes",
                columns: table => new
                {
                    PedidoDetalheId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PedidoId = table.Column<int>(nullable: false),
                    LancheId = table.Column<int>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoDetalhes", x => x.PedidoDetalheId);
                    table.ForeignKey(
                        name: "FK_PedidoDetalhes_Lanches_LancheId",
                        column: x => x.LancheId,
                        principalTable: "Lanches",
                        principalColumn: "LancheId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoDetalhes_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "PedidoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PedidoDetalhes_LancheId",
                table: "PedidoDetalhes",
                column: "LancheId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoDetalhes_PedidoId",
                table: "PedidoDetalhes",
                column: "PedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarrinhoCompraItens_Lanches_LancheId",
                table: "CarrinhoCompraItens",
                column: "LancheId",
                principalTable: "Lanches",
                principalColumn: "LancheId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhoCompraItens_Lanches_LancheId",
                table: "CarrinhoCompraItens");

            migrationBuilder.DropTable(
                name: "PedidoDetalhes");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarrinhoCompraItens",
                table: "CarrinhoCompraItens");

            migrationBuilder.RenameTable(
                name: "CarrinhoCompraItens",
                newName: "CarrinhoCompraItems");

            migrationBuilder.RenameIndex(
                name: "IX_CarrinhoCompraItens_LancheId",
                table: "CarrinhoCompraItems",
                newName: "IX_CarrinhoCompraItems_LancheId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarrinhoCompraItems",
                table: "CarrinhoCompraItems",
                column: "CarrinhoCompraItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarrinhoCompraItems_Lanches_LancheId",
                table: "CarrinhoCompraItems",
                column: "LancheId",
                principalTable: "Lanches",
                principalColumn: "LancheId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
