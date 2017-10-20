using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesUnitarios.EnvioLote
{
    public class Guia
    {
        public string NumeroGuia { get; set; }
        public IEnumerable<Evento> Eventos { get; set; }
        public IEnumerable<string> Glosas { get; set; }
    }
}
