using AutoMapper;
using DrVendas.dddcore.Application.AppVendas.Interfaces.AgregracaoPedidos;
using DrVendas.dddcore.Application.AppVendas.ViewModels.AgregracaoPedidos;
using DrVendas.dddcore.Domain.Entidades.AgregacaoPedido;
using DrVendas.dddcore.Domain.Interfaces.Services.AgregacaoPedidos;
using System;
using System.Collections.Generic;

namespace DrVendas.dddcore.Application.AppVendas.Services.AgregacaoPedidos
{
    public class ApplicationItensPedidos : IApplicationItemPedido
    {
        private readonly IServiceItemPedido serviceitenspedidos;
        private readonly IMapper mapper;

        public ApplicationItensPedidos(IServiceItemPedido _serviceitenspedidos,
                                       IMapper _mapper)
        {
            serviceitenspedidos = _serviceitenspedidos;
            mapper = _mapper;
        }

        public ItemPedidoViewModel AdicionarItensPedidos(ItemPedidoViewModel item)
        {
            return mapper.Map<ItemPedidoViewModel>(serviceitenspedidos.AdicionarItemPedido(mapper.Map<ItemPedido>(item)));
        }

        public ItemPedidoViewModel AtulizarItensPedidos(ItemPedidoViewModel item)
        {
            return mapper.Map<ItemPedidoViewModel>(serviceitenspedidos.AtualizarItemPedido(mapper.Map<ItemPedido>(item)));
        }

        public ItemPedidoViewModel RemoverItensPedidos(ItemPedidoViewModel item)
        {
            return mapper.Map<ItemPedidoViewModel>(serviceitenspedidos.RemoverItemPedido(mapper.Map<ItemPedido>(item)));
        }

        public IEnumerable<ItemPedidoViewModel> ObterItensPedido(int idpedido)
        {
            return mapper.Map<IEnumerable<ItemPedidoViewModel>>(serviceitenspedidos.ObterItemPedido(idpedido));
        }

        public ItemPedidoViewModel ObterItensPedidosPorId(int id)
        {
            return mapper.Map<ItemPedidoViewModel>(serviceitenspedidos.ObterItemPedidoPorId(id));
        }

        public IEnumerable<ItemPedidoViewModel> ObterItensPedidoProdutoEspecifico(int idproduto)
        {
            return mapper.Map<IEnumerable<ItemPedidoViewModel>>(serviceitenspedidos.ObterItemPedidoProdutoEspecifico(idproduto));
        }

        public void Dispose()
        {
            serviceitenspedidos.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
