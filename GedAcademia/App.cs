using System.Globalization;

namespace GedAcademia;
public class GestaoDaAcademia
{
    public static List<Treinador> treinadores = new List<Treinador>();
    public static List<Cliente> clientes = new List<Cliente>();
    public static List<Treino> treinos = new List<Treino>();
    public List<Avaliacao> Avaliacoes { get; set; } = new List<Avaliacao>();
    private static List<string> crefsUtilizados = new List<string>();

    private static bool CREFUnico(string cref)
    {
        return !crefsUtilizados.Contains(cref);
    }

    public static void AdicionarTreinador()
    {
        Console.Write("Digite o nome do treinador: ");
        string? nomeTreinador = Console.ReadLine();

        DateTime dataNascimento;
        while (true)
        {
            Console.Write("Digite a data de nascimento (DD/MM/YYYY): ");
            string? dataNascTreinador = Console.ReadLine();

            if (DateTime.TryParse(dataNascTreinador, out dataNascimento))
            {
                break;
            }
            else
            {
                Console.WriteLine("O formato da data é inválido, digite um válido.");
            }
        }

        string? cpfTreinador = null;

        while (true)
        {
            Console.Write("Digite o CPF: ");
            string cpfInput = Console.ReadLine();

            // Remover caracteres não numéricos do CPF
            cpfTreinador = new string(cpfInput.Where(char.IsDigit).ToArray());

            // Validar o CPF
            if (Pessoa.ValidarCPF(cpfTreinador))
            {
                // CPF válido, sair do loop
                break;
            }
            else
            {
                Console.WriteLine("CPF inválido, digite um válido.");
            }
        }

        Console.Write("Digite o CREF: ");
        string? crefTreinador = Console.ReadLine();

        while (!CREFUnico(crefTreinador))
        {
            Console.WriteLine("CREF já utilizado, digite um válido.");
            Console.Write("Digite o CREF: ");
            crefTreinador = Console.ReadLine();
        }

        crefsUtilizados.Add(crefTreinador);


        try
        {
            Treinador treinador = new Treinador
            {
                Nome = nomeTreinador,
                DataNascimento = dataNascimento,
                CPF = cpfTreinador,
                CREF = crefTreinador
            };

            treinadores.Add(treinador);
            Console.WriteLine("Treinador adicionado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro: {ex.Message}");
        }

    }

    public static void AdicionarCliente()
    {
        Console.Write("Digite o nome do cliente: ");
        string? nomeCliente = Console.ReadLine();

        DateTime dataNascimento;
        while (true)
        {
            Console.Write("Digite a data de nascimento (DD/MM/YYYY): ");
            string? dataNascCliente = Console.ReadLine();

            if (DateTime.TryParse(dataNascCliente, out dataNascimento))
            {
                break;
            }
            else
            {
                Console.WriteLine("O formato da data é inválido, digite uma válido.");
            }
        }

        string? cpfCliente = null;

        while (true)
        {
            Console.Write("Digite o CPF: ");
            string cpfInput = Console.ReadLine();

            // Remover caracteres não numéricos do CPF
            cpfCliente = new string(cpfInput.Where(char.IsDigit).ToArray());

            // Validar o CPF
            if (Pessoa.ValidarCPF(cpfCliente))
            {
                // CPF válido, sair do loop
                break;
            }
            else
            {
                Console.WriteLine("CPF inválido, digite um válido.");
            }
        }

        Console.Write("Digite a altura do cliente em cm: ");
        int alturaCliente = Int32.Parse(Console.ReadLine());

        Console.Write("Digite o peso do cliente em kg: ");
        int pesoCliente = Int32.Parse(Console.ReadLine());

        try
        {
            Cliente cliente = new Cliente
            {
                Nome = nomeCliente,
                DataNascimento = dataNascimento,
                CPF = cpfCliente,
                AlturaCm = alturaCliente,
                PesoKg = pesoCliente
            };

            clientes.Add(cliente);
            Console.WriteLine("Cliente adicionado com sucesso!");
        }
        catch (FormatException)
        {
            Console.WriteLine("Formato de data inválido, digite um válido");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro: {ex.Message}");
        }
    }

