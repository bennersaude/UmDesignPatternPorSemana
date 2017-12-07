using System;
using System.Security.Cryptography.X509Certificates;
using Benner.Tecnologia.Common;

namespace TestesUnitarios.Avaliacao.Entidades
{
    public interface IGuia
    {
        DateTime? DataAtendimento { get; set; }
        bool? IndicadorDeclaracaoObitoRn { get; set; }
        string NumeroDeclaracaoObito { get; set; }
        long HandleLong { get; set; }
    }
}