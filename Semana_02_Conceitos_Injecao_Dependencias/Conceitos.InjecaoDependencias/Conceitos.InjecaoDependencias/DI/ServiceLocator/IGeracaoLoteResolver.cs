using Conceitos.InjecaoDependencias.DI.Dummies;

namespace Conceitos.InjecaoDependencias.DI.ServiceLocator
{
    public interface IGeracaoLoteResolver
    {
        IGeracaoLote ObterGeracaoLote(TipoGuia tipo);
    }
}