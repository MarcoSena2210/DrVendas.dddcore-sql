using DrVendas.dddcore.Domain.Entidades;
using DrVendas.dddcore.Domain.Interfaces.Repository;
using DrVendas.dddcore.Domain.Interfaces.Services;
using DrVendas.dddcore.Domain.Interfaces.Services.AgregacaoPedidos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DrVendas.dddcore.Domain.Services
{
    public class ServiceClientes : IServiceCliente
    {
        private readonly IRepositoryCliente repocliente;
        private readonly IServicePedido servicepedido;

        public ServiceClientes(IRepositoryCliente _repocliente,
                               IServicePedido _servicepedido)
        {
            repocliente = _repocliente;
            servicepedido = _servicepedido;
        }

        #region Adicionar cliente
        public Cliente Adicionar(Cliente cliente)
        {
            cliente = AptoParaAdicionarCliente(cliente);
            if (cliente.ListaErros.Any()) return cliente;
            repocliente.Adicionar(cliente);
            return cliente;
        }

        private Cliente AptoParaAdicionarCliente(Cliente cliente)
        {
            if (!cliente.EstaConsistente()) return cliente;
            cliente = VerificarSeApelidoExisteEmInclusao(cliente);
            cliente = VerificarSeCPFCNPJExisteEmInclusao(cliente);
            return cliente;
        }

        private Cliente VerificarSeApelidoExisteEmInclusao(Cliente cliente)
        {
            if (ObterPorApelido(cliente.Apelido) != null) cliente.ListaErros.Add("O Apelido " + cliente.Apelido + " já existe em outro cliente!");
            return cliente;
        }

        private Cliente VerificarSeCPFCNPJExisteEmInclusao(Cliente cliente)
        {
            if (ObterPorCpfCnpj(cliente.CPFCNPJ.Numero) != null) cliente.ListaErros.Add("O CPF ou CNPJ " + cliente.CPFCNPJ.Numero + " já existe em outro cliente!");
            return cliente;
        }


        #endregion Adcionar clientes

        #region Atualizar clientes
        public Cliente Atualizar(Cliente cliente)
        {
            cliente = AptoParaAlterarClientes(cliente);
            if (cliente.ListaErros.Any()) return cliente;
            repocliente.Atualizar(cliente);
            return cliente;
        }

        private Cliente AptoParaAlterarClientes(Cliente cliente)
        {
            if (!cliente.EstaConsistente()) return cliente;
            cliente = VerificarSeApelidoExisteEmAlteracao(cliente);
            cliente = VerificarSeCPFCNPJExisteEmAlteracao(cliente);
            return cliente;
        }


        private Cliente VerificarSeApelidoExisteEmAlteracao(Cliente cliente)
        {
            var result = ObterPorApelido(cliente.Apelido);
            if (result != null && result.Id != cliente.Id) cliente.ListaErros.Add("O Apelido " + cliente.Apelido + " já existe em outro cliente!");
            return cliente;
        }

        private Cliente VerificarSeCPFCNPJExisteEmAlteracao(Cliente cliente)
        {
            var result = ObterPorCpfCnpj(cliente.CPFCNPJ.Numero);
            if (result != null && result.Id != cliente.Id) cliente.ListaErros.Add("O CPF ou CNPJ " + cliente.CPFCNPJ.Numero + " já existe em outro cliente!");
            return cliente;
        }


        #endregion Atualizar clientes

        #region Remover clientes
        public Cliente Remover(Cliente cliente)
        {
            cliente = VerificarSeExistePedidoAssociadoAoCliente(cliente);
            if (cliente.ListaErros.Any()) return cliente;
            repocliente.Remover(cliente);
            return cliente;
        }

        private Cliente VerificarSeExistePedidoAssociadoAoCliente(Cliente cliente)
        {
            var result = servicepedido.ObterTodos().FirstOrDefault(p => p.ClienteId == cliente.Id);
            if (result != null) cliente.ListaErros.Add("Existe(m) pedido(s) associados a este Cliente, exclusão não permtida!");
            return cliente;
        }



        #endregion remover clientes

        #region Consulta clientes
        public IEnumerable<Cliente> ObterTodos()
        {
            return repocliente.ObterTodos();
        }

        public Cliente ObterPorId(int id)
        {
            return repocliente.ObterPorId(id);
        }

        public Cliente ObterPorApelido(string apelido)
        {
            return repocliente.ObterPorApelido(apelido);
        }

        public Cliente ObterPorCpfCnpj(string cpfcnpj)
        {
            return repocliente.ObterPorCpfCnpj(cpfcnpj);
        }

        #endregion Consulta clientes

        public void Dispose()
        {
            repocliente.Dispose();
            servicepedido.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}