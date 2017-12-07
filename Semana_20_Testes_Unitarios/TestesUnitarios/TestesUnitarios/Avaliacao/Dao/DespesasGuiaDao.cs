using Benner.Tecnologia.Common;
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

        public IEnumerable<IDespesasGuiaProperties> ObterDespesasDaGuia(long handleGuia)
        {
            var criterio = new Criteria("A.GUIA = :GUIA AND TIPOREDUCAOACRESCIMO <> :TIPO AND VALORREDUCAOACRESCIMO > 100");
            criterio.Parameters.Add("GUIA", handleGuia);
            criterio.Parameters.Add("TIPOREDUCAOACRESCIMO", (int)TipoReducaoAcrescimo.ItemAcrescimo);

            return daoBase.GetMany(criterio);
        }
    }
}