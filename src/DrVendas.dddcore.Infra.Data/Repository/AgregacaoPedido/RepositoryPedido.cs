using Dapper;
using DrVendas.dddcore.Domain.Entidades;
using DrVendas.dddcore.Domain.Entidades.AgregacaoPedido;
using DrVendas.dddcore.Domain.Interfaces.Repository.AgregacaoPedido;
using DrVendas.dddcore.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DrVendas.dddcore.Infra.Data.Repository.AgregacaoPedido
{
    public class RepositoryPedido : Repository<Pedido>, IRepositoryPedido
    {
        public RepositoryPedido(ContextEFSQLServer MeuContexto)
            : base(MeuContexto) 
        {

        }

        public void AdicionarItemPedido(ItemPedido item)
        {
            Db.ItemPedido.Add(item);
        }


        public void AtulizarItemPedido(ItemPedido item)
        {
            Db.ItemPedido.Update(item);
        }

        public void RemoverItemPedido(ItemPedido item)
        {
            Db.ItemPedido.Remove(item);
        }

        public override IEnumerable<Pedido> ObterTodos()
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine(@"SELECT * FROM pedido P
                               INNER JOIN cliente C ON p.ClienteId = C.Id 
                               ORDER BY p.Id DESC");
            var pedidos = Db.Database.GetDbConnection().Query<Pedido, Cliente, Pedido>(query.ToString(),
                (p, c) =>
                {
                    p.Cliente = c;
                    return p;
                });

            foreach (var item in pedidos)
            {
                var itens = ObterItemPedido(item.Id);
                item.QtdProdutos = itens.Count();
                item.ValorTotalPedido = itens.Sum(x => x.Produto.Valor);
            }

            return pedidos;
        }

        public override Pedido ObterPorId(int id)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine(@"SELECT * FROM pedido P
                               INNER JOIN cliente C ON p.ClienteId = C.Id 
                               WHERE P.ID=@uID");
            var pedidos = Db.Database.GetDbConnection().Query<Pedido, Cliente, Pedido>(query.ToString(),
                (p, c) =>
                {
                    p.Cliente = c;
                    return p;
                }, new { uID = id });

            return pedidos.FirstOrDefault();
        }

        public IEnumerable<ItemPedido> ObterItemPedido(int idpedido)
        {
            // return Db.ItensPedidos.Where(i => i.IdPedido == idpedido).OrderBy(i => i.Produto.Apelido);
            StringBuilder query = new StringBuilder();
            query.AppendLine(@"SELECT * FROM pedido P
                               INNER JOIN cliente C ON p.ClienteId = C.Id 
                               INNER JOIN itempedido IT ON P.ID = IT.PedidoId
                               INNER JOIN produto PD ON IT.ProdutoId = PD.ID
                               INNER JOIN fornecedor F ON PD.FornecedorId = F.ID
                               WHERE IT.PEDIDOID=@uIDPEDIDO");
            var itenspedidos = Db.Database.GetDbConnection().Query<Pedido, Cliente, ItemPedido, Produto, Fornecedor, ItemPedido>(query.ToString(),
                (p, c, it, pd, f) =>
                {
                    p.Cliente = c;
                    it.Pedido = p;
                    pd.Fornecedor = f;
                    it.Produto = pd;
                    return it;
                }, new { @uPEDIDOID = idpedido });
            return itenspedidos;
        }

        public ItemPedido ObterItemPedidoPorId(int id)
        {
            // return Db.ItensPedidos.AsNoTracking().FirstOrDefault(i => i.Id == id);
            StringBuilder query = new StringBuilder();
            query.AppendLine(@"SELECT * FROM pedido P
                               INNER JOIN cliente C ON p.ClienteId = C.Id 
                               INNER JOIN itempedido IT ON P.ID = IT.PedidoID
                               INNER JOIN produto PD ON IT.ProdutoId = PD.ID
                               INNER JOIN fornecedor F ON PD.FornecedorId = F.ID
                               WHERE IT.ID=@uID");
            var itenspedidos = Db.Database.GetDbConnection().Query<Pedido, Cliente, ItemPedido, Produto, Fornecedor, ItemPedido>(query.ToString(),
                (p, c, it, pd, f) =>
                {
                    p.Cliente = c;
                    it.Pedido = p;
                    pd.Fornecedor = f;
                    it.Produto = pd;
                    return it;
                }, new { uID = id });

            return itenspedidos.FirstOrDefault();

        }

        public IEnumerable<ItemPedido> ObterItemPedidoProdutoEspecifico(int idproduto)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine(@"SELECT * FROM itempedido WHERE PRODUTO.ID=@uIDPRODUTO");
            var itempedido = Db.Database.GetDbConnection().Query<ItemPedido>(query.ToString(), new { @uIDPRODUTO = idproduto });
            return itempedido;
        }

    }
}