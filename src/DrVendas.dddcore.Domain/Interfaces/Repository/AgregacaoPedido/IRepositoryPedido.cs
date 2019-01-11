using DrVendas.dddcore.Domain.Entidades.AgregacaoPedido;
using System.Collections.Generic;

namespace DrVendas.dddcore.Domain.Interfaces.Repository.AgregacaoPedido
{
    public interface IRepositoryPedido : IRepository<Pedido>
    {
        void AdicionarItensPedidos(ItemPedido item);
        void AtulizarItensPedidos(ItemPedido item);
        void RemoverItensPedidos(ItemPedido item);
        ItemPedido ObterItensPedidosPorId(int id);
        IEnumerable<ItemPedido> ObterItensPedido(int idpedido);

    }
}
