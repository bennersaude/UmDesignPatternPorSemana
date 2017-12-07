using System.Collections.Generic;
using Benner.Tecnologia.Common;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Avaliacao.Dao
{
    public class DespesasGuiaDao : IDespesasGuiaDao
    {
        private readonly IDao<IDespesasGuiaProperties> despesasGuiaDao;

        public DespesasGuiaDao(IDao<IDespesasGuiaProperties> despesasGuiaDao)
        {
            this.despesasGuiaDao = despesasGuiaDao;
        }

        public IEnumerable<IDespesasGuiaProperties> ObterDespesasDaGuia(long handleGuia)
        {
            return despesasGuiaDao.GetMany(new Criteria());
        }
    }
}
