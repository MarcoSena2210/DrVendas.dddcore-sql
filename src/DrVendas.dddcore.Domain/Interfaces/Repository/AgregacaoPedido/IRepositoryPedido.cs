﻿using DrVendas.dddcore.Domain.DTO;
using DrVendas.dddcore.Domain.Entidades.AgregacaoPedido;
using System.Collections.Generic;

namespace DrVendas.dddcore.Domain.Interfaces.Repository.AgregacaoPedido
{
    public interface IRepositoryPedido : IRepository<Pedido>
    {
        void AdicionarItemPedido(ItemPedido item);
        void AtulizarItemPedido(ItemPedido item);
        void RemoverItemPedido(ItemPedido item);
        ItemPedido ObterItemPedidoPorId(int id);
        IEnumerable<ItemPedido> ObterItemPedido(int idpedido);
        IEnumerable<ItemPedido> ObterItemPedidoProdutoEspecifico(int idproduto);

        PedidoDTO ObterPorIdCompleto(int id);
        IEnumerable<PedidoDTO> ObterListagemPedidos();

    }
}
