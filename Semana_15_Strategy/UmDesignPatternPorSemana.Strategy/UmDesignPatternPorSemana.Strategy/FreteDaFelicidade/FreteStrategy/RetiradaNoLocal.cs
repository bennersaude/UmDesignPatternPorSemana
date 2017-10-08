using System;
using System.Collections.Generic;

namespace UmDesignPatternPorSemana.Strategy.FreteDaFelicidade.FreteStrategy
{
    public class RetiradaNoLocal : IFrete
    {
        public decimal CalcularCusto(int distancia)
        {
            return 0m;
        }
    }
}
