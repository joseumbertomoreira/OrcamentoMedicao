namespace Main.Models;

public class Orcamento
{
    public int Id { get; set; }
    public string? NomeProjeto { get; set; }
    public string? Cliente { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.Now;
    public int ObraId { get; set; }
    public Obra? Obra { get; set; }
    public List<ItemOrcamento> Itens { get; set; } = new();
    public decimal BDI { get; set; }

    public decimal Total => Itens.Sum(i => i.Total) * (1 + BDI / 100);
}
