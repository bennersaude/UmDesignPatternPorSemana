using NSubstitute;
using NUnit.Framework;
using TestesUnitarios.Avaliacao.Business;
using TestesUnitarios.Avaliacao.Dao;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Tests.Avaliacao.Business
{
    [TestFixture]
    public class ValidadorGuiaTests
    {
        private IValidadorGuias validador;
        private IGuiaProperties guiaComDataInvalida;
        private IGuiaProperties guiaComNumeroNaoPreenchido;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            validador = new ValidadorGuia();

            var dao = Substitute.For<IDao<IGuiaProperties>>();
            guiaComDataInvalida = new GuiaFake(dao).ObterGuiaDataAtendimentoInvalida();
            guiaComNumeroNaoPreenchido = new GuiaFake(dao).ObterGuiaNumeroDeclaracaoObitoInvalido();
        }

        [Test]
        public void DeveRetornarFalseSeDataAtendimentoMaiorQueHoje()
        {
            Assert.IsFalse(validador.GuiaEhValida(guiaComDataInvalida));
        }

        [Test]
        public void NumeroDeclaracaoObitoDeveEstarPreenchidoSeIndicadorObtiroForVerdadeiro()
        {
            Assert.IsFalse(validador.GuiaEhValida(guiaComNumeroNaoPreenchido));
        }
    }
}