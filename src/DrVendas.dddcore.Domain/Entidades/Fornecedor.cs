using DrVendas.dddcore.Domain.Shared.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace DrVendas.dddcore.Domain.Entidades
{
    public class Fornecedor : Pessoa
    {
        /* Propriedades de navegação-Um Fornecedor tem um ou  varios produtos 
       *                                                                                                         */
        public ICollection<Produto> Produtos{ get; set; }

        public override bool EstaConsistente()
        {
            ApelidoDeveSerPreenchido();
            ApelidoDeveTerUmTamanhoLimite(20);
            NomeDeveSerPreenchido();
            NomeDeveTerUmTamanhoLimite(100);
            CPFouCNPJDeveSerPreenchido();
            CPFouCNPJDeveSerValido();
            EmaiDeveSerValido();
            EmailDeveTerUmTamanhoLimite(100);
            EnderecoDeveSerPreenchido();
            EnderecoDeveTerUmTamanhoLimite(100);
            BairroDeveTerUmTamanhoLimite(30);
            CidadeDeveSerPreenchida();
            CidadeDeveTerUmTamanhoLimite(30);
            UFDeveSerPreenchida();
            UFDeveSerValida();
            CepDeveSerValido();
            return !ListaErros.Any(); //Se a lista não esta vazia
        }
    }
}
