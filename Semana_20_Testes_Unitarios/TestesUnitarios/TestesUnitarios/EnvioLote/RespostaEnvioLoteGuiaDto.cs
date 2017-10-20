using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesUnitarios.EnvioLote
{

    public class RespostaEnvioLoteGuiaDto
    {
        public string NumeroGuia { get; set; }
        public IEnumerable<string> GlosasGuia { get; set; }
    }
}
