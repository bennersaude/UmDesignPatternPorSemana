namespace TestesUnitarios.CalculoFrete.CalculadoraFretesTemplate.Classes
{
    public class CalculadoraFreteViaSedexTemplate : CalculadoraFreteTemplate
    {
        public override double CalcularFrete(double distanciaEmKm)
        {
            return System.Math.Round(distanciaEmKm * ((distanciaEmKm < 100) ? 0.4 : 0.7), QUANTIDADE_CASAS_DECIMAIS);
        }
    }
}
