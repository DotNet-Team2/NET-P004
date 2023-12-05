
namespace GedAcademia
{
    public class PagPix : Pagamento
    {
        public void RealizarPagamento(double valor)
        {
            Console.WriteLine($"Pagamento de {valor} realizado em dinheiro");
        }
    }
}