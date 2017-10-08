using System.Collections.Generic;
using System.Linq;
using UmDesignPatternPorSemana.Strategy.OdontogramaRefatorado.Anomalias;

namespace UmDesignPatternPorSemana.Strategy.OdontogramaRefatorado
{
    public class FactoryImpressaoAnomalias
    {
        public ImpressaoAnomalias ObterImpressao()
        {
            return new ImpressaoAnomalias(new List<IAnomalia>
            {
                new CoroaAusente(),
                new RaizAusente(),
                new DenteIncluso(),
                new GiroVersao()
            });
        }
    }
}
