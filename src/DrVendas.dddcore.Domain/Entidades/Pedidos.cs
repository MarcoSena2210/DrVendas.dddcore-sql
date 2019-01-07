using DrVendas.dddcore.Domain.Shared.Entidades;
using System;

namespace DrVendas.dddcore.Domain.Entidades
{
    public class Pedidos : EntidadeBase
    {
     
        public string Apelido { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public DateTime DataEntrega { get; set; }
        public int Status { get; set; }
        public int IdCliente { get; set; }

        public override bool EstaConsistente()
        {
            throw new NotImplementedException();
        }
    }
}
