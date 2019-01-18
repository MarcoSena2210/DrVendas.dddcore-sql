using DrVendas.dddcore.Domain.Shared.Entidades;
using System.Linq;

namespace DrVendas.dddcore.Domain.Entidades.AgregacaoPedido
{ 
   public class ItemPedido : EntidadeBase
    {
        public int Qtd { get; set; }
        public decimal ValorItem { get; set; }
        public decimal ValorTotalItem { get; set; }

        public int PedidoId { get; set; }
        public virtual  Pedido Pedido  { get; set; }

        public int ProdutoId { get; set; }
        public virtual Produto  Produto{ get; set; }

        public override bool EstaConsistente()
        {
            QuantidadeDeveSerSuperiorAZero();
            ItemDePedidoDeveSerAssociadoAUmPedido();
            ProdudoDeveSerPreenchido();
            return !ListaErros.Any();
        }

        public bool EstaConsistente(bool pedido)
        {
            QuantidadeDeveSerSuperiorAZero();
            ProdudoDeveSerPreenchido();
            return !ListaErros.Any();
        }

        private void QuantidadeDeveSerSuperiorAZero()
        {
            if (Qtd <= 0) ListaErros.Add("Quantidade deverá ser informada!");
        }

        private void ItemDePedidoDeveSerAssociadoAUmPedido()
        {
            if (PedidoId <= 0) ListaErros.Add("Numero do pedido inválido!");
        }

        private void ProdudoDeveSerPreenchido()
        {
            if (ProdutoId <= 0) ListaErros.Add("Produto deve ser informado!");
        }

        private void ValorDoItemDeverSerSuperiorAZero()
        {
            if (ValorItem <= 0) ListaErros.Add("O campo valor do item dever ser maior que zero!");
        }

        private void ValorTotalDoItemDeverSerSuperiorAZero()
        {
            if (ValorTotalItem <= 0) ListaErros.Add("O campo valor total do item dever ser maior que zero!");
        }



    }
}