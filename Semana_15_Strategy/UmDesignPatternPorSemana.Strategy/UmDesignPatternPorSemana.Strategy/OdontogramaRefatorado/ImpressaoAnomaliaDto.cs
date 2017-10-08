using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmDesignPatternPorSemana.Strategy.OdontogramaRefatorado
{
    public class ImpressaoAnomaliaDto
    {
        public bool OcultarCoroa { get; set; }
        public bool OcultarRaiz { get; set; }
        public string Icone { get; set; }
        public string AjusteAltura { get; set; }
    }
}
