using DrVendas.dddcore.Domain.Entidades;
using System;
using System.Collections.Generic;

namespace DrVendas.dddcore.Domain.Interfaces.Services
{
    public interface IServiceCliente : IDisposable
    {
        Cliente Adicionar(Cliente cliente);
        Cliente Atualizar(Cliente cliente);
        Cliente Remover(Cliente cliente);
        IEnumerable<Cliente> ObterTodos();
        Cliente ObterPorId(int id);
        Cliente ObterPorCpfCnpj(string cpfcnpj);
        Cliente ObterPorApelido(string apelido);
    }
}
