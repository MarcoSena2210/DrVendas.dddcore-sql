using DrVendas.dddcore.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrVendas.dddcore.Infra.Data.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Apelido)
                .HasColumnType("varchar(20)")
                .IsRequired();

            builder.Property(p => p.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.Descricao)
               .HasColumnType("varchar(150)")
               .IsRequired();

            builder.Property(p => p.Valor)
                .HasColumnType("decimal")
                .IsRequired();

            builder.Property(p => p.Unidade)
                .HasColumnType("varchar(2)")
                .IsRequired();

            builder.HasOne(p => p.Fornecedor)
               .WithMany(f => f.Produtos)
               .HasForeignKey(p => p.FornecedorId);

            builder.Ignore(p => p.ListaErros);

            builder.ToTable("Produto");

        }
    }
}



