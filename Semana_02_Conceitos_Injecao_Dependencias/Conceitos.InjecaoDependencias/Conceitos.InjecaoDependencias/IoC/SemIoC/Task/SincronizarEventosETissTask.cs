using Conceitos.InjecaoDependencias.IoC.Dummies.Task;

namespace Conceitos.InjecaoDependencias.IoC.SemIoC.Task
{
    public class SincronizarEventosETissTask : SincronizacaoTaskBase
    {
        public void Run(DadosParaSincronizacaoDTO dadosSincronizacao)
        {
            new CriadorArquivoSincronizacao(dadosSincronizacao, "SincronizarEventosETiss").Iniciar();

            RunTask(new SincronizarEventosETiss());
        }
    }
}
