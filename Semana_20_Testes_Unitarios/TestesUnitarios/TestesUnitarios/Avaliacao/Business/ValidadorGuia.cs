using System;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Avaliacao.Business
{
    public class ValidadorGuia : IValidadorGuias
    {
        public bool GuiaEhValida(IGuiaProperties guia)
        {
            return this.ValidarDataAtendimento(guia) && this.ValidarNumeroDeclaracaoObito(guia);
        }

        //todo usar strategy pra criar classes de validacoes
        private bool ValidarDataAtendimento(IGuiaProperties guia)
        {
            return guia.DataAtendimento > DateTime.Now;
        }

        private bool ValidarNumeroDeclaracaoObito(IGuiaProperties guia)
        {
            return guia.IndicadorDeclaracaoObitoRn == true && guia.NumeroDeclaracaoObito == string.Empty;
        }
    }
}