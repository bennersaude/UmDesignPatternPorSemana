using System;

namespace UmDesignPatternPorSemana.Strategy.FreteDaFelicidade
{

    public class EntregaPedidos
    {
        private readonly int distancia;
        private readonly IFactoryFrete factoryFrete;

        public EntregaPedidos(int distancia, IFactoryFrete factoryFrete)
        {
            this.distancia = distancia;
            this.factoryFrete = factoryFrete;
        }

        public decimal ObterCusto(TipoFrete tipo)
        {
            return factoryFrete.ObterFrete(tipo).CalcularCusto(distancia);
        }
    }
}
