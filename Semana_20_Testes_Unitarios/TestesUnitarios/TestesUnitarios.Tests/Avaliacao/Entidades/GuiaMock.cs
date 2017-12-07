using System;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Tests.Avaliacao.Entidades
{
    public class GuiaMock : IGuiaProperties
    {
        public DateTime? DataAtendimento { get; set; }
        public bool? IndicadorDeclaracaoObitoRn { get; set; }
        public string NumeroDeclaracaoObito { get; set; }
    }
}