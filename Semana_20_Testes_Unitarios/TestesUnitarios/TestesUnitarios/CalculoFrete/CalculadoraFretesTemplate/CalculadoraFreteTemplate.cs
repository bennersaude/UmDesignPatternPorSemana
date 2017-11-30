using TestesUnitarios.CalculoFrete.Enum;

namespace TestesUnitarios.CalculoFrete.CalculadoraFretesTemplate
{
    public abstract class CalculadoraFreteTemplate : ICalculadoraFrete
    {
        protected const int QUANTIDADE_CASAS_DECIMAIS = 2;

        public abstract double CalcularFrete(double distanciaEmKm);
    }
}