    public static void ListarTreinadores()
    {
        Console.WriteLine("Lista de Treinadores:");
        Console.WriteLine();
        Console.WriteLine("{0,-35} {1,-20} {2,-20} {3,-15}", "Nome", "Data de Nascimento", "CPF", "CREF");
        Console.WriteLine(new string('=', 100));

        foreach (var treinador in treinadores)
        {
            Console.WriteLine("{0,-35} {1,-20} {2,-20} {3,-15}", treinador.Nome, treinador.DataNascimento.ToString("dd/MM/yyyy"), treinador.CPF, treinador.CREF);
            Console.WriteLine(new string('.', 100));
        }
    }

    public static void ListarClientes()
    {
        Console.WriteLine("Lista de Clientes:");
        Console.WriteLine();
        Console.WriteLine("{0,-35} {1,-20} {2,-20} {3,-12} {4,-10}", "Nome", "Data de Nascimento", "CPF", "Altura(cm)", "Peso(Kg)");
        Console.WriteLine(new string('=', 100));

        foreach (var cliente in clientes)
        {
            Console.WriteLine("{0,-35} {1,-20} {2,-20} {3,-12} {4,-10}", cliente.Nome, cliente.DataNascimento.ToString("dd/MM/yyyy"), cliente.CPF, cliente.AlturaCm, cliente.PesoKg);
            Console.WriteLine(new string('.', 100));
        }
    }



    public static void CriarTreino()
    {
        Treino treino = new Treino();

        Console.Write("Digite o tipo de treino: ");
        treino.Tipo = Console.ReadLine();

        Console.Write("Digite o objetivo do treino: ");
        treino.Objetivo = Console.ReadLine();

        Console.Write("Digite a duração estimada em minutos: ");
        treino.DuracaoEstimadaMinutos = int.Parse(Console.ReadLine());

        DateTime dataInicio;
        while (true)
        {
            Console.Write("Digite a data de início (DD/MM/YYYY): ");
            string? dataInicioStr = Console.ReadLine();

            if (DateTime.TryParseExact(dataInicioStr, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataInicio))
            {
                treino.DataInicio = dataInicio;
                break;
            }
            else
            {
                Console.WriteLine("Formato de data inválido. Tente novamente.");
            }
        }

        Console.Write("Digite o número de dias de vencimento: ");
        treino.VencimentoDias = int.Parse(Console.ReadLine());

        Console.Write("Digite o nome do treinador responsável: ");
        string? nomeTreinador = Console.ReadLine();
        Treinador? treinadorResponsavel = treinadores.Find(t => t.Nome == nomeTreinador);
        if (treinadorResponsavel != null)
        {
            treino.TreinadorResponsavel = treinadorResponsavel;
        }
        else
        {
            Console.WriteLine("Treinador não encontrado.");
            return;
        }

        // Adicionar treino à lista de treinos
        treinos.Add(treino);

        Console.WriteLine("Treino criado com sucesso!");

        // Perguntar se deseja adicionar exercícios ao treino recém-criado
        Console.Write("Deseja adicionar exercícios ao treino recém-criado? (S/N): ");
        string resposta = Console.ReadLine();

        if (resposta.ToUpper() == "S")
        {
            AdicionarExerciciosAoTreino(treino);
        }
    }

    public void AdicionarAvaliacao(Cliente cliente, int nota)
    {
        Avaliacoes.Add(new Avaliacao(cliente, nota));
    }

    public static void RealizarAvaliacao()
    {
        Console.Write("Digite o tipo do treino para realizar a avaliação: ");
        string? tipoTreino = Console.ReadLine();
        Treino? treino = treinos.Find(t => t.Tipo == tipoTreino);

        if (treino != null)
        {
            // Solicitar informações do cliente e nota
            Console.Write("Digite o nome do cliente para realizar a avaliação: ");
            string? nomeCliente = Console.ReadLine();

            Cliente? cliente = clientes.Find(c => c.Nome == nomeCliente);

            Console.Write("Digite a nota para avaliação do treino (entre 0 e 10): ");
            if (int.TryParse(Console.ReadLine(), out int nota) && nota >= 0 && nota <= 10)
            {
                // Adicionar a avaliação à lista de avaliações do treino
                if (cliente != null)
                {
                    treino.Avaliacoes.Add(new Avaliacao(cliente, nota));
                    Console.WriteLine($"Avaliação realizada com sucesso para {cliente.Nome}.");
                }
                else
                {
                    Console.WriteLine("Cliente não encontrado, mas a avaliação foi registrada.");
                }
            }
            else
            {
                Console.WriteLine("Nota inválida. A nota deve estar entre 0 e 10.");
            }
        }
        else
        {
            Console.WriteLine("Treino não encontrado.");
        }
    }

