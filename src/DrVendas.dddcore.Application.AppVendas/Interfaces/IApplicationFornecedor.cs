using DrVendas.dddcore.Application.AppVendas.ViewModels;
using System;
using System.Collections.Generic;

namespace DrVendas.dddcore.Application.AppVendas.Interfaces
{
    public interface IApplicationFornecedor : IDisposable
    {
        FornecedorViewModel Adicionar(FornecedorViewModel fornecedor);
        FornecedorViewModel Atualizar(FornecedorViewModel fornecedor);
        FornecedorViewModel Remover(FornecedorViewModel fornecedor);
        IEnumerable<FornecedorViewModel> ObterTodos();
        FornecedorViewModel ObterPorId(int id);
        FornecedorViewModel ObterPorCpfCnpj(string cpfcnpj);
        FornecedorViewModel ObterPorApelido(string apelido);

    }
}
