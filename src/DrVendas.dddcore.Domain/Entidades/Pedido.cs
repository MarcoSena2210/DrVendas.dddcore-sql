using DrVendas.dddcore.Domain.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DrVendas.dddcore.Domain.Entidades
{
    public class Pedido : EntidadeBase
    {
        public DateTime DataPedido { get; set; }
        public DateTime? DataEntrega { get; set; }
        public int ClienteId { get; set; }
        public string Observacao { get; set; }
        public decimal ValorTotalPedido { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<ItemPedido> ItensPedidos { get; set; }


        public override bool EstaConsistente()
        {
            DataPedidoDeveSerPreenchida();
            DataPedidoDeveSerSuperiorOuIgualADataDoDia();
            DataEntregaDeveSerSuperiorOuIgualDataPedido();
            ObservacaoDeveTerUmTamanhoLimite();
            ValorTotalPedidoDeverSerSuperiorAZero();
            ClienteDeveSerPreenchido();
            return !ListaErros.Any();
        }

        private void DataPedidoDeveSerPreenchida()
        {
            if (DataPedido == null) ListaErros.Add("Preencha data do pedido!");
        }

        private void DataPedidoDeveSerSuperiorOuIgualADataDoDia()
        {
            if (DataPedido < DateTime.Today) ListaErros.Add("Data do pedido não pode ser superior a data de hoje!");
        }

        private void DataEntregaDeveSerSuperiorOuIgualDataPedido()
        {
            if (DataEntrega != null && DataEntrega < DataPedido) ListaErros.Add("Data da entrega deve ser superior a data do pedido");
        }

        private void ObservacaoDeveTerUmTamanhoLimite()
        {
            if (!string.IsNullOrEmpty(Observacao) && Observacao.Length > 4000) ListaErros.Add("Campo observação deverá ter no máximo 4000 caracteres!");
        }



        private void ValorTotalPedidoDeverSerSuperiorAZero()
        {
            if (ValorTotalPedido <= 0) ListaErros.Add("O campo valor  total do pedido deve ser maior que zero!");
        }



        private void ClienteDeveSerPreenchido()
        {
            if (ClienteId == 0) ListaErros.Add("Cliente deve ser informado!");
        }



    }
}