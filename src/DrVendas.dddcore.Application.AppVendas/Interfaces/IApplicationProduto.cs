using DrVendas.dddcore.Application.AppVendas.ViewModels;
using System;
using System.Collections.Generic;

namespace DrVendas.dddcore.Application.AppVendas.Interfaces
{
    public interface IApplicationProduto : IDisposable
    {
        ProdutoViewModel Adicionar(ProdutoViewModel produto);
        ProdutoViewModel Atualizar(ProdutoViewModel produto);
        ProdutoViewModel Remover(ProdutoViewModel produto);
        IEnumerable<ProdutoViewModel> ObterTodos();
        ProdutoViewModel ObterPorId(int id);
        ProdutoViewModel ObterPorNome(string nome);
        ProdutoViewModel ObterPorApelido(string apelido);

    }
}
