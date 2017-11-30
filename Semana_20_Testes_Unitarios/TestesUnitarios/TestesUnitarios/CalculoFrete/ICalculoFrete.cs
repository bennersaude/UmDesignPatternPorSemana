using TestesUnitarios.CalculoFrete.TiposFrete;

namespace TestesUnitarios.CalculoFrete
{
    public interface ICalculoFrete
    {
        decimal CalcularFrete(TiposFreteEnum tipoFrete, decimal quilometragem);
    }
}