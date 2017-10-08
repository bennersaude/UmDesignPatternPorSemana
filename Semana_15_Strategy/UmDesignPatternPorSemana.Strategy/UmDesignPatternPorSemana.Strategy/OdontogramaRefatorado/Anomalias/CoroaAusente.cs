using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmDesignPatternPorSemana.Strategy.OdontogramaRefatorado.Anomalias
{

    public class CoroaAusente : IAnomalia
    {
        public bool EstaPresente(DadosAnomaliasDto dados)
        {
            return dados.AusenciaCoroa;
        }

        public ImpressaoAnomaliaDto ObterAnomalia()
        {
            return new ImpressaoAnomaliaDto { OcultarCoroa = true };
        }
    }
}
