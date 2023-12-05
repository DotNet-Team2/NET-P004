public class Pagamento {
    
    public string? Descricao { get; set; }

    
    public double ValorBruto { get; set; }

    
    public double Desconto { get; set; }

    
    public DateTime DataHora { get; set; }

    internal void EfetuarPagamento(double valorBruto)
    {
        throw new NotImplementedException();
    }
}
