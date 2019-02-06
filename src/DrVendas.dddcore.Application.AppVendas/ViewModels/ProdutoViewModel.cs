using System.Collections.Generic;

namespace DrVendas.dddcore.Application.AppVendas.ViewModels
{
    public class ProdutoViewModel
    {
        public ProdutoViewModel()
        {
            ListaErros = new List<string>();
        }

        public int Id { get; set; }
        public List<string> ListaErros { get; set; }
        public string Apelido { get; set; }
        public string Nome { get; set; }
        public string Valor { get; set; }
        public string Unidade { get; set; }
        public int IdFornecedor { get; set; }
    }
}
