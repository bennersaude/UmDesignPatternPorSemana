using Conceitos.InjecaoDependencias.ServiceLocator.SemServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conceitos.InjecaoDependencias.ServiceLocator.ComServiceLocator.ProcessamentoLotes
{
    public class ProcessamentoLotes : IProcessamentoLotes
    {
        private IGeracaoLotes geracaoLotes;
        private IEnvioLotes envioLotes;

        public ProcessamentoLotes(IServiceLocator locator)
        {
            geracaoLotes = locator.Resolve<IGeracaoLotes>();
            envioLotes = locator.Resolve<IEnvioLotes>();
        }

        public void ProcessarLote(IEnumerable<Guia> guias)
        {
            var lote = geracaoLotes.GerarNovoLote(guias);
            envioLotes.EnviarLote(lote);
        }
    }
}
