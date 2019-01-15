using DrVendas.dddcore.Domain.Entidades.AgregacaoPedido;
using DrVendas.dddcore.Domain.Interfaces.Repository.AgregacaoPedido;
using System;
using System.Collections.Generic;


namespace DrVendas.dddcore.Domain.Interfaces.Services.AgregacaoPedidos
{
    public class ServicePedido : IServicePedido
    {
        protected readonly IRepositoryPedido repopedidos;

        public ServicePedido(IRepositoryPedido _repopedidos)
        {
            repopedidos = _repopedidos;
        }

        public Pedido Adicionar(Pedido pedido)
        {
            repopedidos.Adicionar(pedido);
            return pedido;
        }

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
