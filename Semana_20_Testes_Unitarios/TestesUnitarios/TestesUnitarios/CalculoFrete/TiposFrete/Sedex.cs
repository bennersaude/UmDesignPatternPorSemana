using System;

namespace TestesUnitarios.CalculoFrete.TiposFrete
{
    public class Sedex : TipoFreteBase
    {
        private const decimal DISTANCIA_MINIMA = 100;
        private const decimal PORCENTAGEM_DISTANCIA_MINIMA = 0.40M;
        private const decimal PORCENTAGEM_DISTANCIA_MAXIMA = 0.70M;

        public Sedex()
        {
            DistanciaMinima = DISTANCIA_MINIMA;
            PorcentagemDistanciaMinima = PORCENTAGEM_DISTANCIA_MINIMA;
            PorcentagemDistanciaMaxima = PORCENTAGEM_DISTANCIA_MAXIMA;
        }
    }
}