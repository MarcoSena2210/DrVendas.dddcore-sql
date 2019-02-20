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
    //    public int QtdProdutos { get; set; }
    //    public string TotalProdutos { get; set; } retirado para seguir oa aula
        public int IdCliente { get; set; }

        public int QtdTotalProdutos { get; set; }
        public string ValorTotalProdutos { get; set; }
        public string NomeCliente { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
    }
}
