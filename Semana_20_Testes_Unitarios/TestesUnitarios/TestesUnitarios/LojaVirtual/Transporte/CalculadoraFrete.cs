namespace TestesUnitarios.LojaVirtual.Transporte
{
    public enum TipoFrete
    {
        PAC,
        SEDEX,
        TRANSPORTADORA,
        RETIRADA_NO_LOCAL
    }

    public class CalculadoraFrete
    {
        public double Calcular(double distancia, TipoFrete tipoFrete)
        {
            switch (tipoFrete)
            {
                case TipoFrete.PAC:
                    return distancia * (distancia < 100 ? 0.15 : 0.25);
                case TipoFrete.SEDEX:
                    return distancia * (distancia < 100 ? 0.4 : 0.7);
                case TipoFrete.TRANSPORTADORA:
                    return distancia * (distancia <= 400 ? 0.30 : 0.35);
                case TipoFrete.RETIRADA_NO_LOCAL:
                default:
                    return 0;
            }
        }
    }
}