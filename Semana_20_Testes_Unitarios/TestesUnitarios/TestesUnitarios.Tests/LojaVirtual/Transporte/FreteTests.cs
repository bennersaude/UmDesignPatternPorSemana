using NUnit.Framework;
using TestesUnitarios.LojaVirtual.Transporte;

namespace TestesUnitarios.Tests.LojaVirtual.Transporte
{
    [TestFixture]
    public class FreteTests
    {
        [Test]
        public void Deve_calcular_PAC_menos_de_100_km()
        {
            var frete = new CalculadoraFrete();
            var actual = frete.Calcular(90, TipoFrete.PAC);

            Assert.AreEqual(13.5, actual);
        }

        [TestCase(90, TipoFrete.PAC, 13.5, TestName = "Cálculo PAC < 100KM")]
        [TestCase(110, TipoFrete.PAC, 27.5, TestName = "Cálculo PAC > 100KM")]
        [TestCase(100, TipoFrete.PAC, 25, TestName = "Cálculo PAC = 100KM")]
        [TestCase(90, TipoFrete.SEDEX, 36, TestName = "Cálculo SEDEX < 100KM")]
        [TestCase(110, TipoFrete.SEDEX, 77, TestName = "Cálculo SEDEX > 100KM")]
        [TestCase(100, TipoFrete.SEDEX, 70, TestName = "Cálculo SEDEX = 100KM")]
        [TestCase(390, TipoFrete.TRANSPORTADORA, 117, TestName = "Cálculo TRANSPORTADORA < 400KM")]
        [TestCase(410, TipoFrete.TRANSPORTADORA, 143.5, TestName = "Cálculo TRANSPORTADORA > 400KM")]
        [TestCase(400, TipoFrete.TRANSPORTADORA, 120, TestName = "Cálculo TRANSPORTADORA = 400KM")]
        [TestCase(0, TipoFrete.RETIRADA_NO_LOCAL, 0, TestName = "Cálculo RETIRADA NA LOJA")]
        public void Deve_calcular_frete(double distancia, TipoFrete tipoFrete, double valorEsperado)
        {
            var frete = new CalculadoraFrete();
            var actual = frete.Calcular(distancia, tipoFrete);
            Assert.AreEqual(valorEsperado, actual);
        }
    }
}
