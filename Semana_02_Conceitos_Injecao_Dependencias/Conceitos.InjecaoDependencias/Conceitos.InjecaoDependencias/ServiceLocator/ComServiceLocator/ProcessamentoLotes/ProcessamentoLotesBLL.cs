using Conceitos.InjecaoDependencias.ServiceLocator.SemServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conceitos.InjecaoDependencias.ServiceLocator.ComServiceLocator.ProcessamentoLotes
{
    class ProcessamentoLotesBLL
    {
        public void Processar()
        {
            var processamento = ServiceLocatorRegistration.Locator.Resolve<IProcessamentoLotes>();
            processamento.ProcessarLote(new[] { new Guia() });
        }
    }
}
