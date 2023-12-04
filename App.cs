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
                        // GerarRelatorios();
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

    public static void AssociarTreino(){
        Console.WriteLine($"Para o cliente: {clientes[0].GetNome()}");
        Console.WriteLine($"Vamos associar o treino de: {treinos[0].GetTipo()}");
        //Antes de adicionar o treino verifico se o cliente ja possui 2 treinos ou não
        if(clientes[0].getTamanhoListTreino() >2){
            treinos[0].SetDataInicio(new DateTime(2023, 10,23));
            treinos[0].SetVencimento(10);
            clientes[0].setLitTreinos(treinos[0]);
        }

        /* 
            Testando adicionar um treino para um cliente que já posui 2 treinos
         */
        
    }
}
