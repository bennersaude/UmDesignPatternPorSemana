using FluentAssertions;
using NUnit.Framework;
using TestesUnitarios.Avaliacao.Business;

namespace TestesUnitarios.Tests.Avaliacao.Business
{
    [TestFixture]
    public class ProcessamentoGuiasTests
    {
        [Test]
        public void DeveProcessarGuiaCorretamente()
        {
            var processamentoGuia = new ProcessamentoGuias();

            var guia = new GuiaFake().ObterGuiaValida();

            var resultado = processamentoGuia.Processar(guia);

            resultado.ShouldBeEquivalentTo(new RespostaProcessamentoDtoFake().ObterRespostaComSucesso());
        }
    }
}