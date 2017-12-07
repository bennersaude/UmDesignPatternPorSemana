using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System;
using TestesUnitarios.Avaliacao.Business;
using TestesUnitarios.Avaliacao.Dao;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Tests.Avaliacao.Business
{
    [TestFixture]
    public class ProcessamentoGuiasTests
    {
        private IValidadorGuias validador;
        private IServicoEnvioGuias envioGuias;

        private RespostaServicoDto respostaServicoComSucesso;
        private IGuiaProperties guiaValida;
        private IGuiaProperties guiaInvalida;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            var dao = Substitute.For<IDao<IGuiaProperties>>();

            respostaServicoComSucesso = new RespostaServicoDtoFake().ObterRespostaComSucesso();
            guiaValida = new GuiaFake(dao).ObterGuiaValida();
            guiaInvalida = new GuiaFake(dao).ObterGuiaDataAtendimentoInvalida();

            validador = Substitute.For<IValidadorGuias>();

            envioGuias = Substitute.For<IServicoEnvioGuias>();
            envioGuias.Enviar(Arg.Any<IGuiaProperties>()).Returns(respostaServicoComSucesso);
        }

        [Test]
        public void DeveEnviarGuiaSeElaForValida()
        {
            validador.GuiaEhValida(Arg.Any<IGuiaProperties>()).Returns(true);

            var processamentoGuia = new ProcessamentoGuias(validador, envioGuias);

            var resultado = processamentoGuia.Processar(guiaValida);

            envioGuias.Received(1).Enviar(Arg.Any<IGuiaProperties>());
            resultado.ShouldBeEquivalentTo(respostaServicoComSucesso);
        }

        [Test]
        public void NaoDeveEnviarGuiaSeElaForInvalida()
        {
            validador.GuiaEhValida(Arg.Any<IGuiaProperties>()).Returns(false);

            var processamentoGuia = new ProcessamentoGuias(validador, envioGuias);

            Assert.Throws<Exception>(() => processamentoGuia.Processar(guiaInvalida));
            envioGuias.Received(0).Enviar(Arg.Any<IGuiaProperties>());
        }

        [TearDown]
        public void TearDown()
        {
            envioGuias.ClearReceivedCalls();
        }
    }
}