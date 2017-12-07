using System;
using Benner.Tecnologia.Common;

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
