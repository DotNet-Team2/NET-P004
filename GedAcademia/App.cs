using System;
using System.Collections.Generic;

namespace GedAcademia
{
    public static class GestaoDaAcademia
    {
        private static List<Cliente> ListaDeClientes { get; } = new List<Cliente>();
        private static List<Treinador> ListaDeTreinadores { get; } = new List<Treinador>();

        public static void CadastrarCliente((string? Nome, string? CPF, DateTime DataNasc, int Altura, int Peso) clienteInfo)
        {
            Cliente cliente = new Cliente
            {
                Nome = clienteInfo.Nome,
                CPF = clienteInfo.CPF,
                DataNasc = clienteInfo.DataNasc,
                Altura = clienteInfo.Altura,
                Peso = clienteInfo.Peso
            };

            ListaDeClientes.Add(cliente);
        }

        public static (string?, string?, DateTime, int, int) CapturarDadosCliente()
        {
            Console.WriteLine("Cadastro de Cliente:");
            Console.Write("Nome do Cliente: ");
            string? nome = Console.ReadLine();

            Console.Write("CPF do Cliente: ");
            string? cpf = Console.ReadLine();

            Console.Write("Data de Nascimento do Cliente (Formato: dd/MM/yyyy): ");
            DateTime dataNasc = DateTime.Parse(Console.ReadLine());

            Console.Write("Altura do Cliente (em centímetros): ");
            int altura = Convert.ToInt32(Console.ReadLine());

            Console.Write("Peso do Cliente: ");
            int peso = Convert.ToInt32(Console.ReadLine());

            return (nome, cpf, dataNasc, altura, peso);
        }

        public static void CadastrarTreinador((string? Nome, DateTime DataNasc, string? CPF, string? CREF) treinadorInfo)
        {
            Treinador treinador = new Treinador
            {
                Nome = treinadorInfo.Nome,
                DataNasc = treinadorInfo.DataNasc,
                CPF = treinadorInfo.CPF,
                CREF = treinadorInfo.CREF
            };

            ListaDeTreinadores.Add(treinador);
        }

        public static (string?, DateTime, string?, string?) CapturarDadosTreinador()
        {
            Console.WriteLine("Cadastro de Treinador:");
            Console.Write("Nome do Treinador: ");
            string? nome = Console.ReadLine();

            Console.Write("Data de Nascimento do Treinador (Formato: dd/MM/yyyy): ");
            DateTime dataNasc = DateTime.Parse(Console.ReadLine());

            Console.Write("CPF do Treinador: ");
            string? cpf = Console.ReadLine();

            Console.Write("CREF do Treinador: ");
            string? cref = Console.ReadLine();

            return (nome, dataNasc, cpf, cref);
        }

        public static void RelIdadeEntreMinMax(int idadeMinima, int idadeMaxima)
        {
            // Obtém a data atual
            DateTime dataAtual = DateTime.Now;

            // Filtra os treinadores com idade entre os valores fornecidos
            var treinadoresEntreMinMax = ListaDeTreinadores.Where(treinador =>
            {
                int idade = dataAtual.Year - treinador.DataNasc.Year;

                // Ajusta a idade se ainda não tiver completado o aniversário este ano
                if (dataAtual.Month < treinador.DataNasc.Month || (dataAtual.Month == treinador.DataNasc.Month && dataAtual.Day < treinador.DataNasc.Day))
                {
                    idade--;
                }

                return idade >= idadeMinima && idade <= idadeMaxima;
            });

            // Print column headers with fixed width
            Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20}", "Nome", "Data de Nascimento", "CPF", "CREF");

            // Print a line of equal signs as a separator
            Console.WriteLine(new string('=', 83));

            Console.WriteLine($"Treinadores com idade entre {idadeMinima} e {idadeMaxima} anos:");

