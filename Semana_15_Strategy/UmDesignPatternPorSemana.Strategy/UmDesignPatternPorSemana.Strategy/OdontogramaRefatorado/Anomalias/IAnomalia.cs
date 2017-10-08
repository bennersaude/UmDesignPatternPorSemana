using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmDesignPatternPorSemana.Strategy.OdontogramaRefatorado.Anomalias
{
    public interface IAnomalia
    {
        bool EstaPresente(DadosAnomaliasDto dados);
        ImpressaoAnomaliaDto ObterAnomalia();
    }
}
