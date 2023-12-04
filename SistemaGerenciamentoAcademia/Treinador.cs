public class Treinador : Pessoa
{
    public string CREF { get; set; }
    public List<Treino> Treinos { get; set; } = new List<Treino>();

    public Treinador(string nome, DateTime dataNascimento, string cpf, string cref) : base(nome, dataNascimento, cpf)
    {
        CREF = cref;
    }

    public double CalcularMediaNotas()
    {
        if (Treinos == null || Treinos.Count == 0)
        {
            // Se não houver treinos, a média é zero ou outra lógica apropriada
            return 0;
        }

        // Calcula a média das notas de todos os treinos do treinador
        double somaNotas = Treinos.Sum(t => t.Avaliacoes.Average(avaliacao => avaliacao.Item2));
        double media = somaNotas / Treinos.Count;

        return media;
    }
}
