using TestesUnitarios.CalculoFrete.TiposFrete;

namespace TestesUnitarios.CalculoFrete
{
    public class CalculoFrete : ICalculoFrete
    {
        private readonly ITipoFreteFactory tipoFreteFactory;

        public CalculoFrete(ITipoFreteFactory tipoFreteFactory)
        {
            this.tipoFreteFactory = tipoFreteFactory;
        }

        public decimal CalcularFrete(TiposFreteEnum tipoFrete, decimal quilometragem)
        {
            var tipoDoFrete = tipoFreteFactory.Obter(tipoFrete);

            return tipoDoFrete.Calcular(quilometragem);
        }
    }
}