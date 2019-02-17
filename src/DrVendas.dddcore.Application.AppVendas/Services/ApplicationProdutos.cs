using AutoMapper;
using DrVendas.dddcore.Application.AppVendas.Interfaces;
using DrVendas.dddcore.Application.AppVendas.ViewModels;
using DrVendas.dddcore.Domain.Entidades;
using DrVendas.dddcore.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace DrVendas.dddcore.Application.AppVendas.Services
{
    public class ApplicationProdutos : IApplicationProduto
    {   /*  injeção de dependências */
        private readonly IServiceProduto serviceProdutos;
        private readonly IMapper mapper;

        public ApplicationProdutos(IServiceProduto _serviceProdutos,
                                   IMapper _mapper )
        {
            serviceProdutos = _serviceProdutos;
            mapper = _mapper;
        }
        
        public ProdutoViewModel Adicionar(ProdutoViewModel produto)
        {
            return mapper.Map<ProdutoViewModel>(serviceProdutos.Adicionar(mapper.Map<Produto>(produto)));
        }

        public ProdutoViewModel Atualizar(ProdutoViewModel produto)
        {
            return mapper.Map<ProdutoViewModel>(serviceProdutos.Atualizar(mapper.Map<Produto>(produto)));
        }

        public ProdutoViewModel Remover(ProdutoViewModel produto)
        {
            return mapper.Map<ProdutoViewModel>(serviceProdutos.Remover(mapper.Map<Produto>(produto)));
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
