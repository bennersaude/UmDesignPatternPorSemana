using Conceitos.InjecaoDependencias.IoC.Dummies.Task;
using System;

namespace Conceitos.InjecaoDependencias.IoC.ComIoC.Task
{
    public class CriadorArquivoSincronizacao
    {
        private string v;

        public CriadorArquivoSincronizacao(string v)
        {
            this.v = v;
        }

        internal void Iniciar(DadosParaSincronizacaoDTO dadosSincronizacao)
        {
            throw new NotImplementedException();
        }
    }
}
