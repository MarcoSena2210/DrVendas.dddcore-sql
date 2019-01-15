using DrVendas.dddcore.Domain.Entidades;
using System;
using System.Collections.Generic;

namespace DrVendas.dddcore.Domain.Interfaces.Services
{
    public interface IServiceFornecedor : IDisposable
    {
        Fornecedor Adicionar(Fornecedor fornecedor);
        Fornecedor Atualizar(Fornecedor fornecedor);
        Fornecedor Remover(Fornecedor fornecedor);
        IEnumerable<Fornecedor> ObterTodos();
        Fornecedor ObterPorId(int id);
        Fornecedor ObterPorCpfCnpj(string cpfcnpj);
        Fornecedor ObterPorApelido(string apelido);

    }
}
