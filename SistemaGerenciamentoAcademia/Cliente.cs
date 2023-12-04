using System;
using System.Collections.Generic;

public class Cliente : Pessoa
{
    public int Altura { get; set; }
    public int Peso { get; set; }
    public List<(Treino, DateTime, int)> Treinos { get; set; } = new List<(Treino, DateTime, int)>();

    public Cliente(string nome, DateTime dataNascimento, string cpf, int altura, int peso) : base(nome, dataNascimento, cpf)
    {
        Altura = altura;
        Peso = peso;
    }

    internal void ExibirIMC()
    {
        double imc = CalcularIMC();
        Console.WriteLine($"IMC do cliente {Nome}: {imc:F2}");
    }

    internal double CalcularIMC()
    {
        // Fórmula do IMC: peso (kg) / (altura (m) * altura (m))
        double alturaEmMetros = Altura / 100.0; // Convertendo altura para metros
        return Peso / (alturaEmMetros * alturaEmMetros);
    }
}
