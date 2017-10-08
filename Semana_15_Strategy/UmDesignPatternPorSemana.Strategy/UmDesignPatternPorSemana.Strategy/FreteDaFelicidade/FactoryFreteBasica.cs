using System;
using System.Collections.Generic;
using UmDesignPatternPorSemana.Strategy.FreteDaFelicidade.FreteStrategy;

namespace UmDesignPatternPorSemana.Strategy.FreteDaFelicidade
{

    public class FactoryFreteBasica : IFactoryFrete
    {
        private static readonly IDictionary<TipoFrete, IFrete> tiposFrete = new Dictionary<TipoFrete, IFrete>
        {
            {TipoFrete.Pac, new Pac()},
            {TipoFrete.Sedex, new Sedex()},
            {TipoFrete.AlfaTransportadora, new AlfaTransportadora()},
            {TipoFrete.RetiradaNoLocal, new RetiradaNoLocal()},
        };

        public IFrete ObterFrete(TipoFrete tipo)
        {
            return tiposFrete[tipo];
        }
    }
}
