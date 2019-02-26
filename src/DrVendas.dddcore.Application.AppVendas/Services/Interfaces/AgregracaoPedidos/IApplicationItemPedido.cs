using DrVendas.dddcore.Application.AppVendas.ViewModels.AgregracaoPedidos;
using System;
using System.Collections.Generic;

namespace DrVendas.dddcore.Application.AppVendas.Interfaces.AgregracaoPedidos
{
    public interface IApplicationItemPedido : IDisposable
    {
        ItemPedidoViewModel AdicionarItensPedidos(ItemPedidoViewModel item);
        ItemPedidoViewModel AtulizarItensPedidos(ItemPedidoViewModel item);
        ItemPedidoViewModel RemoverItensPedidos(ItemPedidoViewModel item);
        ItemPedidoViewModel ObterItensPedidosPorId(int id);
        IEnumerable<ItemPedidoViewModel> ObterItensPedido(int idpedido);
        IEnumerable<ItemPedidoViewModel> ObterItensPedidoProdutoEspecifico(int idproduto);
    }
}
