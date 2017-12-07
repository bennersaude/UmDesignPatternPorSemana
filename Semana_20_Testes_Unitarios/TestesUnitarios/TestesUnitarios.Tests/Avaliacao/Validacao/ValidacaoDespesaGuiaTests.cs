using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using TestesUnitarios.Avaliacao.Dao;
using TestesUnitarios.Avaliacao.Entidades;
using TestesUnitarios.Avaliacao.Validacao;

namespace TestesUnitarios.Tests.Avaliacao.Validacao
{
    [TestFixture]
    public class ValidacaoDespesaGuiaTests
    {
        private const string MENSAGEM_VALIDACAO = "Tipo redução acréscimo não pode ser maior que 100";
        private const long HANDLE_GUIA = 2;
        private IDespesasGuiaDao despesasGuiaDao;
        private ValidacaoDespesaGuia validacaoDespesaGuia;
        private IGuiaProperties guia;

        [SetUp]
        public void Setup()
        {
            despesasGuiaDao = Substitute.For<IDespesasGuiaDao>();
            guia = Substitute.For<IGuiaProperties>();
            guia.Handle = HANDLE_GUIA;

            validacaoDespesaGuia = new ValidacaoDespesaGuia(despesasGuiaDao);
        }

        [Test]
        public void Deve_retornar_null_quando_guia_nao_possui_despesa()
        {
            despesasGuiaDao.ObterDespesasDaGuia(HANDLE_GUIA).Returns(new List<IDespesasGuiaProperties>());
            Assert.IsNull(validacaoDespesaGuia.Validar(guia));
        }

        [TestCase(8898d, TipoReducaoAcrescimo.ItemSemReducaoAcrescimo, null)]
        [TestCase(90d, TipoReducaoAcrescimo.ItemSemReducaoAcrescimo, null)]
        [TestCase(1d, TipoReducaoAcrescimo.ItemSemReducaoAcrescimo, null)]
        [TestCase(1d, TipoReducaoAcrescimo.ItemAcrescimo, null)]
        [TestCase(1d, TipoReducaoAcrescimo.ItemReducao, null)]
        [TestCase(1089d, TipoReducaoAcrescimo.ItemReducao, MENSAGEM_VALIDACAO)]
        [TestCase(1089d, TipoReducaoAcrescimo.ItemAcrescimo, MENSAGEM_VALIDACAO)]
        public void Deve_validar_corretamente(decimal valorReducaoAcrescimo, TipoReducaoAcrescimo tipoReducaoAcrescimo, string expected)
        {
            var despesaGuia = Substitute.For<IDespesasGuiaProperties>();
            despesaGuia.TipoReducaoAcrescimo = tipoReducaoAcrescimo;
            despesaGuia.ValorReducaoAcrescimo = valorReducaoAcrescimo;
            var despesasGuiaLista = new List<IDespesasGuiaProperties> {despesaGuia};
            despesasGuiaDao.ObterDespesasDaGuia(HANDLE_GUIA).Returns(despesasGuiaLista);

            Assert.AreEqual(expected, validacaoDespesaGuia.Validar(guia));
        }
    }
}