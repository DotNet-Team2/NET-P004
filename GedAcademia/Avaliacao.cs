namespace GedAcademia;

public class Avaliacao
{
    public Cliente Cliente { get; set; }
    public int Nota { get; set; }

    public Avaliacao(Cliente cliente, int nota)
    {
        Cliente = cliente;
        Nota = nota;
    }
}

