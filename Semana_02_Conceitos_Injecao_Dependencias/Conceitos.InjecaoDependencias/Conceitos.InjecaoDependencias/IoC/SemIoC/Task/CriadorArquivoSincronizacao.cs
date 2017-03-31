using System;
using Conceitos.InjecaoDependencias.IoC.Dummies.Task;

namespace Conceitos.InjecaoDependencias.IoC.SemIoC.Task
{
    internal class CriadorArquivoSincronizacao
    {
        private DadosParaSincronizacaoDTO dadosSincronizacao;
        private string v;

        public CriadorArquivoSincronizacao(DadosParaSincronizacaoDTO dadosSincronizacao, string v)
        {
            this.dadosSincronizacao = dadosSincronizacao;
            this.v = v;
        }

        internal void Iniciar()
        {
            throw new NotImplementedException();
        }
    }
}