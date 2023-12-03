namespace GedAcademia;

public class Pessoa
{
    public string? Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string? CPF { get; set; }
    public static bool ValidarCPF(string cpf)
    {
        return cpf.All(char.IsDigit) && cpf.Length == 11;
    }

}
