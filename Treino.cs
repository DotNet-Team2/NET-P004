﻿namespace _NET_P004;

public class Treino
{
    private string tipo, objetivo;
    private List<Exercicios> exercicios; //falta incializar 
    private int duracao;
    private DateTime dataInicio;
    private int vencimento;
    private Treinador treinador;
    private List<(Cliente, int?)> avaliacoesClientes;

    public Treino(string tipo, string objetivo, List<Exercicios> exercicios, int duracao, DateTime dataInicio, int vencimento, Treinador treinador)
        {
            this.tipo = tipo;
            this.objetivo = objetivo;
            this.duracao = duracao;
            this.dataInicio = dataInicio;
            this.vencimento = vencimento;
            this.treinador = treinador;
            this.exercicios = new List<Exercicios>(); // Inicializa a lista de exercícios
            this.avaliacoesClientes = new List<(Cliente, int?)>();
        }

        // Método get para o campo 'tipo'
        public string GetTipo()
        {
            return tipo;
        }

        // Método set para o campo 'tipo'
        public void SetTipo(string novoTipo)
        {
            tipo = novoTipo;
        }

        // Método get para o campo 'objetivo'
        public string GetObjetivo()
        {
            return objetivo;
        }

        // Método set para o campo 'objetivo'
        public void SetObjetivo(string novoObjetivo)
        {
            objetivo = novoObjetivo;
        }

        // Método get para o campo 'exercicios'
        public List<Exercicios> GetExercicios()
        {
            return exercicios;
        }

        // Método set para o campo 'exercicios'
        public void SetExercicios(List<Exercicios> novosExercicios)
        {
            exercicios = novosExercicios;
        }

        // Método get para o campo 'duracao'
        public int GetDuracao()
        {
            return duracao;
        }

        // Método set para o campo 'duracao'
        public void SetDuracao(int novaDuracao)
        {
            duracao = novaDuracao;
        }

        // Método get para o campo 'dataInicio'
        public DateTime GetDataInicio()
        {
            return dataInicio;
        }

        // Método set para o campo 'dataInicio'
        public void SetDataInicio(DateTime novaDataInicio)
        {
            dataInicio = novaDataInicio;
        }

        // Método get para o campo 'vencimento'
        public int GetVencimento()
        {
            return vencimento;
        }

        // Método set para o campo 'vencimento'
        public void SetVencimento(int novoVencimento)
        {
            vencimento = novoVencimento;
        }

        // Método get para o campo 'treinador'
        public Treinador GetTreinador()
        {
            return treinador;
        }

        // Método set para o campo 'treinador'
        public void SetTreinador(Treinador novoTreinador)
        {
            treinador = novoTreinador;
        }

        public void AdicionarAvaliacaoCliente(Cliente cliente, int? avaliacao)
        {
            avaliacoesClientes.Add((cliente, avaliacao));
        }

        // Método para obter as avaliações dos clientes
        public List<(Cliente, int?)> ObterAvaliacoesClientes()
        {
            return avaliacoesClientes;
        }
}
