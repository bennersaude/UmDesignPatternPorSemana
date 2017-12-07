using System;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Avaliacao.Validacoes
{
    public class ValidacaoData : IValidacaoGuia
    {
        public bool Validar(IGuia guia)
        {
            var dataMinima = new DateTime(2000,01,01);
            return (guia.DataAtendimento > dataMinima) && (guia.DataAtendimento <= DateTime.Today);
        }

        public string ObterMensagemErro()
        {
            return "Data de atendimento inválida";
        }
    }
}
