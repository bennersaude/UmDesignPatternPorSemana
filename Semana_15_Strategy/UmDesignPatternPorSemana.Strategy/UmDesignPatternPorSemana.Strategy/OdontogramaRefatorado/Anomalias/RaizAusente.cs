using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmDesignPatternPorSemana.Strategy.OdontogramaRefatorado.Anomalias
{

    public class RaizAusente : IAnomalia
    {
        public bool EstaPresente(DadosAnomaliasDto dados)
        {
            return dados.AusenciaRaiz;
        }

        public ImpressaoAnomaliaDto ObterAnomalia()
        {
            return new ImpressaoAnomaliaDto { OcultarRaiz = true };
        }
    }
}
