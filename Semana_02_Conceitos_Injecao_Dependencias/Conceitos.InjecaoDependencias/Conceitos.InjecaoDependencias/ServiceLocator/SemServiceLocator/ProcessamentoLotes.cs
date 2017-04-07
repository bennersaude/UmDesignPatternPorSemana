using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conceitos.InjecaoDependencias.ServiceLocator.SemServiceLocator
{
    public class ProcessamentoLotes : IProcessamentoLotes
    {
        private IGeracaoLotes geracaoLotes;
        private IEnvioLotes envioLotes;

        public ProcessamentoLotes(IGeracaoLotes geracaoLotes, IEnvioLotes envioLotes)
        {
            this.geracaoLotes = geracaoLotes;
            this.envioLotes = envioLotes;
        }

        public void ProcessarLote(IEnumerable<Guia> guias)
        {
            var lote = geracaoLotes.GerarNovoLote(guias);
            envioLotes.EnviarLote(lote);
        }
    }
}
