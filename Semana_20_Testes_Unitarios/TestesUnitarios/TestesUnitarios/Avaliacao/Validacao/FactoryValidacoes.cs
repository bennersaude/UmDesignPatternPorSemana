using System.Collections.Generic;
using TestesUnitarios.Avaliacao.Dao;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Avaliacao.Validacao
{
    public class FactoryValidacoes : IFactoryValidacoes
    {
        public IList<IValidacao> ObterValidacoes()
        {
            return new List<IValidacao>
            {
                new ValidacaoDataAtendimento(),
                new ValidacaoIndicadorObito(),
                new ValidacaoDespesaGuia(new DespesasGuiaDao(new Dao<DespesasGuia, IDespesasGuiaProperties>()))
            };
        }
    }
}
