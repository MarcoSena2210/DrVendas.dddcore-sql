using AutoMapper;
using DrVendas.dddcore.Application.AppVendas.Interfaces;
using DrVendas.dddcore.Application.AppVendas.ViewModels;
using DrVendas.dddcore.Domain.Entidades;
using DrVendas.dddcore.Domain.Interfaces.Services;
using DrVendas.dddcore.Infra.CrossCutting.Extensions;
using DrVendas.dddcore.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;

namespace DrVendas.dddcore.Application.AppVendas.Services
{ 
    public class ApplicationClientes : IApplicationCliente
    {
        private readonly IServiceCliente serviceclientes;
        private readonly IMapper mapper;
        private readonly IUnitOfWork uow;

        public ApplicationClientes(IServiceCliente _serviceclientes,
                                   IMapper _mapper,
                                    IUnitOfWork _uow)
        {
            serviceclientes = _serviceclientes;
            mapper = _mapper;
            uow = _uow;
        }

        public ClienteViewModel Adicionar(ClienteViewModel cliente)
        {
            var clienteresult = mapper.Map<ClienteViewModel>(serviceclientes.Adicionar(mapper.Map<Cliente>(cliente)));
            uow.Commit(clienteresult.ListaErros);
            return mapper.Map<ClienteViewModel>(clienteresult);
        }

        public ClienteViewModel Atualizar(ClienteViewModel cliente)
        {
            var clienteresult = mapper.Map<ClienteViewModel>(serviceclientes.Atualizar(mapper.Map<Cliente>(cliente)));
            uow.Commit(clienteresult.ListaErros);
            return mapper.Map<ClienteViewModel>(clienteresult);
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
