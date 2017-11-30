using NSubstitute;
using NUnit.Framework;
using TestesUnitarios.CalculoFrete;
using TestesUnitarios.CalculoFrete.TiposFrete;

namespace TestesUnitarios.Tests.CalculoFrete
{
    [TestFixture]
    public class CalculoFreteTests
    {
        private ITipoFreteFactory tipoFreteFactory;
        private ICalculoFrete calculoFrete;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            tipoFreteFactory = Substitute.For<ITipoFreteFactory>();

            tipoFreteFactory.Obter(TiposFreteEnum.PAC).Returns(new PAC());
            tipoFreteFactory.Obter(TiposFreteEnum.Sedex).Returns(new Sedex());
            tipoFreteFactory.Obter(TiposFreteEnum.Transportadora).Returns(new Transportadora());
            tipoFreteFactory.Obter(TiposFreteEnum.RetiradaDoLocal).Returns(new RetiradaDoLocal());

            calculoFrete = new TestesUnitarios.CalculoFrete.CalculoFrete(tipoFreteFactory);
        }

        [TestCase(TiposFreteEnum.PAC, 99, 14.85)]
        [TestCase(TiposFreteEnum.PAC, 100, 25)]
        [TestCase(TiposFreteEnum.Sedex, 99, 39.6)]
        [TestCase(TiposFreteEnum.Sedex, 100, 70)]
        [TestCase(TiposFreteEnum.Transportadora, 399, 119.7)]
        [TestCase(TiposFreteEnum.Transportadora, 400, 140)]
        [TestCase(TiposFreteEnum.RetiradaDoLocal, 0, 0)]
        [TestCase(TiposFreteEnum.RetiradaDoLocal, 100, 0)]
        public void Deve_calcular_frete_corretamente(TiposFreteEnum tipoFrete, decimal quilometragem, decimal expected)
        {
            var result = calculoFrete.CalcularFrete(tipoFrete, quilometragem);

            Assert.AreEqual(expected, result);
        }
    }
}