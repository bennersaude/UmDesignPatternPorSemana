using System;

namespace TestesUnitarios.Avaliacao.Business.Excecoes
{
    public class GuiaNulaException : Exception
    {
        public GuiaNulaException()
            : base("Guia nula ou Data de Atendimento não Preenchido!")
        {
        }
    }
}