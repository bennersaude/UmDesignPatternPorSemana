using System;
using System.Collections.Generic;
using TestesUnitarios.Avaliacao.Business.Excecoes;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Avaliacao.Business.Validacao
{
    public class ValidacaoGuia
    {
        private readonly DateTime _dataminimapermitida = new DateTime(2000, 01, 01);

        public RespostaProcessamentoDto ValidarGuia(IGuiaProperties guia)
        {
            var exceptions = new List<Exception>();
            var naoTemErros = true;

            var retornoValidacao = ValidarDadosNulos(guia);
            if (retornoValidacao != null)
                return new RespostaProcessamentoDto
                {
                    Erros = new List<Exception>
                    {
                        retornoValidacao
                    },
                    Sucesso = false
                };

            retornoValidacao = ValidarDataAtendimento(guia);
            if (retornoValidacao != null)
            {
                naoTemErros = false;
                exceptions.Add(retornoValidacao);
            }

            retornoValidacao = ValidarDeclaracaoObito(guia);
            if (retornoValidacao != null)
            {
                naoTemErros = false;
                exceptions.Add(retornoValidacao);
            }

            return new RespostaProcessamentoDto
            {
                Erros = exceptions,
                Sucesso = naoTemErros
            };
        }

        private Exception ValidarDadosNulos(IGuiaProperties guia)
        {
            if (guia != null && guia.DataAtendimento != null)
            {
                return null;
            }

            return new GuiaNulaException();
        }

        private Exception ValidarDataAtendimento(IGuiaProperties guia)
        {
            var dataHoje = DateTime.Today;
            if (dataHoje >= guia.DataAtendimento && _dataminimapermitida < guia.DataAtendimento)
                return null;

            return new DataAtendimentoInvalidaException(
                string.Format("Data de Atendimento deve ser Menor que a data de Hoje {0} e Maior que {1}!",
                dataHoje,
                _dataminimapermitida));
        }

        private Exception ValidarDeclaracaoObito(IGuiaProperties guia)
        {
            if (guia.IndicadorDeclaracaoObitoRn == null
                || !Convert.ToBoolean(guia.IndicadorDeclaracaoObitoRn))
                return null;

            return !string.IsNullOrEmpty(guia.NumeroDeclaracaoObito)
                ? null
                : new NumeroDeclaracaoObitoException();
        }
    }
}