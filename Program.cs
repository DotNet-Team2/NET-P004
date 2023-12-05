using System;
using System.Collections.Generic;
using System.Linq;
namespace pessoa.aula4;

class Program
{
    static List<Treinador> treinadores = new List<Treinador>();
    static List<Cliente> clientes = new List<Cliente>();
    static List<Treino> treinos = new List<Treino>();

    static void Main()
    {// Adiciona clientes aniversariantes
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Adicionar Treinador");
            Console.WriteLine("2. Adicionar Cliente");
            Console.WriteLine("3. Adicionar Treino");
            Console.WriteLine("4. Gerar Relatórios");
            Console.WriteLine("5. Sair");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AdicionarTreinador();
                    break;

                case "2":
                    AdicionarCliente();
                    break;

                case "3":
                    AdicionarTreino();
                    break;

                case "4":
                    GerarRelatorios();
                    break;

                case "5":
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    static void AdicionarTreinador()
    {
        Console.Write("Digite o nome do treinador: ");
        string nome = Console.ReadLine();

        Console.Write("Digite a data de nascimento (DD/MM/YYYY): ");
        string dataNascimentoStr = Console.ReadLine();

        Console.Write("Digite o CPF: ");
        string cpf = Console.ReadLine();

        Console.Write("Digite o CREF: ");
        string cref = Console.ReadLine();

        try
        {
            Treinador treinador = new Treinador(nome, DateTime.Parse(dataNascimentoStr), cpf, cref);
            treinadores.Add(treinador);
        }
        catch (FormatException)
        {
            Console.WriteLine("Formato de data inválido.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro: {ex.Message}");
        }
    }

    static void AdicionarCliente()
    {
        Console.Write("Digite o nome do cliente: ");
        string nomeCliente = Console.ReadLine();

        Console.Write("Digite a data de nascimento do cliente (DD/MM/YYYY): ");
        string dataNascimentoClienteStr = Console.ReadLine();

        Console.Write("Digite o CPF do cliente: ");
        string cpfCliente = Console.ReadLine();

        Console.Write("Digite o peso do cliente em kg: ");
        double pesoCliente = double.Parse(Console.ReadLine());

        try
        {
            Cliente cliente = new Cliente
        {
            Nome = nomeCliente,
            DataNascimento = DateTime.Parse(dataNascimentoClienteStr),
            CPF = cpfCliente,
            Altura = alturaCliente,
            Peso = pesoCliente
        };

            clientes.Add(cliente);
        }
        catch (FormatException)
        { 
            Pessoa pessoa = new Pessoa();
            Console.WriteLine("Formato de data inválido.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro: {ex.Message}");
        }
    }

    static void AdicionarTreino()
    {
        Console.Write("Digite o tipo de treino: ");
            string tipoTreino = Console.ReadLine();

            Console.Write("Digite o objetivo do treino: ");
            string objetivoTreino = Console.ReadLine();

            // Assuming a treino can have up to 10 exercícios
            List<Exercicio> listaExercicios = new List<Exercicio>();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Exercício {i + 1}:");

                Console.Write("Digite o grupo muscular: ");
                string grupoMuscular = Console.ReadLine();

                Console.Write("Digite o número de séries: ");
                int series = int.Parse(Console.ReadLine());

                Console.Write("Digite o número de repetições: ");
                int repeticoes = int.Parse(Console.ReadLine());

                Console.Write("Digite o tempo de intervalo em segundos: ");
                int tempoIntervalo = int.Parse(Console.ReadLine());

                Exercicio exercicio = new Exercicio
                {
                    GrupoMuscular = grupoMuscular,
                    Series = series,
                    Repeticoes = repeticoes,
                    TempoIntervaloSegundos = tempoIntervalo
                };

                listaExercicios.Add(exercicio);
            }

            Console.Write("Digite a duração estimada do treino em minutos: ");
            int duracaoEstimada = int.Parse(Console.ReadLine());

            Console.Write("Digite a data de início do treino (DD/MM/YYYY): ");
            string dataInicioTreinoStr = Console.ReadLine();

            Console.Write("Digite o número de dias até o vencimento do treino: ");
            int vencimentoDias = int.Parse(Console.ReadLine());

            // Assuming a treino must be associated with a treinador
            Console.Write("Digite o nome do treinador responsável: ");
            string nomeTreinador = Console.ReadLine();
            Treinador treinadorResponsavel = treinadores.FirstOrDefault(t => t.Nome == nomeTreinador);

            if (treinadorResponsavel == null)
            {
                Console.WriteLine("Treinador não encontrado.");
                return;
            }

            try
            {
                Treino treino = new Treino
                {
                    Tipo = tipoTreino,
                    Objetivo = objetivoTreino,
                    ListaExercicios = listaExercicios,
                    DuracaoEstimadaMinutos = duracaoEstimada,
                    DataInicio = DateTime.Parse(dataInicioTreinoStr),
                    VencimentoDias = vencimentoDias,
                    TreinadorResponsavel = treinadorResponsavel
                };

                treinos.Add(treino);
            }
            catch (FormatException)
            {
                Console.WriteLine("Formato de data inválido.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
            }
    }

    static void GerarRelatorios()
    {
        Console.WriteLine("Relatórios:");
        Console.WriteLine("1. Treinadores com idade entre dois valores");
        Console.WriteLine("2. Clientes com idade entre dois valores");
        Console.WriteLine("3. Clientes com IMC maior que um valor informado, em ordem crescente");
        Console.WriteLine("4. Clientes em ordem alfabética");
        Console.WriteLine("5. Clientes do mais velho para mais novo");
        Console.WriteLine("6. Treinadores e clientes aniversariantes do mês informado");
        Console.WriteLine("7. Treinos em ordem crescente pela quantidade de dias até o vencimento");
        Console.WriteLine("8. Treinadores em ordem decrescente da média de notas dos seus treinos");
        Console.WriteLine("9. Treinos cujo objetivo contenham determinada palavra");
        Console.WriteLine("10. Top 10 exercícios mais utilizados nos treinos");

        Console.WriteLine("Escolha o número do relatório:");
        string reportChoice = Console.ReadLine();

        switch (reportChoice)
        {
            case "1":
                    
                    Console.WriteLine("Digite a idade mínima:");
                    int idadeMin1 = int.Parse(Console.ReadLine());

                    Console.WriteLine("Digite a idade máxima:");
                    int idadeMax1 = int.Parse(Console.ReadLine());

                    var result1 = TreinadoresEntreIdades(idadeMin1, idadeMax1);
                    Console.WriteLine(result1);
                    break;

                case "2":
                    
                    Console.WriteLine("Digite a idade mínima:");
                    int idadeMin2 = int.Parse(Console.ReadLine());

                    Console.WriteLine("Digite a idade máxima:");
                    int idadeMax2 = int.Parse(Console.ReadLine());

                    var result2 = ClientesEntreIdades(idadeMin2, idadeMax2);
                    Console.WriteLine(result2);
                    break;

                case "3":
                    
                    Console.WriteLine("Digite o valor de IMC:");
                    double imcValor = double.Parse(Console.ReadLine());

                    var result3 = ClientesPorIMC(imcValor);
                    Console.WriteLine(result3);
                    break;

                case "4":
                    
                    var result4 = ClientesOrdenadosPorNome();
                    Console.WriteLine(result4);
                    break;

                case "5":
                    
                    var result5 = ClientesMaisVelhoParaNovo();
                    Console.WriteLine(result5);
                    break;

                case "6":
                    
                    Console.WriteLine("Digite o mês:");
                    int mesInformado6 = int.Parse(Console.ReadLine());

                    var result6 = AniversariantesDoMes(mesInformado6);
                    Console.WriteLine(result6);
                    break;

                case "7":
                    
                    var result7 = TreinosOrdenadosPorVencimento();
                    Console.WriteLine(result7);
                    break;

                case "8":
                    
                    /*var result8 = TreinadoresOrdenadosPorMediaNotas();
                    Console.WriteLine(result8);*/
                    break;

                case "9":
                    
                    Console.WriteLine("Digite a palavra:");
                    string palavra9 = Console.ReadLine();

                    var result9 = TreinosComObjetivo(palavra9);
                    Console.WriteLine(result9);
                    break;

                case "10":
                    
                    var result10 = Top10ExerciciosMaisUtilizados();
                    Console.WriteLine(result10);
                    break;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
        }

        static List<Treinador> TreinadoresEntreIdades(int idadeMin, int idadeMax)
        {
            return treinadores
                .Where(t => (DateTime.Now.Year - t.DataNascimento.Year) >= idadeMin && (DateTime.Now.Year - t.DataNascimento.Year) <= idadeMax)
                .ToList();
        }

        static List<Cliente> ClientesEntreIdades(int idadeMin, int idadeMax)
        {
            return clientes
                .Where(c => (DateTime.Now.Year - c.DataNascimento.Year) >= idadeMin && (DateTime.Now.Year - c.DataNascimento.Year) <= idadeMax)
                .ToList();Console.WriteLine("Sem resultado");
        }

        static List<Cliente> ClientesPorIMC(double imcValor)
        {
            return clientes
                .Where(c => (double)c.Peso / Math.Pow((double)c.Altura / 100, 2) > imcValor)
                .OrderBy(c => (double)c.Peso / Math.Pow((double)c.Altura / 100, 2))
                .ToList();
        }

        static List<Cliente> ClientesOrdenadosPorNome()
        {
            return clientes
                .OrderBy(c => c.Nome)
                .ToList();
        }

        static List<Cliente> ClientesMaisVelhoParaNovo()
        {
            return clientes
                .OrderByDescending(c => c.DataNascimento)
                .ToList();
        }

       static List<Pessoa> AniversariantesDoMes(int mesInformado)
        {
            List<Pessoa> aniversariantes = new List<Pessoa>();

            
            aniversariantes.AddRange(treinadores.Where(t => t.DataNascimento.Month == mesInformado));

            
            aniversariantes.AddRange(clientes.Where(c => c.DataNascimento.Month == mesInformado));

            return aniversariantes;
        }

        static List<Treino> TreinosOrdenadosPorVencimento()
        {
            return treinos
                .OrderBy(t => (t.DataInicio.AddDays(t.VencimentoDias) - DateTime.Now).Days)
                .ToList();
        }

        /* static List<Treinador> TreinadoresOrdenadosPorMediaNotas()
        {
            return treinadores
                .OrderByDescending(t => t.TreinosAssociados.Average(tr => tr.Item1.ClientesAvaliacao.Sum(a => a.Item2)))
                .ToList();
                
        }*/

        static List<Treino> TreinosComObjetivo(string palavra)
        {
            return treinos
                .Where(t => t.Objetivo.Contains(palavra))
                .ToList();
        }

        static List<Exercicio> Top10ExerciciosMaisUtilizados()
        {
            return treinos
                .SelectMany(t => t.ListaExercicios)
                .GroupBy(e => e)
                .OrderByDescending(g => g.Count())
                .Take(10)
                .Select(g => g.Key)
                .ToList();
        }
    }
}
