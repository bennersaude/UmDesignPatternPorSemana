using UmDesignPatternPorSemana.Strategy.FreteDaFelicidade.FreteStrategy;

namespace UmDesignPatternPorSemana.Strategy.FreteDaFelicidade
{
    public interface IFactoryFrete
    {
        IFrete ObterFrete(TipoFrete tipo);
    }
}