            foreach (var treinador in treinadoresEntreMinMax)
            {
                // Print information about each treinador with fixed width
                Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20}", treinador.Nome, treinador.DataNasc.ToString("dd/MM/yyyy"), treinador.CPF, treinador.CREF);
                Console.WriteLine(new string('.', 83));
            }
        }

        public static void RelIdadeClientesEntreMinMax(int idadeMinima, int idadeMaxima)
        {
            DateTime dataAtual = DateTime.Now;

            var clientesEntreMinMax = ListaDeClientes.Where(cliente =>
            {
                int idade = dataAtual.Year - cliente.DataNasc.Year;

                if (dataAtual.Month < cliente.DataNasc.Month || (dataAtual.Month == cliente.DataNasc.Month && dataAtual.Day < cliente.DataNasc.Day))
                {
                    idade--;
                }

                return idade >= idadeMinima && idade <= idadeMaxima;
            });

            Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20}", "Nome", "Data de Nascimento", "Altura", "Peso");

            Console.WriteLine(new string('=', 83));

            Console.WriteLine($"Clientes com idade entre {idadeMinima} e {idadeMaxima} anos:");

            foreach (var cliente in clientesEntreMinMax)
            {
                Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20}", cliente.Nome, cliente.DataNasc.ToString("dd/MM/yyyy"), cliente.Altura, cliente.Peso);
                Console.WriteLine(new string('.', 83));
            }
        }

         public static void RelatorioClientesIMC(double valorMinimoIMC)
        {
            var clientesFiltrados = ListaDeClientes
                .Where(cliente => CalcularIMC(cliente) > valorMinimoIMC)
                .OrderBy(cliente => CalcularIMC(cliente));

            Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20}", "Nome", "Data de Nascimento", "Altura", "Peso", "IMC");

            Console.WriteLine(new string('=', 103));

            Console.WriteLine($"Clientes com IMC maior que {valorMinimoIMC}:");

            foreach (var cliente in clientesFiltrados)
            {
                Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20}", cliente.Nome, cliente.DataNasc.ToString("dd/MM/yyyy"), cliente.Altura, cliente.Peso, CalcularIMC(cliente).ToString("F2"));
                Console.WriteLine(new string('.', 103));
            }
        }

        private static double CalcularIMC(Cliente cliente)
        {
            if (cliente.Altura <= 0 || cliente.Peso <= 0)
            {
                return 0.0; 
            }

            double alturaMetros = cliente.Altura / 100; 
            return cliente.Peso / (alturaMetros * alturaMetros);
        }

        public static void GerarRelatorioClientesOrdemAlfabetica()
        {
            Console.WriteLine("\nClientes Cadastrados em Ordem Alfabética:");

            var clientesOrdenados = GestaoDaAcademia.ListaDeClientes.OrderBy(cliente => cliente.Nome);

            foreach (var cliente in clientesOrdenados)
            {
                Console.WriteLine($"Nome: {cliente.Nome}, CPF: {cliente.CPF}, Data de Nascimento: {cliente.DataNasc}, Altura: {cliente.Altura}, Peso: {cliente.Peso}");
            }
        }

        public static void RelIdadeClientesOrdenados()
        {
            // Ordenar os clientes pelo mais velho para o mais novo
            var clientesOrdenados = ListaDeClientes.OrderByDescending(cliente => cliente.DataNasc);

            // Print column headers with fixed width
            Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20}", "Nome", "Data de Nascimento", "Altura", "Peso");

            // Print a line of equal signs as a separator
            Console.WriteLine(new string('=', 83));

            Console.WriteLine($"Clientes ordenados do mais velho para o mais novo:");

            foreach (var cliente in clientesOrdenados)
            {
                // Print information about each cliente with fixed width
                Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20}", cliente.Nome, cliente.DataNasc.ToString("dd/MM/yyyy"), cliente.Altura, cliente.Peso);
                Console.WriteLine(new string('.', 83));
            }
        }

        public static void RelAniversariantesPorMes()
        {
            for (int mes = 1; mes <= 12; mes++)
            {
                DateTime dataAtual = DateTime.Now;

                var treinadoresAniversariantes = ListaDeTreinadores
                    .Where(treinador => treinador.DataNasc.Month == mes)
                    .OrderBy(treinador => treinador.DataNasc.Day);

                var clientesAniversariantes = ListaDeClientes
                    .Where(cliente => cliente.DataNasc.Month == mes)
                    .OrderBy(cliente => cliente.DataNasc.Day);

                // Imprimir apenas se houver aniversariantes
                if (treinadoresAniversariantes.Any() || clientesAniversariantes.Any())
                {
                    // Print column headers with fixed width
                    Console.WriteLine("{0,-20} {1,-20} {2,-20}", "Nome", "Data de Nascimento", "Tipo");

                    // Print a line of equal signs as a separator
                    Console.WriteLine(new string('=', 63));

                    Console.WriteLine($"Aniversariantes do mês {mes}:");

                    // Exibir treinadores aniversariantes
                    Console.WriteLine("\nTreinadores:");
                    foreach (var treinador in treinadoresAniversariantes)
                    {
                        Console.WriteLine("{0,-20} {1,-20} {2,-20}", treinador.Nome, treinador.DataNasc.ToString("dd/MM/yyyy"), "Treinador");
                    }

                    // Exibir clientes aniversariantes
                    Console.WriteLine("\nClientes:");
                    foreach (var cliente in clientesAniversariantes)
                    {
                        Console.WriteLine("{0,-20} {1,-20} {2,-20}", cliente.Nome, cliente.DataNasc.ToString("dd/MM/yyyy"), "Cliente");
                    }

                    Console.WriteLine(); // Adicionar uma linha em branco entre os meses
                }
            }
        }
    }
}
