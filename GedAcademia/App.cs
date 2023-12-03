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
                Console.WriteLine("O formato da data é inválido. Tente novamente.");
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
                Console.WriteLine("CPF inválido. Digite um CPF válido.");
            }
        }

        Console.Write("Digite o CREF: ");
        string? crefTreinador = Console.ReadLine();

        // Verificar se o CREF é único
        if (CREFUnico(crefTreinador))
        {
            crefsUtilizados.Add(crefTreinador);
        }
        else
        {
            Console.WriteLine("CREF já utilizado. Digite um CREF único.");
            return;
        }

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
                Console.WriteLine("O formato da data é inválido. Tente novamente.");
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
                Console.WriteLine("CPF inválido. Digite um CPF válido.");
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
            Console.WriteLine("Formato de data inválido.");
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
        }
        Console.WriteLine(new string('.', 100));
    }

    public static void ListarClientes()
    {
        Console.WriteLine("Lista de Clientes:");
        Console.WriteLine();
        Console.WriteLine("{0,-35} {1,-20} {2,-20} {3,-20} {4,-15}", "Nome", "Data de Nascimento", "CPF", "Altura(cm)", "Peso(Kg)");
        Console.WriteLine(new string('=', 100));

        foreach (var cliente in clientes)
        {
            Console.WriteLine("{0,-35} {1,-20} {2,-20} {3,-20} {4,-15}", cliente.Nome, cliente.DataNascimento.ToString("dd/MM/yyyy"), cliente.CPF, cliente.AlturaCm, cliente.PesoKg);
        }
        Console.WriteLine(new string('.', 100));
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

            Console.Write("Digite a nota da avaliação (entre 0 e 10): ");
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
        while (true)
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

            Console.Write("Deseja adicionar outro exercício? (S/N): ");
            string? resposta = Console.ReadLine();

            if (resposta.ToUpper() != "S")
            {
                break;
            }
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

    // public static void SalvarDados()
    // {
    //     SalvarTreinadores();
    //     SalvarClientes();
    //     SalvarTreinos();
    //     SalvarExercicios();
    //     SalvarAvaliacoes();
    // }

    // public static void CarregarDados()
    // {
    //     CarregarTreinadores();
    //     CarregarClientes();
    //     CarregarTreinos();
    //     CarregarExercicios();
    //     CarregarAvaliacoes();
    // }

    // private static void SalvarTreinadores()
    // {
    //     string filePath = "treinadores.txt";

    //     using (StreamWriter writer = new StreamWriter(filePath))
    //     {
    //         foreach (var treinador in treinadores)
    //         {
    //             writer.WriteLine($"{treinador.Nome},{treinador.DataNascimento},{treinador.CPF},{treinador.CREF}");
    //         }
    //     }
    // }

    // private static void CarregarTreinadores()
    // {
    //     string filePath = "treinadores.txt";

    //     if (File.Exists(filePath))
    //     {
    //         treinadores.Clear();

    //         using (StreamReader reader = new StreamReader(filePath))
    //         {
    //             string line;
    //             while ((line = reader.ReadLine()) != null)
    //             {
    //                 string[] parts = line.Split(',');
    //                 if (parts.Length == 4)
    //                 {
    //                     Treinador treinador = new Treinador
    //                     {
    //                         Nome = parts[0],
    //                         DataNascimento = DateTime.Parse(parts[1]),
    //                         CPF = parts[2],
    //                         CREF = parts[3]
    //                     };
    //                     treinadores.Add(treinador);
    //                 }
    //             }
    //         }
    //     }
    // }

    // private static void SalvarClientes()
    // {
    //     string filePath = "clientes.txt";

    //     using (StreamWriter writer = new StreamWriter(filePath))
    //     {
    //         foreach (var cliente in clientes)
    //         {
    //             writer.WriteLine($"{cliente.Nome},{cliente.DataNascimento},{cliente.CPF},{cliente.AlturaCm},{cliente.PesoKg}");
    //         }
    //     }
    // }

    // private static void CarregarClientes()
    // {
    //     string filePath = "clientes.txt";

    //     if (File.Exists(filePath))
    //     {
    //         clientes.Clear();

    //         using (StreamReader reader = new StreamReader(filePath))
    //         {
    //             string line;
    //             while ((line = reader.ReadLine()) != null)
    //             {
    //                 string[] parts = line.Split(',');
    //                 if (parts.Length == 5)
    //                 {
    //                     Cliente cliente = new Cliente
    //                     {
    //                         Nome = parts[0],
    //                         DataNascimento = DateTime.Parse(parts[1]),
    //                         CPF = parts[2],
    //                         AlturaCm = int.Parse(parts[3]),
    //                         PesoKg = int.Parse(parts[4])
    //                     };
    //                     clientes.Add(cliente);
    //                 }
    //             }
    //         }
    //     }
    // }


    // private static void SalvarTreinos()
    // {
    //     string filePath = "treinos.txt";

    //     using (StreamWriter writer = new StreamWriter(filePath))
    //     {
    //         foreach (var treino in treinos)
    //         {
    //             // Escrever os dados do treino no formato desejado
    //             writer.WriteLine($"{treino.Tipo},{treino.Objetivo},{treino.DuracaoEstimadaMinutos},{treino.DataInicio},{treino.VencimentoDias},{treino.TreinadorResponsavel.Nome}");
    //         }
    //     }
    // }

    // private static void CarregarTreinos()
    // {
    //     string filePath = "treinos.txt";

    //     if (File.Exists(filePath))
    //     {
    //         treinos.Clear();

    //         using (StreamReader reader = new StreamReader(filePath))
    //         {
    //             string line;
    //             while ((line = reader.ReadLine()) != null)
    //             {
    //                 string[] parts = line.Split(',');
    //                 if (parts.Length == 6)
    //                 {
    //                     Treino treino = new Treino
    //                     {
    //                         Tipo = parts[0],
    //                         Objetivo = parts[1],
    //                         DuracaoEstimadaMinutos = int.Parse(parts[2]),
    //                         DataInicio = DateTime.Parse(parts[3]),
    //                         VencimentoDias = int.Parse(parts[4]),
    //                         TreinadorResponsavel = treinadores.Find(t => t.Nome == parts[5])
    //                     };
    //                     treinos.Add(treino);
    //                 }
    //             }
    //         }
    //     }
    // }

    // private static void SalvarExercicios()
    // {
    //     string filePath = "exercicios.txt";

    //     using (StreamWriter writer = new StreamWriter(filePath))
    //     {
    //         foreach (var treino in treinos)
    //         {
    //             if (treino.ListaExercicios != null)
    //             {
    //                 foreach (var exercicio in treino.ListaExercicios)
    //                 {
    //                     // Escrever os dados do exercício no formato desejado
    //                     writer.WriteLine($"{treino.Tipo},{exercicio.GrupoMuscular},{exercicio.Series},{exercicio.Repeticoes},{exercicio.TempoIntervaloSegundos}");
    //                 }
    //             }
    //         }
    //     }
    // }

    // private static void CarregarExercicios()
    // {
    //     string filePath = "exercicios.txt";

    //     if (File.Exists(filePath))
    //     {
    //         foreach (var treino in treinos)
    //         {
    //             treino.ListaExercicios = new List<Exercicio>();
    //         }

    //         using (StreamReader reader = new StreamReader(filePath))
    //         {
    //             string line;
    //             while ((line = reader.ReadLine()) != null)
    //             {
    //                 string[] parts = line.Split(',');
    //                 if (parts.Length == 5)
    //                 {
    //                     Exercicio exercicio = new Exercicio
    //                     {
    //                         GrupoMuscular = parts[1],
    //                         Series = int.Parse(parts[2]),
    //                         Repeticoes = int.Parse(parts[3]),
    //                         TempoIntervaloSegundos = int.Parse(parts[4])
    //                     };

    //                     // Encontrar o treino associado ao exercício
    //                     Treino treino = treinos.Find(t => t.Tipo == parts[0]);
    //                     if (treino != null)
    //                     {
    //                         treino.ListaExercicios.Add(exercicio);
    //                     }
    //                 }
    //             }
    //         }
    //     }
    // }

    // private static void SalvarAvaliacoes()
    // {
    //     string filePath = "avaliacoes.txt";

    //     using (StreamWriter writer = new StreamWriter(filePath))
    //     {
    //         foreach (var treino in treinos)
    //         {
    //             if (treino.Avaliacoes != null)
    //             {
    //                 foreach (var avaliacao in treino.Avaliacoes)
    //                 {
    //                     // Escrever os dados da avaliação no formato desejado
    //                     writer.WriteLine($"{treino.Tipo},{avaliacao.Cliente.Nome},{avaliacao.Nota}");
    //                 }
    //             }
    //         }
    //     }
    // }

    // private static void CarregarAvaliacoes()
    // {
    //     string filePath = "avaliacoes.txt";

    //     if (File.Exists(filePath))
    //     {
    //         foreach (var treino in treinos)
    //         {
    //             treino.Avaliacoes = new List<Avaliacao>();
    //         }

    //         using (StreamReader reader = new StreamReader(filePath))
    //         {
    //             string line;
    //             while ((line = reader.ReadLine()) != null)
    //             {
    //                 string[] parts = line.Split(',');
    //                 if (parts.Length == 3)
    //                 {
    //                     // Encontrar o treino associado à avaliação
    //                     Treino treino = treinos.Find(t => t.Tipo == parts[0]);
    //                     if (treino != null)
    //                     {
    //                         Cliente cliente = clientes.Find(c => c.Nome == parts[1]);
    //                         if (cliente != null)
    //                         {
    //                             int nota = int.Parse(parts[2]);
    //                             treino.Avaliacoes.Add(new Avaliacao(cliente, nota));
    //                         }
    //                     }
    //                 }
    //             }
    //         }
    //     }
    // }
}
