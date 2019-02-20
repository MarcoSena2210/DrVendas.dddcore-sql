using AutoMapper;
using DrVendas.dddcore.Application.AppVendas.Interfaces.AgregracaoPedidos;
using DrVendas.dddcore.Application.AppVendas.ViewModels.AgregracaoPedidos;
using DrVendas.dddcore.Domain.Entidades.AgregacaoPedido;
using DrVendas.dddcore.Domain.Interfaces.Services.AgregacaoPedidos;
using System;
using System.Collections.Generic;

namespace DrVendas.dddcore.Application.AppVendas.Services.AgregacaoPedidos
{
    public class ApplicationPedidos : IApplicationPedido
    {
        private readonly IServicePedido servicepedidos;
        private readonly IMapper mapper;

        public ApplicationPedidos(IServicePedido _servicepedidos,
                                  IMapper _mapper)
        {
            servicepedidos = _servicepedidos;
            mapper = _mapper;
        }


        public PedidoViewModel Adicionar(PedidoViewModel pedido)
        {
            return mapper.Map<PedidoViewModel>(servicepedidos.Adicionar(mapper.Map<Pedido>(pedido)));
        }

        public PedidoViewModel Atualizar(PedidoViewModel pedido)
        {
            return mapper.Map<PedidoViewModel>(servicepedidos.Atualizar(mapper.Map<Pedido>(pedido)));
        }

        public PedidoViewModel Remover(PedidoViewModel pedido)
        {
            return mapper.Map<PedidoViewModel>(servicepedidos.Remover(mapper.Map<Pedido>(pedido)));
        }


        public IEnumerable<PedidoViewModel> ObterTodos()
        {
            return mapper.Map<IEnumerable<PedidoViewModel>>(servicepedidos.ObterTodos());
        }

        public PedidoViewModel ObterPorId(int id)
        {
            return mapper.Map<PedidoViewModel>(servicepedidos.ObterPorId(id));
        }

        //Precisamos configurar o auto mapper, só vai ter de dominio para viewmodel
        public PedidoViewModel ObterPorIdCompleto(int id)
        {
            return mapper.Map<PedidoViewModel>(servicepedidos.ObterPorIdCompleto(id));
         }

        public IEnumerable<PedidoViewModel> ObterListagemPedidos()
        {
            return mapper.Map<IEnumerable<PedidoViewModel>>(servicepedidos.ObterListagemPedidos());
        }

        public void Dispose()
        {
            servicepedidos.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
