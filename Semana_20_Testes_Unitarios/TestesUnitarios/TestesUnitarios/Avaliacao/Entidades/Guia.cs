using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Benner.Tecnologia.Business;
using Benner.Tecnologia.Common;

namespace TestesUnitarios.Avaliacao.Entidades
{
    public class Guia : EntityBase<Guia>, IGuiaProperties
    {
        public DateTime? DataAtendimento { get; set; }
        public bool? IndicadorDeclaracaoObitoRn { get; set; }
        public string NumeroDeclaracaoObito { get; set; }
    }
}