    public static void ExibirDetalhesTreino()
    {
        Console.Write("Digite o tipo do treino para exibir detalhes: ");
        string? tipoTreino = Console.ReadLine();
        Treino? treino = treinos.Find(t => t.Tipo == tipoTreino);

        if (treino != null)
        {
            ExibirDetalhesDoTreino(treino);
        }
        else
        {
            Console.WriteLine("Treino não encontrado.");
        }
    }

    public static void ExibirDetalhesDoTreino(Treino treino)
    {
        Console.WriteLine($"Detalhes do Treino '{treino.Tipo}':");
        Console.WriteLine($"Tipo: {treino.Tipo}");
        Console.WriteLine($"Objetivo: {treino.Objetivo}");
        Console.WriteLine($"Duração Estimada (minutos): {treino.DuracaoEstimadaMinutos}");
        Console.WriteLine($"Data de Início: {treino.DataInicio}");
        Console.WriteLine($"Vencimento (dias): {treino.VencimentoDias}");
        Console.WriteLine($"Treinador Responsável: {treino.TreinadorResponsavel.Nome}");

        Console.WriteLine("Exercícios:");

        if (treino.ListaExercicios != null && treino.ListaExercicios.Any())
        {
            foreach (var exercicio in treino.ListaExercicios)
            {
                Console.WriteLine("\nDetalhes do Exercício:");
                Console.WriteLine($"Grupo Muscular: {exercicio.GrupoMuscular}");
                Console.WriteLine($"Séries: {exercicio.Series}");
                Console.WriteLine($"Repetições: {exercicio.Repeticoes}");
                Console.WriteLine($"Tempo de Intervalo (segundos): {exercicio.TempoIntervaloSegundos}");
            }
        }
        else
        {
            Console.WriteLine("Nenhum exercício registrado.");
        }

        Console.WriteLine("\nAvaliações:");

        // if (treino.Avaliacoes != null && treino.Avaliacoes.Any())
        if (treino.Avaliacoes != null)
        {
            foreach (var avaliacao in treino.Avaliacoes)
            {
                Console.WriteLine($"{avaliacao.Cliente.Nome}: {avaliacao.Nota}");
            }
        }
        else
        {
            Console.WriteLine("Nenhuma avaliação registrada.");
        }
    }

    public static void AdicionarExerciciosAoTreino(Treino treino)
    {
        while (treino.ListaExercicios.Count < treino.LimiteExercicios)
        {
            Console.WriteLine("Adicionar Exercício ao Treino:");
            Exercicio exercicio = new Exercicio();

            Console.Write("Grupo Muscular: ");
            exercicio.GrupoMuscular = Console.ReadLine();

            Console.Write("Número de Séries: ");
            exercicio.Series = int.Parse(Console.ReadLine());

            Console.Write("Número de Repetições: ");
            exercicio.Repeticoes = int.Parse(Console.ReadLine());

            Console.Write("Tempo de Intervalo (segundos): ");
            exercicio.TempoIntervaloSegundos = int.Parse(Console.ReadLine());

            // Adicionar o exercício ao treino
            AdicionarExercicioAoTreino(treino, exercicio);

            Console.WriteLine(new string('=', 80));
            Console.Write("Deseja adicionar outro exercício? (S/N): ");
            string? resposta = Console.ReadLine();

            if (resposta?.ToUpper() != "S")
            {
                break;
            }
        }

        if (treino.ListaExercicios.Count >= treino.LimiteExercicios)
        {
            Console.WriteLine($"Limite de {treino.LimiteExercicios} exercícios atingido para o treino '{treino.Tipo}'.");
        }
    }

    public static void AdicionarExercicioAoTreino(Treino treino, Exercicio exercicio)
    {
        if (treino.ListaExercicios == null)
        {
            treino.ListaExercicios = new List<Exercicio>();
        }

        treino.ListaExercicios.Add(exercicio);

        Console.WriteLine($"Exercício adicionado ao treino '{treino.Tipo}'.");
    }
}
