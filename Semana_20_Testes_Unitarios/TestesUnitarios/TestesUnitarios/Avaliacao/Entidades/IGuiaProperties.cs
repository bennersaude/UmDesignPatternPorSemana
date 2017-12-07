using Benner.Tecnologia.Common;
using System;

namespace TestesUnitarios.Avaliacao.Entidades
{
    public interface IGuiaProperties
    {
        Handle Handle { get; set; }
        DateTime? DataAtendimento { get; set; }
        bool? IndicadorDeclaracaoObitoRn { get; set; }
        string NumeroDeclaracaoObito { get; set; }
    }
}