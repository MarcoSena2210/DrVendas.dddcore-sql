using DrVendas.dddcore.Domain.Entidades.AgregacaoPedido;
using DrVendas.dddcore.Domain.Interfaces.Repository.AgregacaoPedido;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DrVendas.dddcore.Domain.Interfaces.Services.AgregacaoPedidos
{
    public class ServicePedido : IServicePedido
    {
        protected readonly IRepositoryPedido repopedidos;

        public ServicePedido(IRepositoryPedido _repopedidos)
        {
            repopedidos = _repopedidos;
        }
        #region Adicionar Pedidos

        public Pedido Adicionar(Pedido pedido)
        {
            pedido = AptoParaAdicionarPedidos(pedido);
            if (pedido.ListaErros.Any()) return pedido;
            repopedidos.Adicionar(pedido);
            return pedido;
        }
        private Pedido AptoParaAdicionarPedidos(Pedido pedido)
        {
            if (!pedido.EstaConsistente()) return pedido;
            pedido = VerificarSeExistePedidoAbertoDoClienteNaDataInclusao(pedido);
            pedido = VerificarSeExisteItemDePedidoNaInclusao(pedido);
            pedido = VerificarSeItemPedidoDaInclusaoEhConsistente(pedido);
            return pedido;
        }

        private Pedido VerificarSeExistePedidoAbertoDoClienteNaDataInclusao(Pedido pedido)
        {
            var wPedidos = ObterTodos().FirstOrDefault(x => x.ClienteId == pedido.ClienteId && x.DataEntrega == null && x.DataPedido == pedido.DataPedido);
            if (wPedidos != null) pedido.ListaErros.Add("Existe(m) pedido(s) abertos deste cliente nesta data " + pedido.DataPedido.ToString("dd/MM/yyyy") + "!");
            return pedido;
        }

        private Pedido VerificarSeExisteItemDePedidoNaInclusao(Pedido pedido)
        {
            if (pedido.ItensPedidos.Count() != 1) pedido.ListaErros.Add("Na inclusão do pedido é preciso informar somente um item!");
            return pedido;
        }

        private Pedido VerificarSeItemPedidoDaInclusaoEhConsistente(Pedido pedido)
        {
            if (pedido.ItensPedidos.Count() == 1)
            {
                var item = pedido.ItensPedidos.ToList()[0];
                if (!item.EstaConsistente(true))
                {
                    foreach (var erros in item.ListaErros)
                    {
                        pedido.ListaErros.Add(erros);
                    }
                }
            }
            return pedido;
        }

        #endregion Adicionar Pedidos

        public Pedido Atualizar(Pedido pedido)
        {
            repopedidos.Atualizar(pedido);
            return pedido;

        }

        public Pedido Remover(Pedido pedido)
        {
            repopedidos.Remover(pedido);
            return pedido;
        }

        public IEnumerable<Pedido> ObterTodos()
        {
            return repopedidos.ObterTodos();
        }


        public Pedido ObterPorId(int id)
        {
            return repopedidos.ObterPorId(id);
        }
        public void Dispose()
        {
            repopedidos.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
