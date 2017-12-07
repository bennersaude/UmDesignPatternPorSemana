using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using TestesUnitarios.Avaliacao.Business;
using TestesUnitarios.Avaliacao.Dao;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Tests.Avaliacao.Business
{
    [TestFixture]
    public class ValidacaoGuiaTests
    {
        private ValidacaoGuia validacaoGuia;
        private IDespesasGuiaDao despesasGuiaDAO;
        private IGuiaProperties guia;
        private IDespesasGuiaProperties despesaGuia;

        //private static IEnumerable Guia
        //{
        //    get
        //    {
        //        yield return new TestCaseData(
        //            guiaDataInferior
        //        ).SetName("Deve validar se data é menor que 2000");

        //        yield return new TestCaseData(
        //            new Guia()
        //            {
        //                //DataAtendimento = new DateTime(2018, 1, 1)
        //            }
        //        ).SetName("Deve validar se data é maior que data atual");
        //    }
        //}

        [TestFixtureSetUp]
        public void TextFixtureSetUp()
        {
            despesaGuia = Substitute.For<IDespesasGuiaProperties>();
            despesasGuiaDAO = Substitute.For<IDespesasGuiaDao>();
            despesasGuiaDAO.ObterDespesasDaGuia(Arg.Any<long>()).Returns(new List<IDespesasGuiaProperties>() { });
            validacaoGuia = new ValidacaoGuia(despesasGuiaDAO);
        }

        [Test]
        public void Deve_validar_se_data_esta_eh_menor_que_2000()
        {
            guia = Substitute.For<IGuiaProperties>();
            guia.DataAtendimento = new DateTime(1999, 1, 1);
            guia.Handle = 1;
            guia.NumeroDeclaracaoObito = "";

            var expected = new List<string>() { "Data de atendimento inválida" };
            var actual = validacaoGuia.ValidarGuia(guia);
            actual.ShouldBeEquivalentTo(expected);
        }

        [Test]
        public void Deve_validar_se_data_esta_maior_que_data_atual()
        {
            guia = Substitute.For<IGuiaProperties>();
            guia.DataAtendimento = new DateTime(2018, 1, 1);
            guia.Handle = 1;
            guia.NumeroDeclaracaoObito = "";

            var expected = new List<string>() { "Data de atendimento inválida" };
            var actual = validacaoGuia.ValidarGuia(guia);
            actual.ShouldBeEquivalentTo(expected);
        }

        [Test]
        public void Deve_validar_se_campo_numero_declaracao_obito_esta_preenchido()
        {
            var guia = Substitute.For<IGuiaProperties>();
            guia.DataAtendimento = new DateTime(2017, 1, 1);
            guia.NumeroDeclaracaoObito = "";
            guia.IndicadorDeclaracaoObitoRn = true;
            guia.Handle = 1;

            var expected = new List<string>() { "Campo numero declaracao obito deve ser preenchido" };
            var actual = validacaoGuia.ValidarGuia(guia);
            actual.ShouldBeEquivalentTo(expected);
        }

        [Test]
        public void Deve_validar_se_guia_esta_invalida()
        {
            despesasGuiaDAO.ObterDespesasDaGuia(Arg.Any<long>()).Returns(new List<IDespesasGuiaProperties>() { despesaGuia });

            var guia = Substitute.For<IGuiaProperties>();
            guia.DataAtendimento = new DateTime(2017, 1, 1);
            guia.NumeroDeclaracaoObito = "";
            guia.Handle = 1;

            var expected = new List<string>() { "Guia inválida" };
            var actual = validacaoGuia.ValidarGuia(guia);
        }
    }
}