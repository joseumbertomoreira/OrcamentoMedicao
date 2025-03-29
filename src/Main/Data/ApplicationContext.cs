using Main.Data.Configurations;
using Main.Models;
using Microsoft.EntityFrameworkCore;

namespace Main.Data;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ItemOrcamentoConfiguration());
        modelBuilder.ApplyConfiguration(new MedicaoConfiguration());
        modelBuilder.ApplyConfiguration(new ObraConfiguration());
        modelBuilder.ApplyConfiguration(new OrcamentoConfiguration());
        modelBuilder.ApplyConfiguration(new ServicoConfiguration());
    }

    public DbSet<ItemOrcamento> ItensOrcamento { get; set; }
    public DbSet<Medicao> Medicoes { get; set; }
    public DbSet<Obra> Obras { get; set; }
    public DbSet<Orcamento> Orcamentos { get; set; }
    public DbSet<Servico> Servicos { get; set; }

}
