using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections;
using System.Linq;
using TestesUnitarios.Avaliacao.Business.Excecoes;
using TestesUnitarios.Avaliacao.Business.Validacao;
using TestesUnitarios.Avaliacao.Entidades;
using TestesUnitarios.Tests.Avaliacao.Entidades;

namespace TestesUnitarios.Tests.Avaliacao.Business.Validacao
{
    [TestFixture]
    public class ValidacaoGuiaTests
    {
        private static IEnumerable Guias
        {
            get
            {
                yield return new TestCaseData(
                    new GuiaMock
                    {
                        DataAtendimento = DateTime.Today.AddDays(1),
                        IndicadorDeclaracaoObitoRn = false
                    },
                    typeof(DataAtendimentoInvalidaException)
                ).SetName("Deve invalidar guia com data atendimento maior que hj");
                yield return new TestCaseData(
                    new GuiaMock
                    {
                        DataAtendimento = new DateTime(1999, 12, 25),
                        IndicadorDeclaracaoObitoRn = false
                    },
                    typeof(DataAtendimentoInvalidaException)
                ).SetName("Deve invalidar guia com data atenidmento menor que a valida");
                yield return new TestCaseData(
                    null,
                    typeof(GuiaNulaException)
                ).SetName("Deve invalidar guia nula");
                yield return new TestCaseData(
                    new GuiaMock
                    {
                        IndicadorDeclaracaoObitoRn = false
                    },
                    typeof(GuiaNulaException)
                ).SetName("Deve invalidar guia com data atendimento nula");
                yield return new TestCaseData(
                    new GuiaMock
                    {
                        DataAtendimento = DateTime.Today,
                        IndicadorDeclaracaoObitoRn = true,
                        NumeroDeclaracaoObito = string.Empty
                    },
                    typeof(NumeroDeclaracaoObitoException)
                ).SetName("Deve invalidar guia com IndicadorObito mas sem NumeroDeclaracao");
            }
        }
        [TestCaseSource("Guias")]
        public void Deve_Invalidar_Guia_Invalida(IGuiaProperties guia, Type tipo)
        {
            var validacao = new ValidacaoGuia();
            var retorno = validacao.ValidarGuia(guia);
            var erros = retorno.Erros.ToList();

            Assert.IsFalse(retorno.Sucesso);

            erros.Should().NotBeNull();
            erros.Should().NotBeEmpty();
            Assert.IsInstanceOf(tipo, erros.First());
        }

        [Test]
        public void Deve_Validar_Guia_DataAtendimento_Valida()
        {
            var guia = new GuiaMock
            {
                DataAtendimento = DateTime.Today,
                IndicadorDeclaracaoObitoRn = false
            };

            var validacao = new ValidacaoGuia();
            var retorno = validacao.ValidarGuia(guia);
            var erros = retorno.Erros;

            Assert.IsTrue(retorno.Sucesso);
            Assert.IsEmpty(erros);
        }

        private static IEnumerable GuiasObito
        {
            get
            {
                yield return new TestCaseData(
                    new GuiaMock
                    {
                        DataAtendimento = DateTime.Today,
                        IndicadorDeclaracaoObitoRn = true,
                        NumeroDeclaracaoObito = "ehumastringessenumero!"
                    }
                ).SetName("Deve validar guia com indicadorObito marcado e numeroObito preenchido");
                yield return new TestCaseData(
                    new GuiaMock
                    {
                        DataAtendimento = DateTime.Today,
                        IndicadorDeclaracaoObitoRn = false,
                        NumeroDeclaracaoObito = string.Empty
                    }
                ).SetName("Deve validar guia sem IndicadorObito mas com NumeroObito preenchido");
            }
        }
        [TestCaseSource("GuiasObito")]
        public void Deve_Validar_Guia_Indicador_Numero_obito_Valida(IGuiaProperties guia)
        {
            var validacao = new ValidacaoGuia();
            var retorno = validacao.ValidarGuia(guia);
            var erros = retorno.Erros;

            Assert.IsTrue(retorno.Sucesso);
            Assert.IsEmpty(erros);
        }
    }
}