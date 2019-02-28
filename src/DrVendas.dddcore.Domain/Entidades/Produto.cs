using DrVendas.dddcore.Domain.Entidades.AgregacaoPedido;
using DrVendas.dddcore.Domain.Shared.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace DrVendas.dddcore.Domain.Entidades
{
    public class Produto : EntidadeBase
    {
       
        public string Apelido { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public string Unidade { get; set; }
        public byte [] Foto { get; set; }

        public int FornecedorId { get; set; }

        /* Propriedades de navegação-Um Produto pertence a um fornecedor
         *                                               Um produto tem varios items de pedido  */
        public virtual Fornecedor Fornecedor { get; set; }
        public virtual ICollection<ItemPedido> ItensPedidos { get; set; }

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
            var listunidade = new List<string> { "CM","G ","KG", "M", "UN" };
            if (!listunidade.Contains(Unidade)) ListaErros.Add("Unidade deve ser CM, G , KG, M ou UN !");
        }

        private void FornecedorDeveSerPreenchido()
        {
            if (FornecedorId == 0) ListaErros.Add("O campo fornecedor dever ser informado!");
        }

    }
}