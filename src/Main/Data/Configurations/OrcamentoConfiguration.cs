using Main.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Main.Data.Configurations;

public class OrcamentoConfiguration : IEntityTypeConfiguration<Orcamento>
{
    public void Configure(EntityTypeBuilder<Orcamento> builder)
    {
        builder.ToTable("Orcamentos");

        builder.HasKey(or => or.Id);

        builder.Property(or => or.NomeProjeto)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(or => or.Cliente)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(or => or.DataCriacao)
            .HasDefaultValueSql("GETDATE()");

        builder.Property(or => or.BDI)
            .HasColumnType("decimal(5,2)")
            .HasDefaultValue(0);

        builder.HasOne(or => or.Obra)
            .WithMany(o => o.Orcamentos)
            .HasForeignKey(or => or.ObraId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(or => or.Itens)
            .WithOne(io => io.Orcamento)
            .HasForeignKey(io => io.OrcamentoId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
