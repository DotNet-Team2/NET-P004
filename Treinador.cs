namespace _NET_P004;

public class Treinador : Pessoa
{
    private string cref;

     public Treinador(string nome, DateTime dataNascimento, string cpf, string cref)
            : base(nome, dataNascimento, cpf)
        {
            this.cref = cref;
        }

        // Método get para o campo 'cref'
        public string GetCref()
        {
            return cref;
        }

        // Método set para o campo 'cref'
        public void SetCref(string novoCref)
        {
            cref = novoCref;
        }
}
