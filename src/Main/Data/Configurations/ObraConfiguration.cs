using Main.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Main.Data.Configurations;

public class ObraConfiguration : IEntityTypeConfiguration<Obra>
{
    public void Configure(EntityTypeBuilder<Obra> builder)
    {
        builder.ToTable("Obras");

        builder.HasKey(o => o.Id);

        builder.Property(o => o.Nome).IsRequired().HasMaxLength(200);

        builder.Property(o => o.Localizacao).HasMaxLength(300);

        builder.Property(o => o.Cliente).IsRequired().HasMaxLength(150);

        builder.HasMany(o => o.Medicoes).WithOne(m => m.Obra).HasForeignKey(m => m.ObraId).OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(o => o.Orcamentos).WithOne(or => or.Obra).HasForeignKey(or => or.ObraId).OnDelete(DeleteBehavior.Cascade);
    }
}