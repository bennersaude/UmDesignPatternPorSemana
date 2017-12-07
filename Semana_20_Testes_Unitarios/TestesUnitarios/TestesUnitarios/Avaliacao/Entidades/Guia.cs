using Benner.Tecnologia.Common;
using System;

namespace TestesUnitarios.Avaliacao.Entidades
{
    public class Guia : EntityBase<Guia>, IGuiaProperties
    {
        public DateTime? DataAtendimento { get; set; }
        public bool? IndicadorDeclaracaoObitoRn { get; set; }
        public string NumeroDeclaracaoObito { get; set; }
    }
}
