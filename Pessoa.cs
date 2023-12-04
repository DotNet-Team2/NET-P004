namespace _NET_P004;

public class Pessoa
{
    private string nome;
    private DateTime dataNascimento;
    private string cpf;

    public Pessoa(string nome, DateTime dataNascimento, string cpf)
        {
            this.nome = nome;
            this.dataNascimento = dataNascimento;
            this.cpf = cpf;
        }

        // Método get para o campo 'nome'
        public string GetNome()
        {
            return nome;
        }

        // Método set para o campo 'nome'
        public void SetNome(string novoNome)
        {
            nome = novoNome;
        }

        // Método get para o campo 'dataNascimento'
        public DateTime GetDataNascimento()
        {
            return dataNascimento;
        }

        // Método set para o campo 'dataNascimento'
        public void SetDataNascimento(DateTime novaDataNascimento)
        {
            dataNascimento = novaDataNascimento;
        }

        // Método get para o campo 'cpf'
        public string GetCpf()
        {
            return cpf;
        }

        // Método set para o campo 'cpf'
        public void SetCpf(string novoCpf)
        {
            cpf = novoCpf;
        }
}