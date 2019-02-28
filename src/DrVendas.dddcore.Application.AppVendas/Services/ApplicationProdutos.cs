using AutoMapper;
using DrVendas.dddcore.Application.AppVendas.Interfaces;
using DrVendas.dddcore.Application.AppVendas.ViewModels;
using DrVendas.dddcore.Domain.Entidades;
using DrVendas.dddcore.Domain.Interfaces.Services;
using DrVendas.dddcore.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;

namespace DrVendas.dddcore.Application.AppVendas.Services
{
    public class ApplicationProdutos : IApplicationProduto
    {   /*  injeção de dependências */
        private readonly IServiceProduto serviceProdutos;
        private readonly IMapper mapper;
        private readonly IUnitOfWork uow;

        public ApplicationProdutos(IServiceProduto _serviceProdutos,
                                   IMapper _mapper,
                                   IUnitOfWork _uow)
        {
            serviceProdutos = _serviceProdutos;
            mapper = _mapper;
            uow = _uow;
        }

        public ProdutoViewModel Adicionar(ProdutoViewModel produto)
        {
            var produtoresult = mapper.Map<ProdutoViewModel>(serviceProdutos.Adicionar(mapper.Map<Produto>(produto)));
            uow.Commit(produtoresult.ListaErros);
            return mapper.Map<ProdutoViewModel>(produtoresult);
        }

        public ProdutoViewModel Atualizar(ProdutoViewModel produto)
        {
            var produtoresult = mapper.Map<ProdutoViewModel>(serviceProdutos.Atualizar(mapper.Map<Produto>(produto)));
            uow.Commit(produtoresult.ListaErros);
            return mapper.Map<ProdutoViewModel>(produtoresult);
        }

        public ProdutoViewModel Remover(ProdutoViewModel produto)
        {
            var produtoresult = mapper.Map<ProdutoViewModel>(serviceProdutos.Remover(mapper.Map<Produto>(produto)));
            uow.Commit(produtoresult.ListaErros);
            return mapper.Map<ProdutoViewModel>(produtoresult);
        }

        public IEnumerable<ProdutoViewModel> ObterTodos()
        {
            return mapper.Map<IEnumerable<ProdutoViewModel>>(serviceProdutos.ObterTodos());
        }

        public ProdutoViewModel ObterPorId(int id)
        {
            return mapper.Map<ProdutoViewModel>(serviceProdutos.ObterPorId(id));
        }

        public ProdutoViewModel ObterPorApelido(string apelido)
        {
            return mapper.Map<ProdutoViewModel>(serviceProdutos.ObterPorApelido(apelido));
        }

        public ProdutoViewModel ObterPorNome(string nome)
        {
            return mapper.Map<ProdutoViewModel>(serviceProdutos.ObterPorNome(nome));
        }

        public void Dispose()
        {
            serviceProdutos.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
