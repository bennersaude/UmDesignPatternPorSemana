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
            var processamentoGuia = new ProcessamentoGuias();

            var dao = Substitute.For<IDao<IGuiaProperties>>();

            var guia = new GuiaFake(dao).ObterGuiaValida();

            var resultado = processamentoGuia.Processar(guia);

            resultado.ShouldBeEquivalentTo(new RespostaProcessamentoDtoFake().ObterRespostaComSucesso());
        }
    }
}