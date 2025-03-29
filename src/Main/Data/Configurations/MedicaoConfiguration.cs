using Main.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Main.Data.Configurations;

public class MedicaoConfiguration : IEntityTypeConfiguration<Medicao>
{
    public void Configure(EntityTypeBuilder<Medicao> builder)
    {
        builder.ToTable("Medicoes");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Data)
            .IsRequired();

        builder.HasOne(m => m.Obra)
            .WithMany(o => o.Medicoes)
            .HasForeignKey(m => m.ObraId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(m => m.Servicos)
            .WithOne(s => s.Medicao)
            .HasForeignKey(s => s.MedicaoId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
