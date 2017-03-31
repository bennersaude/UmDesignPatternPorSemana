using Conceitos.InjecaoDependencias.IoC.Dummies.Task;

namespace Conceitos.InjecaoDependencias.IoC.ComIoC.Task
{
    public class SincronizarTask : SincronizacaoTaskBase
    {
        private CriadorArquivoSincronizacao criadorArquivoSincronizacao;
        private Sincronizar sincronizar;

        public SincronizarTask(
            CriadorArquivoSincronizacao criadorArquivoSincronizacao, 
            Sincronizar sincronizar)
        {
            this.criadorArquivoSincronizacao = criadorArquivoSincronizacao;
            this.sincronizar = sincronizar;
        }

        public void Run(DadosParaSincronizacaoDTO dadosSincronizacao)
        {
            criadorArquivoSincronizacao.Iniciar(dadosSincronizacao);

            RunTask(sincronizar);
        }
    }
}
