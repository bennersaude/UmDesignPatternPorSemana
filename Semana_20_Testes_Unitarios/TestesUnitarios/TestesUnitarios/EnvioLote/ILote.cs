using System.Collections.Generic;

namespace TestesUnitarios.EnvioLote
{
    public interface ILote
    {
        IEnumerable<string> Glosas { get; set; }
        IEnumerable<Guia> Guias { get; set; }
    }
}