using System;

namespace GedAcademia
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string opcao;

            Console.WriteLine("[SISTEMA DE GERENCIAMENTO DE ESTOQUE]");
            Console.WriteLine("=====================================");
            Console.WriteLine();
            do
            {
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine();
                Console.WriteLine("1.  CADASTRAR CLIENTES ");
                Console.WriteLine("2.  CADASTRAR TREINADORES");
                //Console.WriteLine("3.  RELATÓRIOS");
                // Console.WriteLine("4.  LISTAGEM DE TREINADORES ");
                // Console.WriteLine("5.  RELATÓRIO DE QUANTIDADE ABAIXO ");
                // Console.WriteLine("6.  RELATÓRIO DE VALORES MIN/MAX ");
                // Console.WriteLine("7.  RELATÓRIO DE VALORES TOTAIS  ");
                Console.WriteLine("0.  SAIR   ");
                Console.WriteLine();

                Console.Write("Opção: ");

                if (int.TryParse(Console.ReadLine(), out int escolha))
                {
                    switch (escolha)
                    {
                        case 1:
                            Console.WriteLine();
                            var clienteInfo = GestaoDaAcademia.CapturarDadosCliente();
                            GestaoDaAcademia.CadastrarCliente(clienteInfo);
                            Console.WriteLine();
                            break;

                        case 2:
                            Console.WriteLine();
                            var treinadorInfo = GestaoDaAcademia.CapturarDadosTreinador();
                            GestaoDaAcademia.CadastrarTreinador(treinadorInfo);
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
}