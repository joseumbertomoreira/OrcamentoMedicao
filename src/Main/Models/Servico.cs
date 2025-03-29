namespace Main.Models;

public class Servico
{
    public int Id { get; set; }
    public string? Descricao { get; set; }
    public string? Unidade { get; set; }
    public double Quantidade { get; set; }
    public decimal PrecoUnitario { get; set; }
    public int MedicaoId { get; set; }
    public Medicao? Medicao { get; set; }

    public decimal Total => (decimal)Quantidade * PrecoUnitario;
}
