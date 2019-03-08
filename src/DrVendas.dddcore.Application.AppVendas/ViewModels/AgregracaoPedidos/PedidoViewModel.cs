using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "Data do pedido é obrigatório")]
        public string DataPedido { get; set; }
        public string DataEntrega { get; set; }
        public string Observacao { get; set; }

        [Required(ErrorMessage = "Selecione o  produto")]
        public int ProdutoId { get; set; }  //Idproduto 

        [Required(ErrorMessage = "Informe a quantidade de produtos")]
        public string QtdProdutos { get; set; }  //Qtd

         //    public string TotalProdutos { get; set; } retirado para seguir oa aula

        [Required(ErrorMessage = "Selecione um cliente")]
        public int ClienteId { get; set; }


        //public int QtdTotalProdutos { get; set; }
        //public string ValorTotalProdutos { get; set; }
        //public string NomeCliente { get; set; }
        //public string Endereco { get; set; }
        //public string Bairro { get; set; }
        //public string Cidade { get; set; }
        //public string UF { get; set; }
        //public string CEP { get; set; }
    }
}
