using System.Linq;

namespace _NET_P004;

public static class App
{
    private static List<Treinador> treinadores = new List<Treinador>();
    private static List<Cliente> clientes = new List<Cliente>();
    private static List<Exercicios> exercicios = new List<Exercicios>();
    private static List<Treino> treinos = new List<Treino>();

    public static void Menu()
    {
        int opcao = -1;
        do
        {
            Console.WriteLine(">>>> MENU DA APLICACAO <<<");
            Console.WriteLine("[1] CADASTRAR TREINADOR");
            Console.WriteLine("[2] CADASTRAR CLIENTE");
            Console.WriteLine("[3] CADASTRAR TREINO");
            Console.WriteLine("[4] CADASTRAR EXERCICIOS");
            Console.WriteLine("[5] ASSOCIAR TREINO PARA UM CLIENTE");
            Console.WriteLine("[6] GERAR RELATORIOS");
            Console.WriteLine("[0] SAIR");
            try
            {
                // Tenta converter a entrada para um número inteiro
                opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        CadastroTreinador();
                        break;

                    case 2:
                        CadastroCliente();
                        break;

                    case 3:
                        CadastradoTreino();
                        break;

                    case 4:
                        CadastradoExercicio();
                        break;

                    case 5:
                        AssociarTreino();
                        break;

                    case 6:
                        GeraRelatorios();
                        break;

                    case 0:
                        break;

                    default:
                        Console.WriteLine("Opcao invalida");
                        break;

                }
            }
            catch (FormatException)
            {
                // Captura a exceção FormatException se a entrada não puder ser convertida para decimal
                Console.WriteLine("Entrada inválida. Certifique-se de digitar um número decimal.");
            }
            catch (OverflowException)
            {
                // Captura a exceção OverflowException se a entrada for muito grande para ser armazenada em um decimal
                Console.WriteLine("Entrada inválida. O número é muito grande.");
            }
            catch (Exception ex)
            {
                // Captura outras exceções não tratadas
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
            }

        } while (opcao != 0);
    }

    public static void CadastroTreinador()
    {
        string cpf1 = "00000000000";
        string cref1 = "01";
        DateTime d1 = new DateTime(1999, 12, 20);
        if (VerificaCpf(cpf1, treinadores))
        {
            if (VerificaCref(cref1))
            {
                Treinador t1 = new Treinador("Zequinha", d1, cpf1, cref1);
                treinadores.Add(t1);
            }

        }

        string cpf2 = "00000000001";
        string cref2 = "02";
        DateTime d2 = new DateTime(2000, 12, 20);
        if (VerificaCpf(cpf2, treinadores))
        {
            if (VerificaCref(cref2))
            {
                Treinador t2 = new Treinador("Ze da Manga", d2, cpf2, cref2);
                treinadores.Add(t2);
            }
        }
    }
    public static void CadastroCliente()
    {
        string cpf1 = "00000000000";

        if (VerificaCpf(cpf1, clientes))
        {
            Cliente c1 = new Cliente("João", new DateTime(1999, 02, 15), cpf1, 50, 70);
            clientes.Add(c1);
        }

        string cpf2 = "00000000001";
        if (VerificaCpf(cpf2, clientes))
        {
            Cliente c2 = new Cliente("Maria", new DateTime(1985, 12, 22), cpf2, 95, 60);
            clientes.Add(c2);
        }

        // Console.WriteLine($"Tamanho de clientes {clientes.Count}");
    }

    public static bool VerificaCref(string cref)
    {
        if (string.IsNullOrWhiteSpace(cref))
        {
            throw new ArgumentException("O CREF não pode ser nulo ou vazio.");
        }

        //verifica se não existe outro cpf já cadastrado
        foreach (var treinador in treinadores)
        {
            if (treinador.GetCref().Equals(cref))
            {
                Console.WriteLine($"CREF {cref} já Cadastrado!");
                return false;
            }
        }

        return true;
    }
    public static bool VerificaCpf<T>(string cpf, List<T> pessoas) where T : Pessoa
    {
        if (string.IsNullOrWhiteSpace(cpf))
        {
            throw new ArgumentException("O CPF ou CREF não pode ser nulo ou vazio.");
        }

        // Verifica se é um CPF válido
        if (cpf.Length == 11)
        {
            //verifica se não existe outro cpf já cadastrado
            foreach (var pessoa in pessoas)
            {
                if (pessoa.GetCpf().Equals(cpf))
                {
                    Console.WriteLine($"CPF {cpf} já Cadastrado!");
                    return false;
                }
            }
        }
        else
        {
            Console.WriteLine($"CPF {cpf} com nenos de 11 digitos!");
            return false;
        }

        return true;
    }

    public static void CadastradoTreino()
    {
        if (exercicios.Count <= 10)
        {
            Treino t1 = new Treino("Perna", "Tonificar", exercicios, 60, new DateTime(1992, 10, 2), 5, treinadores[0]);
            treinos.Add(t1);
        }

        if (exercicios.Count <= 10)
        {
            Treino t2 = new Treino("Costas", "Modificar", exercicios, 70, new DateTime(1992, 12, 2), 10, treinadores[1]);
            treinos.Add(t2);
        }

        // Console.WriteLine($"Tamanho de treino: {treinos.Count}");

    }

    public static void CadastradoExercicio()
    {
        Exercicios ex1 = new Exercicios("Pernas", 15, 5, 10);
        Exercicios ex2 = new Exercicios("Braços", 12, 8, 15);
        Exercicios ex3 = new Exercicios("Peito", 10, 10, 12);
        Exercicios ex4 = new Exercicios("Costas", 12, 8, 15);
        Exercicios ex5 = new Exercicios("Abdominais", 20, 3, 20);
        Exercicios ex6 = new Exercicios("Ombros", 10, 12, 10);
        Exercicios ex7 = new Exercicios("Tríceps", 12, 8, 15);
        Exercicios ex8 = new Exercicios("Bíceps", 12, 8, 15);
        Exercicios ex9 = new Exercicios("Cardio", 1, 30, 0);
        Exercicios ex10 = new Exercicios("Cordão de Aquiles", 1, 30, 0);

        // Adicionar os exercicios à lista de exercicios
        exercicios.Add(ex1);
        exercicios.Add(ex2);
        exercicios.Add(ex3);
        exercicios.Add(ex4);
        exercicios.Add(ex5);
        exercicios.Add(ex6);
        exercicios.Add(ex7);
        exercicios.Add(ex8);
        exercicios.Add(ex9);
        exercicios.Add(ex10);

        //Console.WriteLine($"Tamanho de exercicios: {exercicios.Count}");
    }

    public static void AssociarTreino()
    {
        Console.WriteLine($"Para o cliente: {clientes[0].GetNome()}");
        Console.WriteLine($"Vamos associar o treino de: {treinos[0].GetTipo()}");
        //Antes de adicionar o treino verifico se o cliente ja possui 2 treinos ou não
        if (clientes[0].getTamanhoListTreino() < 2)
        {
            treinos[0].SetDataInicio(new DateTime(2023, 10, 23));
            treinos[0].SetVencimento(10);
            clientes[0].setLitTreinos(treinos[0]);
        }
        else
        {
            Console.WriteLine($"{clientes[0].GetNome()} atingiu o numero maximo de treinos");
        }
        Console.WriteLine();

        /* 
            Testando adicionar um treino para um cliente que já posui 2 treinos
         */
        Console.WriteLine($"Para o cliente: {clientes[1].GetNome()}");
        Console.WriteLine($"Vamos associar o treino de: {treinos[0].GetTipo()}");
        Console.WriteLine($"Vamos associar o treino de: {treinos[1].GetTipo()}");

        treinos[0].SetDataInicio(new DateTime(2023, 10, 23));
        treinos[0].SetVencimento(10);
        clientes[1].setLitTreinos(treinos[0]);

        treinos[1].SetDataInicio(new DateTime(2023, 2, 23));
        treinos[1].SetVencimento(10);
        clientes[1].setLitTreinos(treinos[1]);

        if (clientes[1].getTamanhoListTreino() < 2)
        {
            treinos[0].SetDataInicio(new DateTime(2023, 10, 23));
            treinos[0].SetVencimento(10);
            clientes[1].setLitTreinos(treinos[0]);
        }
        else
        {
            Console.WriteLine($"{clientes[1].GetNome()} atingiu o numero maximo de treinos");
        }

        /* Avalidando treinos */
        treinos[0].AdicionarAvaliacaoCliente(clientes[0], 10);
        treinos[0].AdicionarAvaliacaoCliente(clientes[1], 5);

        treinos[1].AdicionarAvaliacaoCliente(clientes[1], 10);
        treinos[1].AdicionarAvaliacaoCliente(clientes[0], 9);

    }

    public static void GeraRelatorios()
    {
        DateTime hoje = DateTime.Today;
        int mesAtual = 12;

        // 1. Treinadores com idade entre dois valores
        var treinadoresIdade = GetTreinadoresComIdadeEntre(10, 30);
        Console.WriteLine($">>> Treinadores com idades entre {10} e {30}");
        ImprimirRelatorioTreinador(treinadoresIdade);

        // 2. Clientes com idade entre dois valores
        var clientesIdade = GetClientesComIdadeEntre(10, 30);
        Console.WriteLine($">>> Clientes com idades entre {10} e {30}");
        ImprimirRelatorioCliente(clientesIdade);

        // 3. Clientes com IMC maior que um valor, em ordem crescente
        var clientesIMC = GetClientesComIMCMaiorQue(25)
            .OrderBy(c => c.IMC());
        Console.WriteLine($">>> Clientes com Imc maior que {25}");
        ImprimirRelatorioCliente(clientesIMC);

        // 4. Clientes em ordem alfabética
        var clientesOrdenados = GetClientesOrdenadosPorNome();
        Console.WriteLine($">>> Clientes Ordenados");
        ImprimirRelatorioCliente(clientesOrdenados);

        // 5. Clientes do mais velho para mais novo
        Console.WriteLine($">>> Clientes do mais velho ao mais novo");
        var clientesMaisVelhos = GetClientesOrdenadosPorIdade(false);
        ImprimirRelatorioCliente(clientesMaisVelhos);

        // 6. Treinadores e clientes aniversariantes do mês informado
        var aniversariantesDoMesTreinadores = GetAniversariantesTreinadoresDoMes(mesAtual);
        Console.WriteLine($">>> Aniversariantes do mes Treinadores: ");
        ImprimirRelatorioTreinador(aniversariantesDoMesTreinadores);

        var aniversariantesDoMesClientes = GetAniversariantesClientesDoMes(mesAtual);
        Console.WriteLine($">>> Aniversariantes do mes Clientes: ");
        ImprimirRelatorioCliente(aniversariantesDoMesClientes);

        //7. Treinos em ordem crescente pela quantidade de dias até o vencimento.
        var treinosEmOrdem = TreinosEmOrdemCrescentePorDiasAteVencimento(treinos);
        Console.WriteLine($">>> Treinos em ordem crescente pela quantidade de dias até o vencimento: ");
        ImprimirRelatorioTreino(treinosEmOrdem);

        //8. Treinadores em ordem decrescente da média de notas dos seus treinos
        var treinadoresEmOrdem = TreinadoresEmOrdemDecrescentePorMediaNotas(treinos);
        Console.WriteLine($">>> Treinadores em ordem decrescente da média de notas dos seus treinos: ");
        ImprimirRelatorioTreinador(treinadoresEmOrdem);

        //9. Treinos cujo objetivo contenham determinada palavra
        var treinoEspecifico = TreinosComObjetivoContendoPalavra(treinos, "Perna");
        Console.WriteLine($">>> Treinos cujo objetivo contenham determinada palavra: ");
        ImprimirRelatorioTreino(treinoEspecifico);

        //10. Top 10 exercícios mais utilizados nos treinos.
        var topExercicios = Top10ExerciciosMaisUtilizados(treinos);
        Console.WriteLine($">>> Top 10 exercícios mais utilizados nos treinos.: ");
        ImprimirRelatorioExercicios(topExercicios);
    }

    public static List<Treinador> TreinadoresComIdadeEntre(List<Treinador> treinadores, int idadeMinima, int idadeMaxima)
    {
        DateTime hoje = DateTime.Today;
        return treinadores.Where(t => (hoje.Year - t.GetDataNascimento().Year) >= idadeMinima &&
                                       (hoje.Year - t.GetDataNascimento().Year) <= idadeMaxima).ToList();
    }

    /* Aaqui */
    public static IEnumerable<Treinador> GetTreinadoresComIdadeEntre(int idadeMinima, int idadeMaxima)
    {
        return treinadores.Where(t => t.Idade() >= idadeMinima && t.Idade() <= idadeMaxima);
    }

    public static IEnumerable<Cliente> GetClientesComIdadeEntre(int idadeMinima, int idadeMaxima)
    {
        return clientes.Where(c => c.Idade() >= idadeMinima && c.Idade() <= idadeMaxima);
    }

    public static IEnumerable<Cliente> GetClientesComIMCMaiorQue(double imcMinimo)
    {
        return clientes.Where(c => c.IMC() > imcMinimo);
    }

    public static IEnumerable<Cliente> GetClientesOrdenadosPorNome()
    {
        return clientes.OrderBy(c => c.GetNome());
    }

    public static IEnumerable<Cliente> GetClientesOrdenadosPorIdade(bool crescente = true)
    {
        return crescente
            ? clientes.OrderBy(c => c.Idade())
            : clientes.OrderByDescending(c => c.Idade());
    }

    private static void ImprimirRelatorioTreinador(IEnumerable<Treinador> treinadores)
    {

        foreach (var treinador in treinadores)
        {
            Console.WriteLine($"Nome: {treinador.GetNome()}");
            Console.WriteLine($"Data de Nascimento: {treinador.GetDataNascimento()}");
            Console.WriteLine($"Idade: {treinador.Idade()}");
            Console.WriteLine($"CPF: {treinador.GetCpf()}");
            Console.WriteLine($"CREF: {treinador.GetCref()}");
            Console.WriteLine("---------------------------");
        }
    }

    private static void ImprimirRelatorioTreino(IEnumerable<Treino> treinos)
    {

        foreach (var treino in treinos)
        {
            Console.WriteLine($"Tipo: {treino.GetTipo()}");
            Console.WriteLine($"Objetivo: {treino.GetObjetivo()}");
            Console.WriteLine($"Duracao: {treino.GetDuracao()}");
            Console.WriteLine($"Data Inicio: {treino.GetDataInicio()}");
            Console.WriteLine($"Vencimento: {treino.GetVencimento()}");
            Console.WriteLine($"Treinador: {treino.GetTreinador().GetNome()}");
            Console.WriteLine("---------------------------");
        }
    }

    private static void ImprimirRelatorioCliente(IEnumerable<Cliente> clientes)
    {

        foreach (var cliente in clientes)
        {
            Console.WriteLine($"Nome: {cliente.GetNome()}");
            Console.WriteLine($"Data de Nascimento: {cliente.GetDataNascimento()}");
            Console.WriteLine($"Idade: {cliente.Idade()}");
            Console.WriteLine($"CPF: {cliente.GetCpf()}");
            Console.WriteLine($"Peso: {cliente.GetPeso()}");
            Console.WriteLine($"Altura: {cliente.GetAltura()}");
            Console.WriteLine("---------------------------");
        }
    }

    private static void ImprimirRelatorioExercicios(IEnumerable<Exercicios> exercicios)
    {

        foreach (var exercicio in exercicios)
        {
            Console.WriteLine($"Grupo Muscular: {exercicio.GetGrupoMuscular()}");
            Console.WriteLine($"Series: {exercicio.GetSeries()}");
            Console.WriteLine($"Repeticoes: {exercicio.GetRepeticoes()}");
            Console.WriteLine($"Intervalos: {exercicio.GetIntervalos()}");
            Console.WriteLine("---------------------------");
        }
    }

    public static IEnumerable<Treinador> GetAniversariantesTreinadoresDoMes(int mes)
    {
        return treinadores
            .Where(t => t.GetDataNascimento().Month == mes)
            .OrderBy(t => t.GetDataNascimento());
    }

    public static IEnumerable<Cliente> GetAniversariantesClientesDoMes(int mes)
    {
        return clientes
            .Where(t => t.GetDataNascimento().Month == mes)
            .OrderBy(t => t.GetDataNascimento());
    }
    /* Parei */

    public static List<Treino> TreinosEmOrdemCrescentePorDiasAteVencimento(List<Treino> treinos)
    {
        DateTime hoje = DateTime.Today;
        return treinos.OrderBy(t => (t.GetDataInicio() + TimeSpan.FromDays(t.GetVencimento()) - hoje).Days).ToList();
    }

    public static List<Treinador> TreinadoresEmOrdemDecrescentePorMediaNotas(List<Treino> treinos)
    {
        return treinos
        .GroupBy(t => t.GetTreinador()) // Agrupa os treinos por treinador
        .Select(g => new
        {
            Treinador = g.Key,
            MediaNotas = g.Average(tr => CalcularNotaTreino(tr))
        })
        .OrderByDescending(g => g.MediaNotas)
        .Select(g => g.Treinador)
        .ToList();
    }

    private static double CalcularNotaTreino(Treino treino)
    {
        double mediaNotas = 0.0;

        if (treino.ObterAvaliacoesClientes().Count > 0)
        {
            mediaNotas = treino.ObterAvaliacoesClientes().Average(a => a.Item2.GetValueOrDefault());
        }

        return mediaNotas;
    }
    public static List<Treino> TreinosComObjetivoContendoPalavra(List<Treino> treinos, string palavra)
    {
        return treinos.Where(t => t.GetTipo().Contains(palavra)).ToList();
    }
    public static List<Exercicios> Top10ExerciciosMaisUtilizados(List<Treino> treinos)
    {
        Dictionary<string, int> exerciciosContagem = new Dictionary<string, int>();

        foreach (var treino in treinos)
        {
            foreach (var exercicio in treino.GetExercicios())
            {
                if (exerciciosContagem.ContainsKey(exercicio.GetGrupoMuscular()))
                {
                    exerciciosContagem[exercicio.GetGrupoMuscular()]++;
                }
                else
                {
                    exerciciosContagem[exercicio.GetGrupoMuscular()] = 1;
                }
            }
        }

        return exerciciosContagem.OrderByDescending(kv => kv.Value)
                                .Take(10)
                                .Select(kv => new Exercicios(kv.Key, 0, 0, 0)) // Criar novos objetos Exercicios com os dados necessários
                                .ToList();
    }

}
