using Conceitos.InjecaoDependencias.ServiceLocator.SemServiceLocator;
using System.Collections.Generic;

namespace Conceitos.InjecaoDependencias.ServiceLocator.ComServiceLocator.ProcessamentoLotes
{
    public class GeracaoLotes : IGeracaoLotes
    {
        private IValidacaoGuias validacao;

        public GeracaoLotes(IServiceLocator locator)
        {
            validacao = locator.Resolve<IValidacaoGuias>();
        }

        public Lote GerarNovoLote(IEnumerable<Guia> guias)
        {
            validacao.Validar(guias);
            return new Lote(guias);
        }
    }
}
