using System;
using System.Collections.Generic;
using TestesUnitarios.CalculoFrete.CalculadoraFretesTemplate.Classes;
using TestesUnitarios.CalculoFrete.Enum;

namespace TestesUnitarios.CalculoFrete.CalculadoraFretesTemplate.Factory
{
    public class CalculadoraFreteTemplateFactory
    {
        private readonly Dictionary<TipoFrete, Func<ICalculadoraFrete>> dicionarioCalculadoras = new Dictionary<TipoFrete, Func<ICalculadoraFrete>>();

        public CalculadoraFreteTemplateFactory()
        {
            dicionarioCalculadoras.Add(TipoFrete.RetiradaLocal, () => new CalculadoraFreteRetiradaLocalTemplate());
            dicionarioCalculadoras.Add(TipoFrete.ViaPAC, () => new CalculadoraFreteViaPACTemplate());
            dicionarioCalculadoras.Add(TipoFrete.ViaSedex, () => new CalculadoraFreteViaSedexTemplate());
            dicionarioCalculadoras.Add(TipoFrete.ViaTransportadora, () => new CalculadoraFreteViaTransportadoraTemplate());
        }

        public ICalculadoraFrete ObterCalculadoraPorTipoFrete(TipoFrete tipoFrete)
        {
            return dicionarioCalculadoras[tipoFrete]();
        }
    }
}
