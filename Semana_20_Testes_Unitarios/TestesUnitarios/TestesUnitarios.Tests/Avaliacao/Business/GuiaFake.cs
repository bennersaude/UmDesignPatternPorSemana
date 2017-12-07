using System;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Tests.Avaliacao.Business
{
    public class GuiaFake
    {
        public Guia ObterGuiaValida()
        {
            return new Guia()
            {
                DataAtendimento = DateTime.Now,
                IndicadorDeclaracaoObitoRn = false,
                NumeroDeclaracaoObito = "123"
            };
        }
    }
}
