using DrVendas.dddcore.Domain.Shared.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace DrVendas.dddcore.Domain.Entidades
{
    public class Produtos : EntidadeBase
    {
       
        public string Apelido { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public string Unidade { get; set; }
        public int IdFornecedor { get; set; }

 
        public override bool EstaConsistente()
        {
            ApelidoDeveSerPreenchido();
            ApelidoDeveTerUmTamanhoLimite();
            ValorDeverSerSuperiorAZero();
            UnidadeDeveSerValida();
            return !ListaErros.Any();
        }

        private void ApelidoDeveSerPreenchido()
        {
            if (string.IsNullOrEmpty(Apelido)) ListaErros.Add("O campo apelido deve ser preenchido!");
        }

        private void ApelidoDeveTerUmTamanhoLimite()
        {
            if (Apelido.Length > 20) ListaErros.Add("O campo apelido deve ter no máximo 20 caracteres!");
        }

        private void ValorDeverSerSuperiorAZero()
        {
            if (Valor <= 0) ListaErros.Add("O campo valor dever ser maior que zero!");
        }


        private void UnidadeDeveSerValida()
        {
            var listunidade = new List<string> { "KL", "GR", "MT", "CM", "QT" };
            if (!listunidade.Contains(Unidade)) ListaErros.Add("Unidade deve ser KL, GR, MT, CM ou QT!");
        }


    }
}