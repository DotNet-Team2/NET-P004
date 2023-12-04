using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static Academia academia = new Academia();

    static void Main()
    {
        int opcao;

        do
        {
            ExibirMenu();
            Console.Write("Escolha uma opção: ");

            if (int.TryParse(Console.ReadLine(), out opcao))
            {
                ExecutarOpcao(opcao);
            }
            else
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
            }

        } while (opcao != 0);
    }

    static void ExibirMenu()
    {
        Console.WriteLine("\n===== Menu =====");
        Console.WriteLine("1. Adicionar Treinador");
        Console.WriteLine("2. Adicionar Cliente");
        Console.WriteLine("3. Adicionar Treino");
        Console.WriteLine("4. Associar Treino a Cliente");
        Console.WriteLine("5. Avaliar Treino");
        Console.WriteLine("6. Relatório: Treinadores entre Idades");
        Console.WriteLine("7. Relatório: Clientes entre Idades");
        Console.WriteLine("8. Relatório: Clientes com IMC Maior que");
        Console.WriteLine("9. Relatório: Clientes em Ordem Alfabética");
        Console.WriteLine("10. Relatório: Clientes do Mais Velho para o Mais Novo");
        Console.WriteLine("11. Relatório: Aniversariantes do Mês");
        Console.WriteLine("12. Relatório: Treinos por Dias até o Vencimento");
        Console.WriteLine("13. Relatório: Treinadores por Média de Notas");
        Console.WriteLine("14. Relatório: Treinos por Objetivo");
        Console.WriteLine("15. Top 10: Exercícios Mais Utilizados");
        Console.WriteLine("0. Sair");
    }

    static void ExecutarOpcao(int opcao)
    {
        switch (opcao)
        {
            case 1:
                AdicionarTreinador();
                break;

            case 2:
                AdicionarCliente();
                break;

            case 3:
                AdicionarTreino();
                break;

            case 4:
                AssociarTreinoACliente();
                break;

            case 5:
                AvaliarTreino();
                break;

            case 6:
                RelatorioTreinadoresEntreIdades();
                break;

            case 7:
                RelatorioClientesEntreIdades();
                break;

            case 8:
                RelatorioClientesComIMCMaiorQue();
                break;

            case 9:
                RelatorioClientesEmOrdemAlfabetica();
                break;

            case 10:
                RelatorioClientesDoMaisVelhoParaOMaisNovo();
                break;

            case 11:
                RelatorioAniversariantesDoMes();
                break;

            case 12:
                RelatorioTreinosPorDiasAteOVencimento();
                break;

            case 13:
                RelatorioTreinadoresPorMediaDeNotas();
                break;

            case 14:
                RelatorioTreinosPorObjetivo();
                break;

            case 15:
                Top10ExerciciosMaisUtilizados();
                break;

            case 0:
                Console.WriteLine("Saindo do programa. Até mais!");
                break;

            default:
                Console.WriteLine("Opção inválida. Tente novamente.");
                break;
        }

        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    static void AdicionarTreinador()
    {
        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.Write("Data de Nascimento (dd/mm/aaaa): ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime dataNascimento))
        {
            Console.Write("CPF: ");
            string cpf = Console.ReadLine();

            Console.Write("CREF: ");
            string cref = Console.ReadLine();

            Treinador treinador = new Treinador(nome, dataNascimento, cpf, cref);
            academia.AdicionarTreinador(treinador);

            Console.WriteLine("Treinador adicionado com sucesso!");
        }
        else
        {
            Console.WriteLine("Data de nascimento inválida.");
        }
    }

    static void AdicionarCliente()
    {
        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.Write("Data de Nascimento (dd/mm/aaaa): ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime dataNascimento))
        {
            Console.Write("CPF: ");
            string cpf = Console.ReadLine();

            Console.Write("Altura (cm): ");
            if (int.TryParse(Console.ReadLine(), out int altura))
            {
                Console.Write("Peso (kg): ");
                if (int.TryParse(Console.ReadLine(), out int peso))
                {
                    Cliente cliente = new Cliente(nome, dataNascimento, cpf, altura, peso);
                    academia.AdicionarCliente(cliente);

                    Console.WriteLine("Cliente adicionado com sucesso!");

                    // Agora, após atribuir os valores de altura e peso, chamamos o método ExibirIMC
                    cliente.ExibirIMC();
                }
                else
                {
                    Console.WriteLine("Peso inválido.");
                }
            }
            else
            {
                Console.WriteLine("Altura inválida.");
            }
        }
        else
        {
            Console.WriteLine("Data de nascimento inválida.");
        }
    }

    static void AdicionarTreino()
{
    Console.Write("Tipo de Treino: ");
    string tipoTreino = Console.ReadLine();

    Console.Write("Objetivo do Treino: ");
    string objetivoTreino = Console.ReadLine();

    Console.Write("Duração Estimada (minutos): ");
    if (int.TryParse(Console.ReadLine(), out int duracaoEstimada))
    {
        Console.Write("Vencimento em Dias: ");
        if (int.TryParse(Console.ReadLine(), out int vencimentoDias))
        {
            Console.Write("Treinador Responsável (CREF): ");
            string crefTreinador = Console.ReadLine();
            Treinador treinadorResponsavel = academia.Treinadores.FirstOrDefault(t => t.CREF == crefTreinador);

            if (treinadorResponsavel != null)
            {
                Treino treino = new Treino(tipoTreino, objetivoTreino, duracaoEstimada, vencimentoDias, treinadorResponsavel);
                academia.Treinos.Add(treino);

                Console.WriteLine($"Treino adicionado com sucesso! ID do Treino: {treino.Id}");
            }
            else
            {
                Console.WriteLine("Treinador não encontrado.");
            }
        }
        else
        {
            Console.WriteLine("Vencimento em dias inválido.");
        }
    }
    else
    {
        Console.WriteLine("Duração estimada inválida.");
    }
}


    static void AssociarTreinoACliente()
    {
        Console.Write("CPF do Cliente: ");
        string cpfCliente = Console.ReadLine();
        Cliente cliente = academia.Clientes.FirstOrDefault(c => c.CPF == cpfCliente);

        if (cliente != null)
        {
            Console.Write("ID do Treino: ");
            if (int.TryParse(Console.ReadLine(), out int idTreino))
            {
                Treino treino = academia.Treinos.FirstOrDefault(t => t.Id == idTreino);

                if (treino != null)
                {
                    Console.Write("Data de Início do Treino (dd/mm/aaaa): ");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime dataInicio))
                    {
                        Console.Write("Vencimento em Dias: ");
                        if (int.TryParse(Console.ReadLine(), out int vencimentoDias))
                        {
                            academia.AssociarTreinoACliente(cliente, treino, dataInicio, vencimentoDias);
                            Console.WriteLine("Treino associado ao cliente com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Vencimento em dias inválido.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Data de início inválida.");
                    }
                }
                else
                {
                    Console.WriteLine("Treino não encontrado.");
                }
            }
            else
            {
                Console.WriteLine("ID do treino inválido.");
            }
        }
        else
        {
            Console.WriteLine("Cliente não encontrado.");
        }
    }

    static void AvaliarTreino()
    {
        Console.Write("CPF do Cliente: ");
        string cpfCliente = Console.ReadLine();
        Cliente cliente = academia.Clientes.FirstOrDefault(c => c.CPF == cpfCliente);

        if (cliente != null)
        {
            Console.Write("ID do Treino: ");
            if (int.TryParse(Console.ReadLine(), out int idTreino))
            {
                Treino treino = academia.Treinos.FirstOrDefault(t => t.Id == idTreino);

                if (treino != null)
                {
                    Console.Write("Avaliação do Treino (0 a 10): ");
                    if (int.TryParse(Console.ReadLine(), out int avaliacao) && avaliacao >= 0 && avaliacao <= 10)
                    {
                        academia.AvaliarTreino(cliente, treino, avaliacao);
                        Console.WriteLine("Avaliação registrada com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Avaliação inválida. Deve ser um número entre 0 e 10.");
                    }
                }
                else
                {
                    Console.WriteLine("Treino não encontrado.");
                }
            }
            else
            {
                Console.WriteLine("ID do treino inválido.");
            }
        }
        else
        {
            Console.WriteLine("Cliente não encontrado.");
        }
    }

    static void RelatorioTreinadoresEntreIdades()
    {
        Console.Write("Idade mínima: ");
        if (int.TryParse(Console.ReadLine(), out int idadeMinima))
        {
            Console.Write("Idade máxima: ");
            if (int.TryParse(Console.ReadLine(), out int idadeMaxima))
            {
                List<Treinador> treinadores = academia.TreinadoresEntreIdades(idadeMinima, idadeMaxima);

                Console.WriteLine("\nTreinadores entre as idades especificadas:");
                foreach (var treinador in treinadores)
                {
                    Console.WriteLine($"{treinador.Nome} - Data de Nascimento: {treinador.DataNascimento.ToShortDateString()} - CREF: {treinador.CREF}");
                }
            }
            else
            {
                Console.WriteLine("Idade máxima inválida.");
            }
        }
        else
        {
            Console.WriteLine("Idade mínima inválida.");
        }
    }

    static void RelatorioClientesEntreIdades()
    {
        Console.Write("Idade mínima: ");
        if (int.TryParse(Console.ReadLine(), out int idadeMinima))
        {
            Console.Write("Idade máxima: ");
            if (int.TryParse(Console.ReadLine(), out int idadeMaxima))
            {
                List<Cliente> clientes = academia.ClientesEntreIdades(idadeMinima, idadeMaxima);

                Console.WriteLine("\nClientes entre as idades especificadas:");
                foreach (var cliente in clientes)
                {
                    Console.WriteLine($"{cliente.Nome} - Data de Nascimento: {cliente.DataNascimento.ToShortDateString()} - CPF: {cliente.CPF}");
                }
            }
            else
            {
                Console.WriteLine("Idade máxima inválida.");
            }
        }
        else
        {
            Console.WriteLine("Idade mínima inválida.");
        }
    }

    static void RelatorioClientesComIMCMaiorQue()
    {
        Console.Write("Valor do IMC mínimo: ");
        if (double.TryParse(Console.ReadLine(), out double valorMinimo))
        {
            List<Cliente> clientes = academia.ClientesComIMCMaiorQue(valorMinimo);

            Console.WriteLine("\nClientes com IMC maior que o valor especificado:");
            foreach (var cliente in clientes)
            {
                Console.WriteLine($"{cliente.Nome} - IMC: {cliente.CalcularIMC():F2}");
            }
        }
        else
        {
            Console.WriteLine("Valor do IMC inválido.");
        }
    }

    static void RelatorioClientesEmOrdemAlfabetica()
    {
        List<Cliente> clientes = academia.ClientesEmOrdemAlfabetica();

        Console.WriteLine("\nClientes em ordem alfabética:");
        foreach (var cliente in clientes)
        {
            Console.WriteLine($"{cliente.Nome} - Data de Nascimento: {cliente.DataNascimento.ToShortDateString()} - CPF: {cliente.CPF}");
        }
    }

    static void RelatorioClientesDoMaisVelhoParaOMaisNovo()
    {
        List<Cliente> clientes = academia.ClientesDoMaisVelhoParaOMaisNovo();

        Console.WriteLine("\nClientes do mais velho para o mais novo:");
        foreach (var cliente in clientes)
        {
            Console.WriteLine($"{cliente.Nome} - Data de Nascimento: {cliente.DataNascimento.ToShortDateString()} - CPF: {cliente.CPF}");
        }
    }

    static void RelatorioAniversariantesDoMes()
    {
        Console.Write("Número do mês (1 a 12): ");
        if (int.TryParse(Console.ReadLine(), out int mes))
        {
            List<Pessoa> aniversariantes = academia.AniversariantesDoMes(mes);

            Console.WriteLine($"\nAniversariantes do mês {mes}:");
            foreach (var pessoa in aniversariantes)
            {
                Console.WriteLine($"{pessoa.Nome} - Data de Nascimento: {pessoa.DataNascimento.ToShortDateString()}");
            }
        }
        else
        {
            Console.WriteLine("Número do mês inválido.");
        }
    }

    static void RelatorioTreinosPorDiasAteOVencimento()
    {
        List<Treino> treinosOrdenadosPorDias = academia.TreinosOrdenadosPorDiasAteOVencimento();

        Console.WriteLine("\nTreinos em ordem crescente pelos dias até o vencimento:");
        foreach (var treino in treinosOrdenadosPorDias)
        {
            Console.WriteLine($"{treino.Tipo} - Vencimento em dias: {treino.VencimentoDias}");
        }
    }

    static void RelatorioTreinadoresPorMediaDeNotas()
    {
        List<Treinador> treinadoresOrdenadosPorMedia = academia.TreinadoresOrdenadosPorMediaDeNotas();

        Console.WriteLine("\nTreinadores em ordem deescente da média de notas dos seus treinos:");
foreach (var treinador in treinadoresOrdenadosPorMedia)
{
Console.WriteLine($"{treinador.Nome} - Média de Notas: {treinador.CalcularMediaNotas():F2}");
}
}
static void RelatorioTreinosPorObjetivo()
{
    Console.Write("Palavra no Objetivo do Treino: ");
    string palavraChave = Console.ReadLine();

    List<Treino> treinosFiltrados = academia.TreinosPorObjetivoContendoPalavra(palavraChave);

    Console.WriteLine($"\nTreinos cujo objetivo contém '{palavraChave}':");
    foreach (var treino in treinosFiltrados)
    {
        Console.WriteLine($"{treino.Tipo} - Objetivo: {treino.Objetivo}");
    }
}

static void Top10ExerciciosMaisUtilizados()
{
    List<Exercicio> topExercicios = academia.Top10ExerciciosMaisUtilizados();

    Console.WriteLine("\nTop 10 exercícios mais utilizados nos treinos:");
    for (int i = 0; i < Math.Min(10, topExercicios.Count); i++)
    {
        Console.WriteLine($"{i + 1}. {topExercicios[i].GrupoMuscular} - {topExercicios[i].Nome}");
    }
}
}
