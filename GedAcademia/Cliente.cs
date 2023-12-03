namespace GedAcademia;

public class Cliente : Pessoa
{
    public int AlturaCm { get; set; }
    public int PesoKg { get; set; }
    public List<Avaliacao> Avaliacoes { get; set; } = new List<Avaliacao>();
}