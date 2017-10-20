using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesUnitarios.EnvioLote
{

    public class RespostaEnvioLoteDto
    {
        public IEnumerable<string> GlosasLote { get; set; }
        public IEnumerable<RespostaEnvioLoteGuiaDto> GlosasGuia { get; set; }
    }
}
