using DrVendas.dddcore.Domain.Entidades.AgregacaoPedido;
using DrVendas.dddcore.Domain.Interfaces.Repository.AgregacaoPedido;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DrVendas.dddcore.Domain.Interfaces.Services.AgregacaoPedidos
{
    public class ServiceItemPedido : IServiceItemPedido
    {
        
        private readonly IRepositoryPedido repopedidos;

        public ServiceItemPedido(IRepositoryPedido _repopedidos)
        {
            repopedidos = _repopedidos;
        }

        #region Adicionar itens
        public ItemPedido AdicionarItemPedido(ItemPedido item)
        {
            item = AptoParaAdicionarItens(item);
            if (item.ListaErros.Any()) return item;
            repopedidos.AdicionarItemPedido(item);
            return item;
        }

        private ItemPedido AptoParaAdicionarItens(ItemPedido item)
        {
            if (!item.EstaConsistente()) return item;
            item = VerificarSeProdutoJaExisteNoPedidoInclusao(item);
            return item;
        }


        private ItemPedido VerificarSeProdutoJaExisteNoPedidoInclusao(ItemPedido item)
        {
            var itens = ObterItemPedidoProdutoEspecifico(item.ProdutoId).FirstOrDefault(x => x.PedidoId == item.PedidoId);
            if (itens != null) item.ListaErros.Add("Este produto já existe neste pedido!");
            return item;
        }


        #endregion adcionar itens

        #region Atualizar itens
        public ItemPedido AtualizarItemPedido(ItemPedido item)
        {
            item = AptoParaAtualizarItem(item);
            if (item.ListaErros.Any()) return item;
            repopedidos.AtulizarItemPedido(item);
            return item;
        }

        private ItemPedido AptoParaAtualizarItem(ItemPedido item)
        {
            if (!item.EstaConsistente()) return item;
            item = VerificarSeProdutoJaExisteNoPedidoAlteracao(item);
            return item;
        }

        private ItemPedido VerificarSeProdutoJaExisteNoPedidoAlteracao(ItemPedido item)
        {
            var itens = ObterItemPedidoProdutoEspecifico(item.ProdutoId).FirstOrDefault(x => x.PedidoId == item.PedidoId && x.Id != item.Id);
            if (itens != null) item.ListaErros.Add("Este produto já existe neste pedido!");
            return item;
        }


        #endregion atualizar itens

        #region Remover itens
        public ItemPedido RemoverItemPedido(ItemPedido item)
        {
            var pedido = new Pedido();
            //  ??????????????????????   verificar onde esta essa implementação
            ///////////pedido = pedido.VerificarSePedidoJaFoiEntregue(item.Pedido);

            if (!pedido.ListaErros.Any())
            {
                var itens = ObterItemPedido(item.PedidoId).ToList();
                if (itens.Count() > 1)
                {
                    repopedidos.RemoverItemPedido(item);
                }
                else
                {
                    pedido = repopedidos.ObterPorId(item.PedidoId);
                    repopedidos.Remover(pedido);
                }
            }
            else
            {
                item.ListaErros.Add(pedido.ListaErros[0]);
            }
            return item;
        }

        #endregion remover itens

        #region Consultar itens

        public IEnumerable<ItemPedido> ObterItemPedido(int idpedido)
        {
            return repopedidos.ObterItemPedido(idpedido);
        }


        public ItemPedido ObterItemPedidoPorId(int id)
        {
            return repopedidos.ObterItemPedidoPorId(id);
        }
        public IEnumerable<ItemPedido> ObterItemPedidoProdutoEspecifico(int idproduto)
        {
            return repopedidos.ObterItemPedidoProdutoEspecifico(idproduto);
        }

        #endregion consultar itens

        public void Dispose()
        {
            repopedidos.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}

   