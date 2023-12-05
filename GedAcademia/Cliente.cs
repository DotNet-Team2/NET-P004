
namespace GedAcademia
{
    public class Cliente : Pessoa
    {

        public int AlturaCm { get; set; }
        public int PesoKg { get; set; }
        public List<Avaliacao> Avaliacoes { get; set; } = new List<Avaliacao>();


        public List<Pagamento> Pagamentos { get; set; } = new List<Pagamento>();

        public void AdicionarPagamento(Pagamento pagamento)
        {
            Pagamentos.Add(pagamento);
        }


        public void RealizarPagamentos()
        {

            foreach (var pagamento in Pagamentos)
            {
                pagamento.EfetuarPagamento(pagamento.ValorBruto);
            }
        }
    }
}
