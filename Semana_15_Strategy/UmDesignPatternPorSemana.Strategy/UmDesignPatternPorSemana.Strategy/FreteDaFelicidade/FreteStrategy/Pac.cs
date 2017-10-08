using System;
using System.Collections.Generic;

namespace UmDesignPatternPorSemana.Strategy.FreteDaFelicidade.FreteStrategy
{
    public class Pac : IFrete
    {
        public decimal CalcularCusto(int distancia)
        {
            return distancia * 1.25m;
        }
    }
}
