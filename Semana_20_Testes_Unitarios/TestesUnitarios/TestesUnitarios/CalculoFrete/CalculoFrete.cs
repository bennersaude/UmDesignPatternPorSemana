using System;

namespace TestesUnitarios.CalculoFrete
{
    public class CalculoFrete
    {
        public decimal Calcular(TipoFrete tipoFrete, int quilometros)
        {
            decimal valor = 0;
            switch (tipoFrete)
            {
                case TipoFrete.PAC:
                    valor = quilometros < 100 ? quilometros * 0.15m : quilometros * 0.25m;
                    break;
                case TipoFrete.Sedex:
                    valor = quilometros < 100 ? quilometros * 0.4m : quilometros * 0.7m;
                    break;
                case TipoFrete.Transportadora:
                    valor = quilometros > 400 ? quilometros * 0.35m : quilometros * 0.3m;
                    break;
                case TipoFrete.Retirada:
                    break;
                default:
                    throw new ArgumentOutOfRangeException("tipoFrete", tipoFrete, null);
            }
            return valor;
        }
    }
}
