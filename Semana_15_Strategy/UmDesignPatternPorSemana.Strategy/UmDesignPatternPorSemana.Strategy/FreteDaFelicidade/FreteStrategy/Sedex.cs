using System;
using System.Collections.Generic;

namespace UmDesignPatternPorSemana.Strategy.FreteDaFelicidade.FreteStrategy
{
    public class Sedex : IFrete
    {
        public decimal CalcularCusto(int distancia)
        {
            return distancia * 2m;
        }
    }
}
