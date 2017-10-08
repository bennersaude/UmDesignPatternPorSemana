using System.Collections.Generic;
using System.Linq;
using UmDesignPatternPorSemana.Strategy.OdontogramaRefatorado.Anomalias;

namespace UmDesignPatternPorSemana.Strategy.OdontogramaRefatorado
{
    public class ImpressaoAnomalias
    {
        private readonly IEnumerable<IAnomalia> anomalias;

        public ImpressaoAnomalias(IEnumerable<IAnomalia> anomalias)
        {
            this.anomalias = anomalias;
        }

        public IEnumerable<ImpressaoAnomaliaDto> ObterImpressoes(DadosAnomaliasDto dados)
        {
            return anomalias.Where(anomalia => anomalia.EstaPresente(dados)).Select(anomalia => anomalia.ObterAnomalia());
        }
    }
}
