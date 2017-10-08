using System;
using System.Collections.Generic;
using UmDesignPatternPorSemana.Strategy.FreteDaFelicidade.FreteStrategy;

namespace UmDesignPatternPorSemana.Strategy.FreteDaFelicidade
{
    public class FactoryFreteComActivator : IFactoryFrete
    {
        private static readonly IDictionary<TipoFrete, Func<IFrete>> tiposFrete = new Dictionary<TipoFrete, Func<IFrete>>
        {
            {TipoFrete.Pac, ObterInstancia<Pac>},
            {TipoFrete.Sedex, ObterInstancia<Sedex>},
            {TipoFrete.AlfaTransportadora, ObterInstancia<AlfaTransportadora>},
            {TipoFrete.RetiradaNoLocal, ObterInstancia<RetiradaNoLocal>},
        };

        public IFrete ObterFrete(TipoFrete tipo)
        {
            return tiposFrete[tipo]();
        }

        private static IFrete ObterInstancia<T>() where T: IFrete, new()
        {
            return Activator.CreateInstance<T>();
        }
    }
}
