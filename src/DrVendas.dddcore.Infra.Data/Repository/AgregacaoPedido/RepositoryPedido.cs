using DrVendas.dddcore.Domain.Entidades;
using DrVendas.dddcore.Domain.Entidades.AgregacaoPedido;
using DrVendas.dddcore.Domain.Interfaces.Repository;
using DrVendas.dddcore.Domain.Interfaces.Repository.AgregacaoPedido;
using DrVendas.dddcore.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DrVendas.dddcore.Infra.Data.Repository.AgregacaoPedido
{
    public class RepositoryPedido : Repository<Pedido>, IRepositoryPedido
    {
        public RepositoryPedido(ContextEFSQLServer MeuContexto)
            : base(MeuContexto) 
        {

        }

        public void AdicionarItensPedidos(ItemPedido item)
        {
            Db.ItemPedido.Add(item);
        }


        public void AtulizarItensPedidos(ItemPedido item)
        {
            Db.ItemPedido.Update(item);
        }

        public void RemoverItensPedidos(ItemPedido item)
        {
            Db.ItemPedido.Remove(item);
        }

        public IEnumerable<ItemPedido> ObterItensPedido(int idpedido)
        {
            return Db.ItemPedido.Where(it => it.PedidoId == idpedido).OrderBy(it => it.Produto.Nome);
        }

        public ItemPedido ObterItensPedidosPorId(int id)
        {
            return Db.ItemPedido.AsNoTracking().FirstOrDefault(i => i.Id == id);
            
        }

    }
}
