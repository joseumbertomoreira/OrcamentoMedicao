namespace Main.Models;

public class Obra
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Localizacao { get; set; }
    public string? Cliente { get; set; }
    public List<Medicao> Medicoes { get; set; } = new();
    public List<Orcamento> Orcamentos { get; set; } = new();
}
