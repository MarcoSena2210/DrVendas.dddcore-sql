using DrVendas.dddcore.Domain.Entidades.AgregacaoPedido;
using System;
using System.Collections.Generic;


namespace DrVendas.dddcore.Domain.Interfaces.Services.AgregacaoPedidos
{
    public interface IServicePedido : IDisposable
    {
        Pedido Adicionar(Pedido pedido);
        Pedido Atualizar(Pedido pedido);
        Pedido Remover(Pedido pedido);
        IEnumerable<Pedido> ObterTodos();
        Pedido ObterPorId(int id);
    }
}
