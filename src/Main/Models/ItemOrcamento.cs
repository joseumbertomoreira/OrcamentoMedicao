namespace Main.Models;

public class ItemOrcamento
{
    public int Id { get; set; }
    public int OrcamentoId { get; set; }
    public Orcamento? Orcamento { get; set; }
    public string? Codigo { get; set; }
    public string? Descricao { get; set; }
    public string? Unidade { get; set; }
    public double Quantidade { get; set; }
    public decimal PrecoUnitario { get; set; }

    public decimal Total => (decimal)Quantidade * PrecoUnitario;
}
