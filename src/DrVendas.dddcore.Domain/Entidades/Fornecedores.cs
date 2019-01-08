using DrVendas.dddcore.Domain.Shared.Entidades;
using System.Linq;

namespace DrVendas.dddcore.Domain.Entidades
{
    public class Fornecedores : Pessoa
    {
       
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
