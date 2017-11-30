using System;

namespace TestesUnitarios.CalculoFrete.TiposFrete
{
    public class RetiradaDoLocal : TipoFreteBase
    {
        private const decimal DISTANCIA_MINIMA = 0;
        private const decimal PORCENTAGEM_DISTANCIA_MINIMA = 0;
        private const decimal PORCENTAGEM_DISTANCIA_MAXIMA = 0;

        public RetiradaDoLocal()
        {
            DistanciaMinima = DISTANCIA_MINIMA;
            PorcentagemDistanciaMinima = PORCENTAGEM_DISTANCIA_MINIMA;
            PorcentagemDistanciaMaxima = PORCENTAGEM_DISTANCIA_MAXIMA;
        }
    }
}