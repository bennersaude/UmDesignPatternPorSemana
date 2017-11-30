namespace TestesUnitarios.CalculoFrete.CalculadoraFretesTemplate.Classes
{
    public class CalculadoraFreteViaTransportadoraTemplate : CalculadoraFreteTemplate
    {
        public override double CalcularFrete(double distanciaEmKm)
        {
            return System.Math.Round(distanciaEmKm * ((distanciaEmKm > 400) ? 0.35 : 0.3), QUANTIDADE_CASAS_DECIMAIS);
        }
    }
}
