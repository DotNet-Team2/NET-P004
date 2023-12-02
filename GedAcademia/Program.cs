using System;

namespace GedAcademia
{
    class Program
    {
        static void Main()
        {
            // Exemplo de cadastro de cliente
            GestaoClientesTreinadores.CadastrarCliente(("João", "123.456.789-00", new DateTime(1990, 1, 1), 1.75, 70.5));
            GestaoClientesTreinadores.CadastrarCliente(("Ana", "987.654.321-00", new DateTime(1988, 3, 20), 1.68, 62.3));
            GestaoClientesTreinadores.CadastrarCliente(("Carlos", "111.222.333-44", new DateTime(1995, 7, 10), 1.80, 85.0));
            GestaoClientesTreinadores.CadastrarCliente(("Fernanda", "555.666.777-88", new DateTime(1980, 12, 5), 1.62, 55.5));
            GestaoClientesTreinadores.CadastrarCliente(("Ricardo", "999.888.777-66", new DateTime(1992, 9, 15), 1.75, 78.2));
            GestaoClientesTreinadores.CadastrarCliente(("Camila", "333.444.555-66", new DateTime(1987, 2, 8), 1.70, 68.9));

            // Cadastro de treinadores
            GestaoClientesTreinadores.CadastrarTreinador(("Roberto", new DateTime(1983, 6, 25), "444.555.666-77", "CREF456"));
            GestaoClientesTreinadores.CadastrarTreinador(("Mariana", new DateTime(1990, 11, 3), "777.888.999-00", "CREF789"));
            GestaoClientesTreinadores.CadastrarTreinador(("Pedro", new DateTime(1985, 8, 12), "222.333.444-55", "CREF321"));
            GestaoClientesTreinadores.CadastrarTreinador(("Amanda", new DateTime(1998, 4, 30), "666.777.888-99", "CREF654"));
            GestaoClientesTreinadores.CadastrarTreinador(("Lucas", new DateTime(1982, 10, 18), "888.999.000-11", "CREF987"));
            GestaoClientesTreinadores.CadastrarTreinador(("Maria", new DateTime(1985, 5, 15), "123.456.789-00", "CREF123"));

            Console.WriteLine("\nClientes Cadastrados:");
            foreach (var cliente in GestaoClientesTreinadores.ListaDeClientes)
            {
                Console.WriteLine($"Nome: {cliente.Nome}, CPF: {cliente.CPF}, Data de Nascimento: {cliente.DataNasc}, Altura: {cliente.Altura}, Peso: {cliente.Peso}");
            }

            // Exemplo de exibição de treinadores cadastrados
            Console.WriteLine("\nTreinadores Cadastrados:");
            foreach (var treinador in GestaoClientesTreinadores.ListaDeTreinadores)
            {
                Console.WriteLine($"Nome: {treinador.Nome}, Data de Nascimento: {treinador.DataNasc}, CPF: {treinador.CPF}, CREF: {treinador.CREF}");
            }

            // Exemplo de relatório de treinadores com idade entre 30 e 40 anos
            Console.WriteLine("\nRelatório de Treinadores com idade entre 30 e 40 anos:");
            GestaoClientesTreinadores.RelIdadeEntreMinMax(30, 40);

            // Exemplo de relatório de clientes com idade entre 25 e 35 anos
            Console.WriteLine("\nRelatório de Clientes com idade entre 25 e 35 anos:");
            GestaoClientesTreinadores.RelIdadeClientesEntreMinMax(25, 35);

            // Exemplo de relatório de clientes com IMC maior que 25.0
            Console.WriteLine("\nRelatório de Clientes com IMC maior que 25.0:");
            GestaoClientesTreinadores.RelatorioClientesIMC(25.0);

            // Chamar o método para gerar o relatório de clientes em ordem alfabética
            GestaoClientesTreinadores.GerarRelatorioClientesOrdemAlfabetica();

            // Exibição de clientes
            Console.WriteLine("\nClientes Cadastrados:");
            foreach (var cliente in GestaoClientesTreinadores.ListaDeClientes)
            {
                Console.WriteLine($"Nome: {cliente.Nome}, CPF: {cliente.CPF}, Data de Nascimento: {cliente.DataNasc}, Altura: {cliente.Altura}, Peso: {cliente.Peso}");
            }

            // Relatório de idade dos clientes ordenados
            GestaoClientesTreinadores.RelIdadeClientesOrdenados();
            
            // Exemplo de chamada para gerar relatório de aniversariantes de todos os meses
            GestaoClientesTreinadores.RelAniversariantesPorMes();
        }
    }
}
