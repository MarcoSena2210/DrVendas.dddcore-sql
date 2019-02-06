using AutoMapper;
using DrVendas.dddcore.Application.AppVendas.Interfaces;
using DrVendas.dddcore.Application.AppVendas.ViewModels;
using DrVendas.dddcore.Domain.Entidades;
using DrVendas.dddcore.Domain.Interfaces.Services;
using DrVendas.dddcore.Infra.CrossCutting.Extensions;
using System;
using System.Collections.Generic;

namespace Projeto.Curso.Core.Application.Pedido.Services
{
    public class ApplicationFornecedores : IApplicationFornecedor
    {

        private readonly IServiceFornecedor serviceFornecedores;
        private readonly IMapper mapper;

        public ApplicationFornecedores(IServiceFornecedor _serviceFornecedores,
                                       IMapper _mapper )
        {
            serviceFornecedores = _serviceFornecedores;
            mapper = _mapper;
        }

        public FornecedorViewModel Adicionar(FornecedorViewModel fornecedor)
        {
            return mapper.Map<FornecedorViewModel>(serviceFornecedores.Adicionar(mapper.Map<Fornecedor>(fornecedor)));
        }

        public FornecedorViewModel Atualizar(FornecedorViewModel fornecedor)
        {
            return mapper.Map<FornecedorViewModel>(serviceFornecedores.Atualizar(mapper.Map<Fornecedor>(fornecedor)));
        }

        public FornecedorViewModel Remover(FornecedorViewModel fornecedor)
        {
            return mapper.Map<FornecedorViewModel>(serviceFornecedores.Remover(mapper.Map<Fornecedor>(fornecedor)));
        }

        public IEnumerable<FornecedorViewModel> ObterTodos()
        {
            return mapper.Map<IEnumerable<FornecedorViewModel>>(serviceFornecedores.ObterTodos());
        }


        public FornecedorViewModel ObterPorId(int id)
        {
            return mapper.Map<FornecedorViewModel>(serviceFornecedores.ObterPorId(id));
        }

        public FornecedorViewModel ObterPorApelido(string apelido)
        {
            return mapper.Map<FornecedorViewModel>(serviceFornecedores.ObterPorApelido(apelido));
        }

        public FornecedorViewModel ObterPorCpfCnpj(string cpfcnpj)
        {
            return mapper.Map<FornecedorViewModel>(serviceFornecedores.ObterPorCpfCnpj(cpfcnpj.SomenteNumeros()));
        }

        public void Dispose()
        {
            serviceFornecedores.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
