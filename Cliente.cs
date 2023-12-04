namespace _NET_P004;

public class Cliente : Pessoa
{
    private int altura;
    private int peso;

    public Cliente(string nome, DateTime dataNascimento, string cpf, int altura, int peso)
            : base(nome, dataNascimento, cpf)
    {
        this.altura = altura;
        this.peso = peso;
    }

    // Método get para o campo 'altura'
    public int GetAltura()
    {
        return altura;
    }

    // Método set para o campo 'altura'
    public void SetAltura(int novaAltura)
    {
        altura = novaAltura;
    }

    // Método get para o campo 'peso'
    public int GetPeso()
    {
        return peso;
    }

    // Método set para o campo 'peso'
    public void SetPeso(int novoPeso)
    {
        peso = novoPeso;
    }

    public int Idade()
    {
        int idade = DateTime.Today.Year - this.GetDataNascimento().Year;

        if (this.GetDataNascimento()> DateTime.Today.AddYears(-idade))
        {
            idade--;
        }

        return idade;
    }

    public double IMC()
    {
        return this.peso / (this.altura * this.altura);
    }

}
