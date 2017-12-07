using System;
using System.Collections.Generic;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Avaliacao.Dao
{
    public class DespesasGuiaDao : IDespesasGuiaDao
    {
        private readonly IDao<IDespesasGuiaProperties> daoBase;

        public DespesasGuiaDao(IDao<IDespesasGuiaProperties> daoBase)
        {
            this.daoBase = daoBase;
        }

        public DespesasGuiaDao() : this(new Dao<DespesasGuia, IDespesasGuiaProperties>())
        {
        }

        public IEnumerable<DespesasGuia> ObterDespesasDaGuia(long handleGuia)
        {
            throw new NotImplementedException();
        }
    }
}
