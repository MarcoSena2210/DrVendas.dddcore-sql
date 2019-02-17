using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DrVendas.dddcore.Application.AppVendas.ViewModels
{
    public class ClienteViewModel
    {
        public ClienteViewModel()
        {
            ListaErros = new List<string>();
        }
        public int Id { get; set; }
        public List<string> ListaErros { get; set; }
        public string Apelido { get; set; }
        public string Nome { get; set; }

        [Display(Name = "CPF ou CNPJ")]
        public string CpfCnpj { get; set; }

        [Display(Name = "E-Mail")]
        public string Email { get; set; }

        [Display(Name = "Endereço")]
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }

        public string UF { get; set; }
        public string CEP { get; set; }

    }
}
