using System.Collections.Generic;

namespace Conceitos.InjecaoDependencias.ServiceLocator.SemServiceLocator
{
    public interface IValidacaoGuias
    {
        void Validar(IEnumerable<Guia> guias);
    }
}