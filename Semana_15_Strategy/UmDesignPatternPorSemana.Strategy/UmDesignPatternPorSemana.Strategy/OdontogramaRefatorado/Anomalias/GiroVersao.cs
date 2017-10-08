using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmDesignPatternPorSemana.Strategy.OdontogramaRefatorado.Anomalias
{

    public class GiroVersao : IAnomalia
    {
        public bool EstaPresente(DadosAnomaliasDto dados)
        {
            return dados.GiroVersao;
        }

        public ImpressaoAnomaliaDto ObterAnomalia()
        {
            return new ImpressaoAnomaliaDto { Icone = "icone-giro-versao" };
        }
    }
}
