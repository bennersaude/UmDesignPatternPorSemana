using System.Collections;
using NUnit.Framework;

namespace TestesUnitarios.Tests.LojaVirtual.Validacao.Asserts
{
    [TestFixture]
    public class TestCaseSource
    {
        private static IEnumerable Pessoas
        {
            get
            {
                yield return new TestCaseData(
                    new Pessoa("João"),
                    new Pessoa("João"),
                    true
                ).SetName("Deve retornar true para pessoas com o mesmo nome");

                yield return new TestCaseData(
                    new Pessoa("João"),
                    new Pessoa("Pedro"),
                    false
                ).SetName("Deve retornar false para pessoas com o nome diferente");
            }
        }

        [TestCaseSource("Pessoas")]
        public void Deve_comparar_pessoas_corretamente(Pessoa fulano, Pessoa ciclano, bool expected)
        {
            Assert.That(fulano.Equals(ciclano), Is.EqualTo(expected));
        }
    }
}
