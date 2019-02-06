using DrVendas.dddcore.Application.AppVendas.ViewModels.AgregracaoPedidos;
using System;
using System.Collections.Generic;

namespace DrVendas.dddcore.Application.AppVendas.Interfaces.AgregracaoPedidos
{
    public interface IApplicationPedido : IDisposable
    {
        PedidoViewModel Adicionar(PedidoViewModel pedido);
        PedidoViewModel Atualizar(PedidoViewModel pedido);
        PedidoViewModel Remover(PedidoViewModel pedido);
        IEnumerable<PedidoViewModel> ObterTodos();
        PedidoViewModel ObterPorId(int id);

    }
}
