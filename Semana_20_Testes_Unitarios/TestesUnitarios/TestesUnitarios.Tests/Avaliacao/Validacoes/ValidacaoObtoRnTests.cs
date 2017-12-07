using NUnit.Framework;
using TestesUnitarios.Avaliacao.Validacoes;

namespace TestesUnitarios.Tests.Avaliacao.Validacoes
{
    [TestFixture]
    public class ValidacaoObtoRnTests
    {
        private ValidacaoObtoRn validacao;

        [TestFixtureSetUp]
        protected void FixtureSetup()
        {
            validacao = new ValidacaoObtoRn();
        }

        [Test]
        public void Deve_retotornar_true_nao_for_obto_rn()
        {
            var result = validacao.Validar(new GuiaFake
            {
                IndicadorDeclaracaoObitoRn = false
            });

            Assert.AreEqual(result, true);
        }

        [Test]
        public void Deve_retotornar_false_se_obto_rn()
        {
            var result = validacao.Validar(new GuiaFake
            {
                IndicadorDeclaracaoObitoRn = true,
                NumeroDeclaracaoObito = "123"
            });

            Assert.AreEqual(result, true);
        }
    }
}