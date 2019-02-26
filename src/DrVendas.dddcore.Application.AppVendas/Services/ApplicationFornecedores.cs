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
    public class ApplicationFornecedores : IApplicationFornecedor
    {

        private readonly IServiceFornecedor serviceFornecedores;
        private readonly IMapper mapper;
        private readonly IUnitOfWork uow;

        public ApplicationFornecedores(IServiceFornecedor   _serviceFornecedores,
                                    IMapper _mapper,
                                    IUnitOfWork  _uow)
         {
            serviceFornecedores = _serviceFornecedores;
            mapper = _mapper;
            uow = _uow;
        }
        #region Adicionar 
        public FornecedorViewModel Adicionar(FornecedorViewModel fornecedor)
        {
            var fornecedorresult = mapper.Map<FornecedorViewModel>(serviceFornecedores.Adicionar(mapper.Map<Fornecedor>(fornecedor)));
            uow.Commit(fornecedorresult.ListaErros);
            return mapper.Map<FornecedorViewModel>(fornecedorresult);
         }
        #endregion

        #region Atualizar 
        public FornecedorViewModel Atualizar(FornecedorViewModel fornecedor)
        {
            var fornecedorresult = mapper.Map<FornecedorViewModel>(serviceFornecedores.Atualizar(mapper.Map<Fornecedor>(fornecedor)));
            uow.Commit(fornecedorresult.ListaErros);
            return mapper.Map<FornecedorViewModel>(fornecedorresult);
        }
        #endregion

        #region Remover
        public FornecedorViewModel Remover(FornecedorViewModel fornecedor)
        {
            var fornecedorresult = mapper.Map<FornecedorViewModel>(serviceFornecedores.Remover(mapper.Map<Fornecedor>(fornecedor)));
            uow.Commit(fornecedorresult.ListaErros);
            return mapper.Map<FornecedorViewModel>(fornecedorresult);
        }
        #endregion

        #region Consultas
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

        #endregion

        public void Dispose()
        {
            serviceFornecedores.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
