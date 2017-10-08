using System;

namespace UmDesignPatternPorSemana.Strategy.FreteDaFelicidade.FreteStrategy
{
    public interface IFrete
    {
        decimal CalcularCusto(int distancia);
    }
}
