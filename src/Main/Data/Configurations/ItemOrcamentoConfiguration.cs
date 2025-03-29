using Main.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Main.Data.Configurations;

public class ItemOrcamentoConfiguration : IEntityTypeConfiguration<ItemOrcamento>
{
    public void Configure(EntityTypeBuilder<ItemOrcamento> builder)
    {
        builder.ToTable("ItensOrcamento");

        builder.HasKey(io => io.Id);

        builder.Property(io => io.Codigo)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(io => io.Descricao)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(io => io.Unidade)
            .HasMaxLength(10);

        builder.Property(io => io.Quantidade)
            .HasColumnType("decimal(10,2)")
            .IsRequired();

        builder.Property(io => io.PrecoUnitario)
            .HasColumnType("decimal(10,2)")
            .IsRequired();

        builder.HasOne(io => io.Orcamento)
            .WithMany(or => or.Itens)
            .HasForeignKey(io => io.OrcamentoId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
