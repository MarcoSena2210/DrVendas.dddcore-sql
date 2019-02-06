using System;
using System.Collections.Generic;
using System.Text;

namespace DrVendas.dddcore.Application.AppVendas.ViewModels.AgregracaoPedidos
{
    public class PedidoViewModel
    {
        public PedidoViewModel()
        {
            ListaErros = new List<string>();
        }
        public int Id { get; set; }
        public List<string> ListaErros { get; set; }
        public string DataPedido { get; set; }
        public string DataEntrega { get; set; }
        public string Observacao { get; set; }
        public int QtdProdutos { get; set; }
        public string TotalProdutos { get; set; }
        public int IdCliente { get; set; }

    }
}
