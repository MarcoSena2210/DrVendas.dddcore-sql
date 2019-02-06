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
            if (!pedido.EstaConsistente()) return pedido; //nao passou na 1 regra
            pedido = VerificarSeExistePedidoAbertoDoClienteNaDataInclusao(pedido);
            pedido = VerificarSeExisteItemDePedidoNaInclusao(pedido);
            pedido = VerificarSeItemPedidoDaInclusaoEhConsistente(pedido);
            return pedido;
        }

      

        
       

        #endregion Adicionar Pedidos

        #region Atualizar Pedidos
        public Pedido Atualizar(Pedido pedido)
        {
            pedido = AptoParaAtualizarPedido(pedido);
            if (pedido.ListaErros.Any()) return pedido;

            repopedidos.Atualizar(pedido);
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

        private Pedido AptoParaAtualizarPedido(Pedido pedido) {
            if (!pedido.EstaConsistente()) return pedido;
            pedido = VerificarSeExisteItemDePedidoNaInclusao(pedido);
            pedido = pedido.VerificarSePedidoJaFoiEntregue(pedido);
            return pedido;
            
        }

        #endregion Atualizar Pedidos

        #region Remover Pedidos
        public Pedido Remover(Pedido pedido)
        {
            pedido = pedido.VerificarSePedidoJaFoiEntregue(pedido);
            if (pedido.ListaErros.Any()) return pedido;

            repopedidos.Remover(pedido);
            return pedido;
        }
        #endregion Remover Pedidos

        #region Consultar Pedidos
        public IEnumerable<Pedido> ObterTodos()
        {
            return repopedidos.ObterTodos();
        }


        public Pedido ObterPorId(int id)
        {
            return repopedidos.ObterPorId(id);
        }
        #endregion Consultar Pedidos 

        public void Dispose()
        {
            repopedidos.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
