using Conceitos.InjecaoDependencias.DIP.Dummies.ParametrosSistema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conceitos.InjecaoDependencias.ServiceLocator.SemServiceLocator
{
    class ProcessamentoLotesBLL
    {
        public void Processar()
        {
            var processamento = new ProcessamentoLotes(
                new GeracaoLotes(new ValidacaoGuias()), 
                new EnvioLotes(new HttpClient())
            );

            processamento.ProcessarLote(new [] { new Guia() });
        }
    }
}
