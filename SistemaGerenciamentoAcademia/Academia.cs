using System;
using System.Collections.Generic;
using System.Linq;

public class Academia
{
    public List<Treinador> Treinadores { get; set; } = new List<Treinador>();
    public List<Cliente> Clientes { get; set; } = new List<Cliente>();
    public List<Treino> Treinos { get; set; } = new List<Treino>();

internal List<Exercicio> Top10ExerciciosMaisUtilizados()
{
    // Verifica se há exercícios na lista de treinos
    if (Treinos == null || Treinos.Count == 0)
    {
        Console.WriteLine("Não há treinos cadastrados para obter os exercícios mais utilizados.");
        return new List<Exercicio>();
    }

    // Flatten a lista de exercícios de todos os treinos
    List<Exercicio> todosExercicios = Treinos.SelectMany(t => t.ListaExercicios).ToList();

    // Agrupa os exercícios por nome e conta a frequência de cada exercício
    var exerciciosAgrupados = todosExercicios
        .GroupBy(exercicio => exercicio.Nome)
        .Select(grupo => new { Exercicio = grupo.Key, Frequencia = grupo.Count() })
        .OrderByDescending(item => item.Frequencia)
        .Take(10) // Pega os 10 exercícios mais utilizados
        .Select(item => new Exercicio { Nome = item.Exercicio, GrupoMuscular = "Desconhecido" }) // Cria novos objetos Exercicio com base no nome
        .ToList();

    return exerciciosAgrupados;
}

internal List<Pessoa> AniversariantesDoMes(int mes)
{
    List<Pessoa> pessoasDoMes = Clientes
        .Where(cliente => cliente.DataNascimento.Month == mes)
        .Cast<Pessoa>()
        .ToList();

    pessoasDoMes.AddRange(Treinadores
        .Where(treinador => treinador.DataNascimento.Month == mes)
        .Cast<Pessoa>());

    return pessoasDoMes;
}


internal List<Cliente> ClientesComIMCMaiorQue(double valorMinimo)
{
    return Clientes.Where(cliente => cliente.CalcularIMC() > valorMinimo).ToList();
}

internal List<Cliente> ClientesDoMaisVelhoParaOMaisNovo()
{
    return Clientes.OrderByDescending(cliente => cliente.DataNascimento).ToList();
}

internal List<Cliente> ClientesEmOrdemAlfabetica()
{
    return Clientes.OrderBy(cliente => cliente.Nome).ToList();
}


internal List<Treinador> TreinadoresOrdenadosPorMediaDeNotas()
{
    return Treinadores.OrderByDescending(treinador => treinador.CalcularMediaNotas()).ToList();
}

internal List<Treino> TreinosOrdenadosPorDiasAteOVencimento()
{
    return Treinos.OrderBy(treino => treino.VencimentoDias).ToList();
}

internal List<Treino> TreinosPorObjetivoContendoPalavra(string? palavraChave)
{
    return Treinos.Where(treino => treino.Objetivo?.Contains(palavraChave, StringComparison.OrdinalIgnoreCase) == true)
                  .ToList();
}


    internal List<Cliente> ClientesEntreIdades(int idadeMinima, int idadeMaxima)
{
    return Clientes.Where(cliente => CalcularIdade(cliente.DataNascimento) >= idadeMinima
                                  && CalcularIdade(cliente.DataNascimento) <= idadeMaxima)
                   .ToList();
}

    internal void AvaliarTreino(Cliente cliente, Treino treino, int avaliacao)
{
    // Adiciona a avaliação à lista de avaliações no treino
    treino.Avaliacoes.Add((cliente, avaliacao));
    Console.WriteLine("Avaliação registrada com sucesso!");
}


    // Método para adicionar um cliente à lista de clientes
    public void AdicionarCliente(Cliente cliente)
    {
        Clientes.Add(cliente);
        Console.WriteLine("Cliente adicionado com sucesso!");
    }

    // Método para adicionar um treinador à lista de treinadores
    public void AdicionarTreinador(Treinador treinador)
    {
        Treinadores.Add(treinador);
        Console.WriteLine("Treinador adicionado com sucesso!");
    }
internal void AssociarTreinoACliente(Cliente cliente, Treino treino, DateTime dataInicio, int vencimentoDias)
{
    // Adicione o treino à lista de treinos do cliente com a data de início e vencimento
    cliente.Treinos.Add((treino, dataInicio, vencimentoDias));

    Console.WriteLine("Treino associado ao cliente com sucesso!");
}

    // Exemplo de um método de relatório para mostrar na tela
    public void MostrarRelatorioTreinadoresEntreIdades(int idadeMinima, int idadeMaxima)
    {
        var treinadores = TreinadoresEntreIdades(idadeMinima, idadeMaxima);

        Console.WriteLine("\nTreinadores entre as idades especificadas:");
        foreach (var treinador in treinadores)
        {
            Console.WriteLine($"Nome: {treinador.Nome}, Data de Nascimento: {treinador.DataNascimento.ToShortDateString()}, CREF: {treinador.CREF}");
        }
    }

    // Método auxiliar para obter treinadores entre idades específicas
    internal List<Treinador> TreinadoresEntreIdades(int idadeMinima, int idadeMaxima)
    {
        return Treinadores.Where(t => CalcularIdade(t.DataNascimento) >= idadeMinima && CalcularIdade(t.DataNascimento) <= idadeMaxima).ToList();
    }

    // Método auxiliar para calcular a idade com base na data de nascimento
    internal int CalcularIdade(DateTime dataNascimento)
    {
        int idade = DateTime.Now.Year - dataNascimento.Year;

        if (DateTime.Now.DayOfYear < dataNascimento.DayOfYear)
        {
            idade--;
        }

        return idade;
    }

    // Método para criar um treino e associar um cliente automaticamente
    public void CriarTreinoEAssociarCliente(string cpfCliente, string tipo, string objetivo, int duracaoEstimadaMinutos, int vencimentoDias, Treinador treinadorResponsavel)
    {
        Cliente cliente = Clientes.FirstOrDefault(c => c.CPF == cpfCliente);

        if (cliente != null)
        {
            Treino novoTreino = new Treino(tipo, objetivo, duracaoEstimadaMinutos, vencimentoDias, treinadorResponsavel);
            cliente.Treinos.Add((novoTreino, DateTime.Now, vencimentoDias));
            Treinos.Add(novoTreino);

            Console.WriteLine("Treino criado e cliente associado com sucesso!");
        }
        else
        {
            Console.WriteLine("Cliente não encontrado.");
        }
    }
   
}
