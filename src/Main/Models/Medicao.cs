namespace Main.Models;

public class Medicao
{
    public int Id { get; set; }
    public DateTime Data { get; set; }
    public int ObraId { get; set; }
    public Obra? Obra { get; set; }
    public List<Servico> Servicos { get; set; } = new();
}
