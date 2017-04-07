using System.Collections.Generic;

namespace Conceitos.InjecaoDependencias.ServiceLocator.SemServiceLocator
{
    public class GeracaoLotes : IGeracaoLotes
    {
        private IValidacaoGuias validacao;

        public GeracaoLotes(IValidacaoGuias validacao)
        {
            this.validacao = validacao;
        }

        public Lote GerarNovoLote(IEnumerable<Guia> guias)
        {
            validacao.Validar(guias);
            return new Lote(guias);
        }
    }
}
