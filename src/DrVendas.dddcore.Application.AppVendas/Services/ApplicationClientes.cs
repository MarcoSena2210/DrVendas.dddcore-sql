using AutoMapper;
using DrVendas.dddcore.Application.AppVendas.Interfaces;
using DrVendas.dddcore.Application.AppVendas.ViewModels;
using DrVendas.dddcore.Domain.Entidades;
using DrVendas.dddcore.Domain.Interfaces.Services;
using DrVendas.dddcore.Infra.CrossCutting.Extensions;
using System;
using System.Collections.Generic;

namespace DrVendas.dddcore.Application.AppVendas.Services
{ 
    public class ApplicationClientes : IApplicationCliente
    {
        private readonly IServiceCliente serviceclientes;
        private readonly IMapper mapper;

        public ApplicationClientes(IServiceCliente _serviceclientes,
                                   IMapper _mapper)
        {
            serviceclientes = _serviceclientes;
            mapper = _mapper;
        }

        public ClienteViewModel Adicionar(ClienteViewModel cliente)
        {
            return mapper.Map<ClienteViewModel>(serviceclientes.Adicionar(mapper.Map<Cliente>(cliente)));
        }

        public ClienteViewModel Atualizar(ClienteViewModel cliente)
        {
            return mapper.Map<ClienteViewModel>(serviceclientes.Atualizar(mapper.Map<Cliente>(cliente)));
        }

        public ClienteViewModel Remover(ClienteViewModel cliente)
        {
            return mapper.Map<ClienteViewModel>(serviceclientes.Remover(mapper.Map<Cliente>(cliente)));
        }


        public IEnumerable<ClienteViewModel> ObterTodos()
        {
            return mapper.Map<IEnumerable<ClienteViewModel>>(serviceclientes.ObterTodos());
        }

        public ClienteViewModel ObterPorId(int id)
        {
            return mapper.Map<ClienteViewModel>(serviceclientes.ObterPorId(id));
        }

        public ClienteViewModel ObterPorApelido(string apelido)
        {
            return mapper.Map<ClienteViewModel>(serviceclientes.ObterPorApelido(apelido));
        }

        public ClienteViewModel ObterPorCpfCnpj(string cpfcnpj)
        {
            return mapper.Map<ClienteViewModel>(serviceclientes.ObterPorCpfCnpj(cpfcnpj.SomenteNumeros()));
        }

        public void Dispose()
        {
            serviceclientes.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
