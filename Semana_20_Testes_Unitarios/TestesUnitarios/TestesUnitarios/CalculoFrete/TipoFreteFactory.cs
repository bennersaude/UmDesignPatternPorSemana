using System;
using TestesUnitarios.CalculoFrete.TiposFrete;

namespace TestesUnitarios.CalculoFrete
{
    public class TipoFreteFactory : ITipoFreteFactory
    {
        public TipoFreteBase Obter(TiposFreteEnum tipoFrete)
        {
            switch (tipoFrete)
            {
                 case TiposFreteEnum.PAC: return new PAC();
                 case TiposFreteEnum.Sedex: return new Sedex();
                 case TiposFreteEnum.Transportadora: return new Transportadora();
                 case TiposFreteEnum.RetiradaDoLocal: return new RetiradaDoLocal();
                 default: throw new Exception("Não Existe este tipo de frete.");
            }
        }
    }
}