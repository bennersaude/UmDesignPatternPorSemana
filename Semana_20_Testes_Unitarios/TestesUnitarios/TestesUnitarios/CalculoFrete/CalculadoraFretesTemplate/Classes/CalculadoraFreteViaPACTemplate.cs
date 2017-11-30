namespace TestesUnitarios.CalculoFrete.CalculadoraFretesTemplate.Classes
{
    public class CalculadoraFreteViaPACTemplate : CalculadoraFreteTemplate
    {
        public override double CalcularFrete(double distanciaEmKm)
        {
            return System.Math.Round(distanciaEmKm * ((distanciaEmKm < 100) ? 0.15 : 0.25), QUANTIDADE_CASAS_DECIMAIS);
        }
    }
}
