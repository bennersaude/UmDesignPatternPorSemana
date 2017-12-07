using System;
using System.Collections.Generic;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Avaliacao.Business.Validacoes
{
    public class DataAtendimento : IValidacoes
    {
        public string Validar(IGuiaProperties guia)
        {
            if (!guia.DataAtendimento.HasValue) return string.Empty;

            if (guia.DataAtendimento > DateTime.Today)
            {
                return "Data de atendimento maior que hoje";
            }
            if (guia.DataAtendimento < ValoresConfiguracao.DataMinimaAtendimentoGuia)
            {
                return "Data de atendimento menor do que a permitida";
            }

            return string.Empty;
        }
    }
}