using System.Collections.Generic;

namespace DrVendas.dddcore.Application.AppVendas.ViewModels.AgregracaoPedidos
{
    public class ItemPedidoViewModel
    {
        public ItemPedidoViewModel()
        {
            ListaErros = new List<string>();
        }
        public int Id { get; set; }
        public List<string> ListaErros { get; set; }
        public int Qtd { get; set; }
        public int IdPedido { get; set; }
        public int IdProduto { get; set; }

    }
}
