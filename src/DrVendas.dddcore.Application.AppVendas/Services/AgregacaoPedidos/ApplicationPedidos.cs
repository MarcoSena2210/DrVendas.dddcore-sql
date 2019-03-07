using AutoMapper;
using DrVendas.dddcore.Application.AppVendas.Interfaces.AgregracaoPedidos;
using DrVendas.dddcore.Application.AppVendas.ViewModels.AgregracaoPedidos;
using DrVendas.dddcore.Domain.Entidades.AgregacaoPedido;
using DrVendas.dddcore.Domain.Interfaces.Services.AgregacaoPedidos;
using DrVendas.dddcore.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;

namespace DrVendas.dddcore.Application.AppVendas.Services.AgregacaoPedidos
{
    public class ApplicationPedidos : IApplicationPedido
    {
        private readonly IServicePedido servicepedidos;
        private readonly IMapper mapper;
        private readonly IUnitOfWork uow;

        public ApplicationPedidos(IServicePedido _servicepedidos,
                                  IMapper _mapper, IUnitOfWork _uow)
        {
            servicepedidos = _servicepedidos;
            mapper = _mapper;
            uow = _uow;
        }


        public PedidoViewModel Adicionar(PedidoViewModel pedido)
        {
            var pedidoresult = mapper.Map<Pedido>(pedido);

            List<ItemPedido> ListaItem = new List<ItemPedido>();
            ItemPedido item = new ItemPedido();
        //    item.Qtd = Convert.ToInt32(pedido.Qtd);  //Acho que falta criar esse campos
            item.ProdutoId = pedido.ProdutoId;

            ListaItem.Add(item);
            pedidoresult.ItensPedidos = ListaItem;
            pedido = mapper.Map<PedidoViewModel>(servicepedidos.Adicionar(pedidoresult));
            uow.Commit(pedido.ListaErros);

            return pedido;
        //    return mapper.Map<PedidoViewModel>(servicepedidos.Adicionar(mapper.Map<Pedido>(pedido)));
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
