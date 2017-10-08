using System.Collections.Generic;
using UmDesignPatternPorSemana.Strategy.OdontogramaRefatorado;
using UmDesignPatternPorSemana.Strategy.OdontogramaRefatorado.Anomalias;

namespace UmDesignPatternPorSemana.Strategy.OdontogramaLegado
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
            if (dados.AusenciaCoroa) yield return new ImpressaoAnomaliaDto { OcultarCoroa = true };
            if (dados.AusenciaRaiz) yield return new ImpressaoAnomaliaDto { OcultarRaiz = true };
            if (dados.DenteIncluso) yield return new ImpressaoAnomaliaDto { AjusteAltura = "dente-incluso" };
            if (dados.GiroVersao) yield return new ImpressaoAnomaliaDto { Icone = "icone-giro-versao" };
        }
    }
}
