using DrVendas.dddcore.Domain.Entidades;
using DrVendas.dddcore.Domain.Entidades.AgregacaoPedido;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrVendas.dddcore.Infra.Data.Mappings
{
    public class ItemPedidoMapping : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(p => p.ValorItem)
               .HasColumnType("decimal")
               .IsRequired();

            builder.Property(p => p.ValorTotalItem)
             .HasColumnType("decimal")
             .IsRequired();

            builder.HasOne(i => i.Pedido)
                 .WithMany(p => p.ItensPedidos)
                 .HasForeignKey(i => i.PedidoId);

            builder.HasOne(i => i.Produto)
                .WithMany(p => p.ItensPedidos)
                .HasForeignKey(i => i.ProdutoId);


            builder.Ignore(p => p.ListaErros);

            builder.ToTable("ItemPedido");

        }
    }
}
