using NSubstitute;
using NUnit.Framework;
using TestesUnitarios.Avaliacao.Entidades;
using TestesUnitarios.Avaliacao.Validacao;

namespace TestesUnitarios.Tests.Avaliacao.Validacao
{
    [TestFixture]
    public class ValidacaoIndicadorObitoTests
    {
        private const string MENSAGEM_VALIDACAO = "Numero Declaração Óbito deve estar preenchido";

        [TestCase(true, null, MENSAGEM_VALIDACAO)]
        [TestCase(true, "", MENSAGEM_VALIDACAO)]
        [TestCase(true, "   ", MENSAGEM_VALIDACAO)]
        [TestCase(true, "FEFEFHU", null)]
        [TestCase(null, null, null)]
        [TestCase(false, null, null)]
        [TestCase(false, "", null)]
        [TestCase(false, " ", null)]
        [TestCase(false, "fefekfk", null)]
        public void Deve_validar_corretamente(bool? indicadorObito, string numeroDeclaracao, string expected)
        {
            var validacaoIndicadorObito = new ValidacaoIndicadorObito();
            var guiaProperties = Substitute.For<IGuiaProperties>();
            guiaProperties.IndicadorDeclaracaoObitoRn = indicadorObito;
            guiaProperties.NumeroDeclaracaoObito = numeroDeclaracao;

            Assert.AreEqual(expected, validacaoIndicadorObito.Validar(guiaProperties));
        }
    }
}