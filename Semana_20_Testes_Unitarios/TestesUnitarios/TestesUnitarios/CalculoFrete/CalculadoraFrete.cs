using System;

namespace TestesUnitarios.CalculoFrete
{
    public class CalculadoraFrete
    {
        private const int CASA_DECIMAIS = 2;

        public double CalcularFrete(double distancia, TipoFrete tipoFrete)
        {
            switch (tipoFrete)
            {
                case TipoFrete.PAC:
                    return CalcularFretePac(distancia);
                case TipoFrete.Sedex:
                    return CalcularFreteSedex(distancia);
                case TipoFrete.Transportadora:
                    return CalcularFreteTransportadora(distancia);
                case TipoFrete.RetiradaLocal:
                default:
                    return 0;
            }
        }

        private double CalcularFretePac(double distancia)
        {
            return  Math.Round(distancia < 100 ? distancia * 0.15 : distancia * 0.25, CASA_DECIMAIS);
        }

        private double CalcularFreteSedex(double distancia)
        {
            return Math.Round(distancia < 100 ? distancia * 0.40 : distancia * 0.70, CASA_DECIMAIS);
        }

        private double CalcularFreteTransportadora(double distancia)
        {
            return Math.Round(distancia > 400 ? distancia * 0.35 : distancia * 0.30, CASA_DECIMAIS);
        }
    }
}