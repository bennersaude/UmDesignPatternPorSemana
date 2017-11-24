using NUnit.Framework;
using TestesUnitarios.CalculoFrete;

namespace TestesUnitarios.Tests.CalculoFrete
{
    [TestFixture]
    public class CalculoFreteTests
    {
        [TestCase(TipoFrete.PAC, 10, 1.5)]
        [TestCase(TipoFrete.PAC, 100, 25)]
        [TestCase(TipoFrete.Sedex, 10, 4)]
        [TestCase(TipoFrete.Sedex, 100, 70)]
        [TestCase(TipoFrete.Transportadora, 1000, 350)]
        [TestCase(TipoFrete.Transportadora, 100, 30)]
        [TestCase(TipoFrete.Retirada, 100, 0)]
        public void Deve_calcular_valor_frete_corretamente(TipoFrete tipoFrete, int quilometros, decimal esperado)
        {
            var obtido = new TestesUnitarios.CalculoFrete.CalculoFrete().Calcular(tipoFrete, quilometros);

            Assert.AreEqual(esperado, obtido);
        }
    }
}