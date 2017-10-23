using NUnit.Framework;
using TestesUnitarios.NotaFiscal;

namespace TestesUnitarios.Tests.NotaFiscal
{
    [TestFixture]
    public class CalculadoraNotaFiscalTests
    {
        [Test]
        public void Deve_gerar_nota_fiscal_corretamente()
        {
            var gerador = new CalculadoraNotaFiscal();
            var actual = gerador.Calcular(new Pedido("Hitor Helmans", 20, 5));

            Assert.AreEqual(94, actual);
        }
    }
}
