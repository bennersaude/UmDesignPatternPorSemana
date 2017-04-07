using System.Collections.Generic;

namespace Conceitos.InjecaoDependencias.ServiceLocator.SemServiceLocator
{
    public interface IGeracaoLotes
    {
        Lote GerarNovoLote(IEnumerable<Guia> guias);
    }
}