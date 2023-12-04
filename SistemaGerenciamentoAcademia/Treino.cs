using System;
using System.Collections.Generic;
using System.Linq;

public class Treino
{
    public string Tipo { get; set; }
    public string Objetivo { get; set; }
    public List<Exercicio> ListaExercicios { get; set; } = new List<Exercicio>();
    public int DuracaoEstimadaMinutos { get; set; }
    public DateTime DataInicio { get; set; }
    public int VencimentoDias { get; set; }
    public Treinador TreinadorResponsavel { get; set; }
    public List<(Cliente, int)> Avaliacoes { get; set; } = new List<(Cliente, int)>();
    public int Id { get; internal set; }

    public Treino(string tipo, string objetivo, int duracaoEstimadaMinutos, int vencimentoDias, Treinador treinadorResponsavel)
    {
        Tipo = tipo;
        Objetivo = objetivo;
        DuracaoEstimadaMinutos = duracaoEstimadaMinutos;
        VencimentoDias = vencimentoDias;
        TreinadorResponsavel = treinadorResponsavel;
        DataInicio = DateTime.Now;
    }

    internal List<Exercicio> Top10ExerciciosMaisUtilizados()
    {
        // Substitua esta lógica pela implementação real para obter os exercícios mais utilizados nos treinos.
        // A lógica real dependerá de como os exercícios são registrados e avaliados nos treinos.
        // Aqui, estamos retornando uma lista vazia como exemplo.
        return new List<Exercicio>();
    }
}
