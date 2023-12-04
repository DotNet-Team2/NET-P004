namespace GedAcademia;
public class Program
{
    public static void Main()
    {
        string opcao;

        Console.WriteLine("[SISTEMA DE GERENCIAMENTO DE ACADEMIA]");
        Console.WriteLine("=====================================");
        Console.WriteLine();
        do
        {
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine();
            Console.WriteLine("1.  CADASTRAR TREINADORES");
            Console.WriteLine("2.  CADASTRAR CLIENTES");
            Console.WriteLine("3.  LISTAGEM DOS TREINADORES");
            Console.WriteLine("4.  LISTAGEM DOS CLIENTES");
            Console.WriteLine("5.  CRIAR TREINO ");
            Console.WriteLine("6.  REALIZAR AVALIAÇÃO");
            Console.WriteLine("7.  EXIBIR DETALHES DO TREINO");
            Console.WriteLine("8.  RELATÓRIOS DA IDADE DOS TREINADORES ENTRE DOIS VALORES");
            Console.WriteLine("9.  RELATÓRIOS DA IDADE DOS CLIENTES ENTRE DOIS VALORES");
            Console.WriteLine("10. RELATÓRIO DO IMC DOS CLIENTES EM ORDEM CRESCENTE");
            Console.WriteLine("11. RELATÓRIO DOS CLIENTES EM ORDEM ALFABÉTICA");
            Console.WriteLine("12. RELATÓRIO DOS CLIENTES MAIS VELHOS PARA O MAIS NOVO");
            Console.WriteLine("13. RELATÓRIO DOS TREINADORES E CLIENTES ANIVERSARIANTES DO MÊS INFORMADO");
            Console.WriteLine("14. RELATÓRIO DOS TREINOS EM ORDEM CRESCENTE PELA QUANTIDADE DE DIAS ATÉ O VENCIMENTO");
            Console.WriteLine("15. RELATÓRIO DOS TREINADORES EM ORDEM DECRESCENTE DA MÉDIA DE NOTAS DOS SEUS TREINOS");
            Console.WriteLine("16. RELATÓRIO DOS TREINOS CUJO OBJETIVO CONTENHAM DETERMINADA PALAVRA");
            Console.WriteLine("17. RELATÓRIO DO TOP 10 DOS EXERCÍCIOS MAIS UTILIZADOS NOS TREINOS.");
            Console.WriteLine("0. SAIR ");
            Console.WriteLine();

            Console.Write("Opção: ");

            if (int.TryParse(Console.ReadLine(), out int escolha))
            {
                switch (escolha)
                {
                    case 1:
                        Console.WriteLine();
                        GestaoDaAcademia.AdicionarTreinador();
                        Console.WriteLine();
                        break;

                    case 2:
                        Console.WriteLine();
                        GestaoDaAcademia.AdicionarCliente();
                        Console.WriteLine();
                        break;

                    case 3:
                        Console.WriteLine();
                        GestaoDaAcademia.ListarTreinadores();
                        Console.WriteLine();
                        break;

                    case 4:
                        Console.WriteLine();
                        GestaoDaAcademia.ListarClientes();
                        Console.WriteLine();
                        break;

                    case 5:
                        Console.WriteLine();
                        GestaoDaAcademia.CriarTreino();
                        Console.WriteLine();
                        break;

                    case 6:
                        Console.WriteLine();
                        GestaoDaAcademia.RealizarAvaliacao();
                        Console.WriteLine();
                        break;

                    case 7:
                        Console.WriteLine();
                        GestaoDaAcademia.ExibirDetalhesTreino();
                        Console.WriteLine();
                        break;

                    case 8:
                        Console.WriteLine();
                        GestaoDaAcademia.RelIdadeEntreMinMaxTreinador();
                        Console.WriteLine();
                        break;

                    case 9:
                        Console.WriteLine();
                        GestaoDaAcademia.RelIdadeEntreMinMaxClientes();
                        Console.WriteLine();
                        break;

                    case 10:
                        Console.WriteLine();
                        GestaoDaAcademia.RelatorioClientesIMC();
                        Console.WriteLine();
                        break;

                    case 11:
                        Console.WriteLine();
                        GestaoDaAcademia.RelClientesOrdemAlfabetica();
                        Console.WriteLine();
                        break;

                    case 12:
                        Console.WriteLine();
                        GestaoDaAcademia.RelIdadeClientesOrdenados();
                        Console.WriteLine();
                        break;

                    case 13:
                        Console.WriteLine();
                        GestaoDaAcademia.RelAniversariantesPorMes();
                        Console.WriteLine();
                        break;

                    case 14:
                        Console.WriteLine();
                        GestaoDaAcademia.RelTreinosPorQuantVencOrdem();
                        Console.WriteLine();
                        break;

                    case 15:
                        Console.WriteLine();
                        GestaoDaAcademia.RelMediaNotasTreinadores();
                        Console.WriteLine();
                        break;

                    case 16:
                        Console.WriteLine();
                        GestaoDaAcademia.RelTreinosPorObjPalavra();
                        Console.WriteLine();
                        break;

                    case 17:
                        Console.WriteLine();
                        GestaoDaAcademia.RelTop10ExerMaisUtilizados();
                        Console.WriteLine();
                        break;

                    case 0:
                        Console.WriteLine("Saindo do programa.");
                        Console.WriteLine();
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        Console.WriteLine();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opção inválida.");
            }

            Console.WriteLine("Deseja continuar: [s/n]");
            opcao = Console.ReadLine();
        } while (opcao.ToLower() == "s");
    }
}
