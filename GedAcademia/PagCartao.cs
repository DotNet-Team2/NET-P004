
namespace GedAcademia
{
    public class PagCartao : Pagamento
    {
        public string? NumeroCartao { get; set; }
        public void RealizarPagamento(double valor)
        {
            Console.WriteLine($"Pagamento de {valor} realizado com cartão de crédito");
        }
    }
}