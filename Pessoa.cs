namespace pessoa.aula4 {

public class Pessoa
{
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string CPF;
    public string _cpf
    {
        get { return _cpf; }
        set { _cpf = TratarCPF(value); }
    }

    public string TratarCPF(string input)
    {
        // Implemetar aqui a logica para validação
        
        return input;
    }
}

public class Treinador : Pessoa
{
    public string CREF { get; set; }
    public string _cref
    {
        get { return _cref; }
        set { _cref = TratarCREF(value); }
    }
    public string TratarCREF(string input)
    {
        // Implmentar aqui a lógica para validação
        
        return input;
    }
    public static List<Treino> TreinosAssociados { get; set; } = new List<Treino>();
    public Treinador(string _nome, DateTime _dataNascimentoStr, string _cpf, string _cref) {
        Nome = _nome;
        DataNascimento = _dataNascimentoStr;
        CPF = _cpf;
        CREF = _cref;
    }
}

public class Cliente : Pessoa
{
    public double Altura { get; set; }
    public double Peso { get; set; }
    public  List<(Treino, DateTime, int)> TreinosAssociados { get; set; } = new List<(Treino, DateTime, int)>();
    public  List<(Treino, int)> Avaliacoes { get; set; } = new List<(Treino, int)>();

    public void AssociarTreino(Treino treino, DateTime dataInicio, int vencimentoDias)
    {
        if (TreinosAssociados.Count < 2)
        {
            TreinosAssociados.Add((treino, dataInicio, vencimentoDias));
        }
        else
        {
            Console.WriteLine("O cliente já está associado a dois treinos.");
        }
    }

    public void AvaliarTreino(Treino treino, int avaliacao)
    {
        Avaliacoes.Add((treino, avaliacao));
    }
}

public class Exercicio
{
    public string GrupoMuscular { get; set; }
    public int Series { get; set; }
    public int Repeticoes { get; set; }
    public int TempoIntervaloSegundos { get; set; }
}

public class Treino
{
    public string Tipo { get; set; }
    public string Objetivo { get; set; }
    public List<Exercicio> ListaExercicios { get; set; } = new List<Exercicio>();
    public int DuracaoEstimadaMinutos { get; set; }
    public DateTime DataInicio { get; set; }
    public int VencimentoDias { get; set; }
    public Treinador TreinadorResponsavel { get; set; } 
}
}