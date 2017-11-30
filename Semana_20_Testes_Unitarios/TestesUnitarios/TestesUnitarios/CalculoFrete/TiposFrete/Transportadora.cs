using System;

namespace TestesUnitarios.CalculoFrete.TiposFrete
{
    public class Transportadora : TipoFreteBase
    {
        private const decimal DISTANCIA_MINIMA = 400;
        private const decimal PORCENTAGEM_DISTANCIA_MINIMA = 0.30M;
        private const decimal PORCENTAGEM_DISTANCIA_MAXIMA = 0.35M;

        public Transportadora()
        {
            DistanciaMinima = DISTANCIA_MINIMA;
            PorcentagemDistanciaMinima = PORCENTAGEM_DISTANCIA_MINIMA;
            PorcentagemDistanciaMaxima = PORCENTAGEM_DISTANCIA_MAXIMA;
        }
    }
}