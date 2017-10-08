namespace UmDesignPatternPorSemana.Strategy.FreteDaFelicidade.FreteStrategy
{
    public class AlfaTransportadora : IFrete
    {
        public decimal CalcularCusto(int distancia)
        {
            return distancia * 1.75m;
        }
    }
}
