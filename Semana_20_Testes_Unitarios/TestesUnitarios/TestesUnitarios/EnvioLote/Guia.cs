using System.Collections.Generic;

namespace TestesUnitarios.EnvioLote
{
    public class Guia
    {
        public string NumeroGuia { get; set; }
        public IEnumerable<Evento> Eventos { get; set; }
        public IEnumerable<string> Glosas { get; set; }
    }
}