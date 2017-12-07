using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Tests.Avaliacao
{
    public class GuiaFake : IGuia
    {
        public DateTime? DataAtendimento { get; set; }
        public bool? IndicadorDeclaracaoObitoRn { get; set; }
        public string NumeroDeclaracaoObito { get; set; }
        public long HandleLong { get; set; }
    }
}
