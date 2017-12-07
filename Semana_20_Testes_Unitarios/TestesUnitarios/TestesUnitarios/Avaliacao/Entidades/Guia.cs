using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Benner.Tecnologia.Business;

namespace TestesUnitarios.Avaliacao.Entidades
{
    partial class Guia : BusinessEntity<Guia>
    {
        public DateTime? DataAtendimento { get; set; }
        public bool? IndicadorDeclaracaoObitoRn { get; set; }
        public string NumeroDeclaracaoObito { get; set; }
    }
}
