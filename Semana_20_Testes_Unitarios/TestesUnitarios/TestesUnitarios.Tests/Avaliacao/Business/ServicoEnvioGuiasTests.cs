using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using TestesUnitarios.Avaliacao.Business;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Tests.Avaliacao.Business
{
    [TestFixture]
    public class ServicoEnvioGuiasTests
    {
        private ServicoEnvioGuias servicoEnvioGuias;
        private IGuiaProperties guia;

        [SetUp]
        public void Setup()
        {
            servicoEnvioGuias = new ServicoEnvioGuias();
        }

        [Test]
        public void Deve_retornar_dto_com_resposta_false()
        {
            guia = Substitute.For<IGuiaProperties>();
            guia.Handle = 1;

            var expected = new RespostaServicoDto() { Sucesso = false };
            var actual = servicoEnvioGuias.EnviarGuia(guia);

            actual.ShouldBeEquivalentTo(expected);
        }

        [Test]
        public void Deve_retornar_dto_com_resposta_true()
        {
            guia = Substitute.For<IGuiaProperties>();
            guia.Handle = 2;

            var expected = new RespostaServicoDto() { Sucesso = true };
            var actual = servicoEnvioGuias.EnviarGuia(guia);

            actual.ShouldBeEquivalentTo(expected);
        }
    }
}