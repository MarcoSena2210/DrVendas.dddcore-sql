using DrVendas.dddcore.Domain.Entidades.AgregacaoPedido;
using DrVendas.dddcore.Domain.Interfaces.Repository.AgregacaoPedido;
using System;
using System.Collections.Generic;


namespace DrVendas.dddcore.Domain.Interfaces.Services.AgregacaoPedidos
{
    public class ServiceItemPedido : IServiceItemPedido
    {
        private readonly IRepositoryPedido repopedidos;

        public ServiceItemPedido(IRepositoryPedido _repopedidos)
        {
            repopedidos = _repopedidos;
        }

        public ItemPedido AdicionarItemPedido(ItemPedido item)
        {
            repopedidos.AdicionarItemPedido(item);
            return item;
        }

        public ItemPedido AtulizarItemPedido(ItemPedido item)
        {
            repopedidos.AtulizarItemPedido(item);
            return item;
        }

        public ItemPedido RemoverItemPedido(ItemPedido item)
        {
            repopedidos.RemoverItemPedido(item);
            return item;
        }



        public IEnumerable<ItemPedido> ObterItemPedido(int idpedido)
        {
            return repopedidos.ObterItemPedido(idpedido);
        }


        public ItemPedido ObterItemPedidoPorId(int id)
        {
            return ObterItemPedidoPorId(id);
        }

        public void Dispose()
        {
            repopedidos.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
