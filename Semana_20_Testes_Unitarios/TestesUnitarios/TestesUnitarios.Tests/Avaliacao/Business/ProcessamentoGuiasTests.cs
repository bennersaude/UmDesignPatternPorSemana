using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using TestesUnitarios.Avaliacao.Business;
using TestesUnitarios.Avaliacao.Dao;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Tests.Avaliacao.Business
{
    [TestFixture]
    public class ProcessamentoGuiasTests
    {
        [Test]
        public void DeveProcessarGuiaCorretamente()
        {
            var validador = Substitute.For<IValidadorGuias>();
            validador.GuiaEhValida(Arg.Any<IGuiaProperties>()).Returns(true);

            var processamentoGuia = new ProcessamentoGuias(validador);

            var dao = Substitute.For<IDao<IGuiaProperties>>();

            var guia = new GuiaFake(dao).ObterGuiaValida();

            var resultado = processamentoGuia.Processar(guia);

            resultado.ShouldBeEquivalentTo(new RespostaProcessamentoDtoFake().ObterRespostaComSucesso());
        }
    }
}