using Benner.Tecnologia.Common;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesUnitarios.Avaliacao.Business;
using TestesUnitarios.Avaliacao.Dao;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Tests.Avaliacao.Business
{
    [TestFixture]
    public class ValidacaoGuiaTests
    {
        private IDespesasGuiaDao _despesasGuiaDao;
        private IValidacaoGuia _validacaoGuia;

        private static IEnumerable Validacoes
        {
            get
            {
                yield return new TestCaseData(
                    ObterGuia(DateTime.Now.AddDays(1), false),
                    "Data de atendimento inválida",
                    new List<IDespesasGuiaProperties>()
                ).SetName("Deve gerar erro se guia possuir data de atendimento maior que a data atual");

                yield return new TestCaseData(
                    ObterGuia(new DateTime(1999,12,31), false),
                    "Data de atendimento inválida",
                    new List<IDespesasGuiaProperties>()
                ).SetName("Deve gerar erro se guia possuir data de atendimento menor que a data miníma");

                yield return new TestCaseData(
                    ObterGuia(DateTime.Now, true),
                    "Número da declaração de óbito deve ser preenchido",
                    new List<IDespesasGuiaProperties>()
                ).SetName("Deve gerar erro se indicador de óbito for verdadeiro e número vazio");

                yield return new TestCaseData(
                    ObterGuia(DateTime.Now, false),
                    "Valor da redução de acréscimo não pode ser maior que 100",
                    ObterDespesas()
                ).SetName("Deve gerar erro se guia possuir despesa diferente 'ItemSemReducaoAcrescimo' e 'ValorReducaoAcrescimo' maior que 100  ");
            }
        }

        [SetUp]
        public void SetUp()
        {
            _despesasGuiaDao = Substitute.For<IDespesasGuiaDao>();

            _validacaoGuia = new ValidacaoGuia(_despesasGuiaDao);
        }

        [TestCaseSource("Validacoes")]
        public void Deve_validar_guia_corretamente(IGuiaProperties guia, string erro, List<IDespesasGuiaProperties> despesasGuia)
        {
            _despesasGuiaDao.ObterDespesasDaGuia(Arg.Any<long>()).Returns(despesasGuia);
            var respostaProcessamento = _validacaoGuia.Validar(guia);

            var respostaEsperada = new RespostaProcessamentoDto
            {
                Erros = new List<string> { erro },
                Sucesso = false
            };

            respostaProcessamento.Erros.Should().ContainSingle();
            respostaProcessamento.ShouldBeEquivalentTo(respostaEsperada);
        }

        private static IGuiaProperties ObterGuia(DateTime dataAtendimento, bool indicadorObito)
        {
            var guia = Substitute.For<IGuiaProperties>();
            guia.Handle = 1;
            guia.DataAtendimento = dataAtendimento;
            guia.IndicadorDeclaracaoObitoRn = indicadorObito;

            return guia;
        }

        private static IEnumerable<IDespesasGuiaProperties> ObterDespesas()
        {
            var despesas = new List<IDespesasGuiaProperties>();
            var despesa = Substitute.For<IDespesasGuiaProperties>();
            despesa.TipoReducaoAcrescimo = TipoReducaoAcrescimo.ItemReducao;
            despesa.ValorReducaoAcrescimo = 101;

            despesas.Add(despesa);

            return despesas;
        }
    }
}
