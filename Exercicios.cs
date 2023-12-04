namespace _NET_P004;

public class Exercicios
{
    private string grupoMuscular;
    private int series;
    private int repeticoes;
    private int intervalos;

    public Exercicios(string grupoMuscular, int series, int repeticoes, int intervalos)
        {
            this.grupoMuscular = grupoMuscular;
            this.series = series;
            this.repeticoes = repeticoes;
            this.intervalos = intervalos;
        }

        // Método get para o campo 'grupoMuscular'
        public string GetGrupoMuscular()
        {
            return grupoMuscular;
        }

        // Método set para o campo 'grupoMuscular'
        public void SetGrupoMuscular(string novoGrupoMuscular)
        {
            grupoMuscular = novoGrupoMuscular;
        }

        // Método get para o campo 'series'
        public int GetSeries()
        {
            return series;
        }

        // Método set para o campo 'series'
        public void SetSeries(int novasSeries)
        {
            series = novasSeries;
        }

        // Método get para o campo 'repeticoes'
        public int GetRepeticoes()
        {
            return repeticoes;
        }

        // Método set para o campo 'repeticoes'
        public void SetRepeticoes(int novasRepeticoes)
        {
            repeticoes = novasRepeticoes;
        }

        // Método get para o campo 'intervalos'
        public int GetIntervalos()
        {
            return intervalos;
        }

        // Método set para o campo 'intervalos'
        public void SetIntervalos(int novosIntervalos)
        {
            intervalos = novosIntervalos;
        }

}
