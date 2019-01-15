﻿using DrVendas.dddcore.Domain.Entidades.AgregacaoPedido;
using System;
using System.Collections.Generic;

namespace DrVendas.dddcore.Domain.Interfaces.Services.AgregacaoPedidos
{
    public interface IServiceItemPedido : IDisposable
    {
        ItemPedido AdicionarItemPedido(ItemPedido item);
        ItemPedido AtulizarItemPedido(ItemPedido item);
        ItemPedido RemoverItemPedido(ItemPedido item);
        ItemPedido ObterItemPedidoPorId(int id);
        IEnumerable<ItemPedido> ObterItemPedido(int idpedido);
    }
}
