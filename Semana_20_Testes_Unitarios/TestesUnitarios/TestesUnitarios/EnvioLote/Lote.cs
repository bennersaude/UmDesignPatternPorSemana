using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesUnitarios.EnvioLote
{
    public class Lote
    {
        public IEnumerable<Guia> Guias { get; set; }
        public IEnumerable<string> Glosas { get; set; }
    }
}
