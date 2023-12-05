namespace GedAcademia;

public class Cliente : Pessoa
{
    public int AlturaCm { get; set; }
    public int PesoKg { get; set; }
    public Plano planoAtivo;
    List<Pagamento>pagamentosclientes =new List<Pagamento>();
    public List<Avaliacao> Avaliacoes { get; set; } = new List<Avaliacao>();
            public void AdicionarPagamento(Pagamento pagamento)
        {
            pagamentosclientes.Add(pagamento);
        }


    
}