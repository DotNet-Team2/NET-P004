public class Plano {
    public string? titulo;
    private double valorPorMes;

    public Plano (string titulo, double valor){
        this.titulo = titulo;
        this.valorPorMes = valor;
    }

    public string getTitulo(){
        return this.titulo;
    }

    public double  getValorPorMes(){
        return this.valorPorMes;
    }
    public double ValorPorMes {
        get { return valorPorMes; }
        set { valorPorMes = value; }
    }
}
