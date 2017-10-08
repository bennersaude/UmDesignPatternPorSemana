using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmDesignPatternPorSemana.Strategy.OdontogramaRefatorado.Anomalias
{

    public class DenteIncluso : IAnomalia
    {
        public bool EstaPresente(DadosAnomaliasDto dados)
        {
            return dados.DenteIncluso;
        }

        public ImpressaoAnomaliaDto ObterAnomalia()
        {
            return new ImpressaoAnomaliaDto { AjusteAltura = "dente-incluso" };
        }
    }
}
