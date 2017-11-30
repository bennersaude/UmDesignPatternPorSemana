using TestesUnitarios.CalculoFrete.TiposFrete;

namespace TestesUnitarios.CalculoFrete
{
    public interface ITipoFreteFactory
    {
        TipoFreteBase Obter(TiposFreteEnum tipoFrete);
    }
}