namespace GedAcademia;

public class Treino
{
    public string? Tipo { get; set; }
    public string? Objetivo { get; set; }
    public List<Exercicio> ListaExercicios { get; set; } = new List<Exercicio>();
    public int DuracaoEstimadaMinutos { get; set; }
    public DateTime DataInicio { get; set; }
    public int VencimentoDias { get; set; }
    public Treinador TreinadorResponsavel { get; set; }
    public List<Avaliacao> Avaliacoes { get; set; } = new List<Avaliacao>();
    public int LimiteExercicios { get; set; } = 10;

}


