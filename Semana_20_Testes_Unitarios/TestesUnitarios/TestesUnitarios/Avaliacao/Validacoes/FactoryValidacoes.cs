using System.Collections.Generic;
using TestesUnitarios.Avaliacao.Dao;

namespace TestesUnitarios.Avaliacao.Validacoes
{
    public class FactoryValidacoes : IFactoryValidacoes
    {
        private IDespesasGuiaDao despesasGuiaDao;

        public FactoryValidacoes(IDespesasGuiaDao despesasGuiaDao)
        {
            this.despesasGuiaDao = despesasGuiaDao;
        }   

        public IEnumerable<IValidacaoGuia> ObeterValidacoes()
        {
            var validacoes = new List<IValidacaoGuia>
            {
                new ValidacaoData(),
                new ValidacaoDespesas(new DespesasGuiaDao()),
                new ValidacaoObtoRn()
            };

            return validacoes;
        }
    }
}
