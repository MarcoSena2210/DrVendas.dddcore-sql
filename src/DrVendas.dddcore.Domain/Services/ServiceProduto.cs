using DrVendas.dddcore.Domain.Entidades;
using DrVendas.dddcore.Domain.Interfaces.Repository;
using DrVendas.dddcore.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace DrVendas.dddcore.Domain.Services
{
    public class ServiceProduto : IServiceProduto
    {

        private readonly IRepositoryProduto repoprodutos;

        public ServiceProduto(IRepositoryProduto _repoprodutos)
        {
            repoprodutos = _repoprodutos;
        }

        public Produto Adicionar(Produto produto)
        {
            repoprodutos.Adicionar(produto);
            return produto;
        }

        public Produto Atualizar(Produto produto)
        {
            repoprodutos.Atualizar(produto);
            return produto;
        }

        public Produto Remover(Produto produto)
        {
            repoprodutos.Remover(produto);
            return produto;
        }

        public IEnumerable<Produto> ObterTodos()
        {
            return repoprodutos.ObterTodos();
        }

        public Produto ObterPorId(int id)
        {
            return repoprodutos.ObterPorId(id);
        }

        public Produto ObterPorApelido(string apelido)
        {
            return repoprodutos.ObterPorApelido(apelido);
        }
        public Produto ObterPorNome(string nome)
        {
            return repoprodutos.ObterPorNome(nome);
        }

        public void Dispose()
        {
            repoprodutos.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
