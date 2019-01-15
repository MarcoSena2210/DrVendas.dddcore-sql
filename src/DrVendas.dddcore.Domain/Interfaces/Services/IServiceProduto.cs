using DrVendas.dddcore.Domain.Entidades;
using System;
using System.Collections.Generic;

namespace DrVendas.dddcore.Domain.Interfaces.Services
{
    public interface IServiceProduto : IDisposable
    {
        Produto Adicionar(Produto produto);
        Produto Atualizar(Produto produto);
        Produto Remover(Produto produto);
        IEnumerable<Produto> ObterTodos();
        Produto ObterPorId(int id);
        Produto ObterPorNome(string nome);
        Produto ObterPorApelido(string apelido);
    }
}
