using System;

namespace UmDesignPatternPorSemana.Strategy.FreteDoDesespero
{
    public class EntregaPedidos
    {
        private readonly int distancia;

        public EntregaPedidos(int distancia)
        {
            this.distancia = distancia;
        }

        public decimal ObterCusto(TipoFrete tipo)
        {
            if (tipo == TipoFrete.Pac) return distancia * 1.25m;
            if (tipo == TipoFrete.Sedex) return distancia * 2m;
            if (tipo == TipoFrete.Transportadora) return distancia * 1.75m;
            if (tipo == TipoFrete.RetiradaNoLocal) return 0m;

            throw new Exception("Tipo de frete inválido");
        }
    }
}
