using DrVendas.dddcore.Application.AppVendas.ViewModels;
using System;
using System.Collections.Generic;

namespace DrVendas.dddcore.Application.AppVendas.Interfaces
{
    public interface IApplicationCliente : IDisposable
    {
        ClienteViewModel Adicionar(ClienteViewModel cliente);
        ClienteViewModel Atualizar(ClienteViewModel cliente);
        ClienteViewModel Remover(ClienteViewModel cliente);
        IEnumerable<ClienteViewModel> ObterTodos();
        ClienteViewModel ObterPorId(int id);
        ClienteViewModel ObterPorCpfCnpj(string cpfcnpj);
        ClienteViewModel ObterPorApelido(string apelido);

    }
}
