using System;
using TestesUnitarios.CalculoFrete.Enum;

namespace TestesUnitarios.CalculoFrete.CalculadoraFretes
{
    public class CalculadoraFrete : ICalculadoraFrete
    {
        private const int QUANTIDADE_CASAS_DECIMAIS = 2;
        private readonly TipoFrete _tipoFrete;

        public CalculadoraFrete(TipoFrete tipoFrete)
        {
            _tipoFrete = tipoFrete;
        }

        public double CalcularFrete(double distanciaEmKm)
        {
            double coeficiente = 0;
            switch (_tipoFrete)
            {
                case TipoFrete.ViaPAC:
                    coeficiente = CalculoViaPAC(distanciaEmKm);
                    break;
                case TipoFrete.ViaSedex:
                    coeficiente = CalculoViaSedex(distanciaEmKm);
                    break;
                case TipoFrete.ViaTransportadora:
                    coeficiente = CalculoViaTransportadora(distanciaEmKm);
                    break;
            }

            return Math.Round(distanciaEmKm * coeficiente, QUANTIDADE_CASAS_DECIMAIS);
        }

        private double CalculoViaPAC(double distanciaEmKm)
        {
            return (distanciaEmKm < 100) ? 0.15 : 0.25;
        }

        private double CalculoViaSedex(double distanciaEmKm)
        {
            return (distanciaEmKm < 100) ? 0.4 : 0.7;
        }

        private double CalculoViaTransportadora(double distanciaEmKm)
        {
            return (distanciaEmKm > 400) ? 0.35 : 0.3;
        }
    }
}