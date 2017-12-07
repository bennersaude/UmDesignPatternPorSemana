using System;

namespace TestesUnitarios.Avaliacao.Entidades
{
    public interface IGuiaProperties
    {
        DateTime? DataAtendimento { get; set; }
        bool? IndicadorDeclaracaoObitoRn { get; set; }
        string NumeroDeclaracaoObito { get; set; }
    }
}
