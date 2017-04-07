using System.Collections.Generic;

namespace Conceitos.InjecaoDependencias.ServiceLocator.SemServiceLocator
{
    public interface IProcessamentoLotes
    {
        void ProcessarLote(IEnumerable<Guia> guias);
    }
}