using Benner.Tecnologia.Business;
using System;

namespace TestesUnitarios.Avaliacao.Entidades
{
    public class Guia : BusinessEntity<Guia>, IGuia
    {
        public DateTime? DataAtendimento { get; set; }
        public bool? IndicadorDeclaracaoObitoRn { get; set; }
        public string NumeroDeclaracaoObito { get; set; }
    }
}
