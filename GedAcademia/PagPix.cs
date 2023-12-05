
namespace GedAcademia
{
    public class PagPix : Pagamento
    {
        public string? NumeroChave { get; set; }

        
        public void RealizarPagamento(double valor)
        {
            Console.WriteLine($"Pagamento de {valor} realizado em dinheiro");
        }
    }
}