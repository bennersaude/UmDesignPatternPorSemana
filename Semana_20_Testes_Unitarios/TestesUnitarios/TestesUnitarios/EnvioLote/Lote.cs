using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesUnitarios.EnvioLote
{
    public class Lote
    {
        public Lote()
        {
            Guias = new List<Guia>();
        }

        public IList<Guia> Guias { get; set; }
        public IEnumerable<string> Glosas { get; set; }
    }
}
