using DrVendas.dddcore.Domain.Entidades;
using DrVendas.dddcore.Domain.Interfaces.Repository;
using DrVendas.dddcore.Domain.Interfaces.Services;
using DrVendas.dddcore.Domain.Interfaces.Services.AgregacaoPedidos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DrVendas.dddcore.Domain.Services
{
    public class ServiceProduto : IServiceProduto
    {

        private readonly IRepositoryProduto repoproduto;
        private readonly IServiceItemPedido serviceitenspedidos;

        public ServiceProduto(IRepositoryProduto _repoproduto,
                               IServiceItemPedido _serviceitenspedidos)
        {
            repoproduto = _repoproduto;
            serviceitenspedidos = _serviceitenspedidos;
        }

        #region Adicionar produtos

        public Produto Adicionar(Produto produto)
        {
            produto = AptoParaAdicionarProduto(produto);
            if (produto.ListaErros.Any()) return produto;
            repoproduto.Adicionar(produto);
            return produto;
        }

        private Produto AptoParaAdicionarProduto(Produto produto)
        {
            if (!produto.EstaConsistente()) return produto;
            produto = VerificarSeApelidoExisteEmInclusao(produto);
            produto = VerificarSeNomeExisteEmInclusao(produto);
            return produto;
        }


        private Produto VerificarSeApelidoExisteEmInclusao(Produto produto)
        {
            if (ObterPorApelido(produto.Apelido) != null) produto.ListaErros.Add("O Apelido " + produto.Apelido + " já existe em outro produto!");
            return produto;
        }

        private Produto VerificarSeNomeExisteEmInclusao(Produto produto)
        {
            if (ObterPorNome(produto.Nome) != null) produto.ListaErros.Add("O Nome " + produto.Nome + " já existe em outro produto!");
            return produto;
        }

        #endregion Adicionar produtos

        #region Atualizar produtos
        public Produto Atualizar(Produto produto)
        {
            produto = AptoParaAlterarProdutos(produto);
            if (produto.ListaErros.Any()) return produto;
            repoproduto.Atualizar(produto);
            return produto;
        }

        private Produto AptoParaAlterarProdutos(Produto produto)
        {
            if (!produto.EstaConsistente()) return produto;
            produto = VerificarSeApelidoExisteEmAlteracao(produto);
            produto = VerificarSeNomeExisteEmAlteracao(produto);
            return produto;
        }

        private Produto VerificarSeApelidoExisteEmAlteracao(Produto produto)
        {
            var result = ObterPorApelido(produto.Apelido);
            if (result != null && result.Id != produto.Id) produto.ListaErros.Add("O Apelido " + produto.Apelido + " já existe em outro produto!");
            return produto;
        }

        private Produto VerificarSeNomeExisteEmAlteracao(Produto produto)
        {
            var result = ObterPorNome(produto.Nome);
            if (result != null && result.Id != produto.Id) produto.ListaErros.Add("O Nome " + produto.Nome + " já existe em outro produto!");
            return produto;
        }


        #endregion Atualizar produtos

        #region Remover produtos
        public Produto Remover(Produto produto)
        {
            produto = VerificarSeExiteProdutoAssociadoAItensPedidos(produto);
            if (produto.ListaErros.Any()) return produto;
            repoproduto.Remover(produto);
            return produto;
        }

        private Produto VerificarSeExiteProdutoAssociadoAItensPedidos(Produto produto)
        {
            var result = serviceitenspedidos.ObterItemPedidoProdutoEspecifico(produto.Id).FirstOrDefault();
            if (result != null) produto.ListaErros.Add("Existe(m) produto(s) associados a um pedido, exclusão não permtida!");
            return produto;
        }


        #endregion Remover produtos

        #region Consultar produtos
        public IEnumerable<Produto> ObterTodos()
        {
            return repoproduto.ObterTodos();
        }

        public Produto ObterPorId(int id)
        {
            return repoproduto.ObterPorId(id);
        }

        public Produto ObterPorApelido(string apelido)
        {
            return repoproduto.ObterPorApelido(apelido);
        }
        public Produto ObterPorNome(string nome)
        {
            return repoproduto.ObterPorNome(nome);
        }

        #endregion Consultar produtos

        public void Dispose()
        {
            repoproduto.Dispose();
            serviceitenspedidos.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}