using System;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Avaliacao.Validacao
{
    public class ValidacaoDataAtendimento : IValidacao
    {
        private const int MENOR_ANO = 2000;
        private const int MENOR_MES = 1;
        private const int MENOR_DIA = 1;

        public string Validar(IGuiaProperties guia)
        {
            var menorData = new DateTime(MENOR_ANO, MENOR_MES, MENOR_DIA);

            return !guia.DataAtendimento.HasValue || guia.DataAtendimento > DateTime.Today || guia.DataAtendimento < menorData
                ? "Data atendimento invalida"
                : null;
        }
    }
}
