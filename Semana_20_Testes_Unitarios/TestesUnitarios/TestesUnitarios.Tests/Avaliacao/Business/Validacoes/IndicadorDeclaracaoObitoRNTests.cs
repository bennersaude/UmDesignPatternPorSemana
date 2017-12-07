using NSubstitute;
using NUnit.Framework;
using TestesUnitarios.Avaliacao.Business.Validacoes;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Tests.Avaliacao.Business.Validacoes
{
    [TestFixture]
    public class IndicadorDeclaracaoObitoRNTests
    {
        private IndicadorDeclaracaoObitoRN indicadorDeclaracaoObitoRn;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            indicadorDeclaracaoObitoRn = new IndicadorDeclaracaoObitoRN();
        }

        [Test]
        public void Deve_ter_declaracao_de_obito_quando_indicador_for_verdadeiro()
        {
            var guia = Substitute.For<IGuiaProperties>();

            guia.IndicadorDeclaracaoObitoRn = true;
            guia.NumeroDeclaracaoObito = string.Empty;

            var respostaComErro = indicadorDeclaracaoObitoRn.Validar(guia);

            Assert.AreEqual("É necessário ter numero da declaracao do obito", respostaComErro);

            guia.NumeroDeclaracaoObito = "Obito";

            var resposta = indicadorDeclaracaoObitoRn.Validar(guia);

            Assert.IsEmpty(resposta);
        }
    }
}