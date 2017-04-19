using Semana05.Facade.Sincronizacao;
using System.Collections.Generic;

namespace Semana05.Facade.SincronizacaoSaudavel
{
    public class SincronizacaoContratanteFacade : IImportacaoDados
    {
        private readonly List<IImportacaoDados> importacoes;

        public SincronizacaoContratanteFacade(List<IImportacaoDados> importacoes)
        {
            this.importacoes = importacoes;
        }

        public void PosImportacao()
        {
            importacoes.ForEach(i => i.PosImportacao());
        }

        public void PreImportacao()
        {
            importacoes.ForEach(i => i.PreImportacao());
        }

        public void SalvarRegistro(object registro)
        {
            importacoes.ForEach(i => i.SalvarRegistro(registro));
        }
    }
}
