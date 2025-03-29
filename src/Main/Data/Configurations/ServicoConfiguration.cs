using Main.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Main.Data.Configurations;

public class ServicoConfiguration : IEntityTypeConfiguration<Servico>
{
    public void Configure(EntityTypeBuilder<Servico> builder)
    {
        builder.ToTable("Servicos");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Descricao)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(s => s.Unidade)
            .HasMaxLength(10);

        builder.Property(s => s.Quantidade)
            .HasColumnType("decimal(10,2)")
            .IsRequired();

        builder.Property(s => s.PrecoUnitario)
            .HasColumnType("decimal(10,2)")
            .IsRequired();

        builder.HasOne(s => s.Medicao)
            .WithMany(m => m.Servicos)
            .HasForeignKey(s => s.MedicaoId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
