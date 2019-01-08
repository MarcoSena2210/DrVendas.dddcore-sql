using DrVendas.dddcore.Domain.Shared.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace DrVendas.dddcore.Domain.Entidades
{
    public class Produtos : EntidadeBase
    {
       
        public string Apelido { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public string Unidade { get; set; }
        public int IdFornecedor { get; set; }

 
        public override bool EstaConsistente()
        {
            ApelidoDeveSerPreenchido();
            ApelidoDeveTerUmTamanhoLimite();
            NomeDeveSerPreenchido();
            NomeDeveTerUmTamanhoLimite();
            DescricaoDeveSerPreenchido();
            DescricaoDeveTerUmTamanhoLimite();
            ValorDeverSerSuperiorAZero();
            UnidadeDeveSerValida();
            FornecedorDeveSerPreenchido();
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

        private void NomeDeveSerPreenchido()
        {
            if (string.IsNullOrEmpty(Nome)) ListaErros.Add("O campo nome deve ser preenchido!");
        }

        private void NomeDeveTerUmTamanhoLimite()
        {
            if (Nome.Length > 50) ListaErros.Add("O campo nome deve ter no máximo 50 caracteres!");
        }

        private void DescricaoDeveSerPreenchido()
        {
            if (string.IsNullOrEmpty(Descricao)) ListaErros.Add("O campo descrição deve ser preenchido!");
        }

        private void DescricaoDeveTerUmTamanhoLimite()
        {
            if (Descricao.Length > 150) ListaErros.Add("O campo descrição deve ter no máximo 150 caracteres!");
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

        private void FornecedorDeveSerPreenchido()
        {
            if (IdFornecedor == 0) ListaErros.Add("O campo fornecedor dever ser informado!");
        }

    }
}