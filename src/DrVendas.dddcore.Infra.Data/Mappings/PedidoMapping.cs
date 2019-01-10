using DrVendas.dddcore.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrVendas.dddcore.Infra.Data.Mappings
{
    public class PedidoMapping : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.DataPedido)
                .HasColumnType("DateTime")
                .IsRequired();

            builder.Property(p => p.DataEntrega)
                .HasColumnType("DateTime");

            builder.HasOne(p => p.Cliente)
                .WithMany(c => c.Pedidos)
                .HasForeignKey(p => p.ClienteId);

            builder.Ignore(p => p.ListaErros);

            builder.ToTable("Pedido");

        }
    }
}
