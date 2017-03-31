using Conceitos.InjecaoDependencias.IoC.Dummies.Task;
using System.Collections.Generic;

namespace Conceitos.InjecaoDependencias.IoC.ComIoC.Task
{
    public class Sincronismos
    {
        public IEnumerable<SincronizarTask> ObterTasks()
        {
            var sincronismoEventosETiss = new SincronizarTask(
                new CriadorArquivoSincronizacao("SincronizarEventosETiss"), 
                new SincronizarEventosETiss()
            );

            var sincronismoGuiasETiss = new SincronizarTask(
                new CriadorArquivoSincronizacao("SincronizarGuiaETiss"),
                new SincronizarGuiaETiss()
            );

            return new[] { sincronismoEventosETiss, sincronismoGuiasETiss };
        }
    }
}
