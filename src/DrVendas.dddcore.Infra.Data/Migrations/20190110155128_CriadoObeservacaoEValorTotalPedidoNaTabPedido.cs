using Microsoft.EntityFrameworkCore.Migrations;

namespace DrVendas.dddcore.Infra.Data.Migrations
{
    public partial class CriadoObeservacaoEValorTotalPedidoNaTabPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Observacao",
                table: "Pedido",
                type: "varchar(4000)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorTotalPedido",
                table: "Pedido",
                type: "decimal",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Observacao",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "ValorTotalPedido",
                table: "Pedido");
        }
    }
}
