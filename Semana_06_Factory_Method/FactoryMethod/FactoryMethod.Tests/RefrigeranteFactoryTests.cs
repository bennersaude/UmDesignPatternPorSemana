using NUnit.Framework;

namespace FactoryMethod.Tests
{
    [TestFixture]
    public class RefrigeranteFactoryTests
    {
        private RefrigeranteFactory refrigeranteFactory;

        [SetUp]
        public void Setup()
        {
            refrigeranteFactory = new RefrigeranteFactory();
        }

        [Test]
        public void Deve_retornar_refrigerante_kola_quando_tipo_igual_k()
        {
            var refrigerante = refrigeranteFactory.FazerRefrigerante("k");
            Assert.IsInstanceOf<RefrigeranteCola>(refrigerante);
        }

        [Test]
        public void Deve_retornar_refrigerante_phanta_quando_tipo_igual_p()
        {
            var refrigerante = refrigeranteFactory.FazerRefrigerante("p");
            Assert.IsInstanceOf<RefrigeranteLaranja>(refrigerante);
        }

        [Test]
        public void Deve_retornar_null_quando_tipo_diferente_de_k_ou_p()
        {
            var refrigerante = refrigeranteFactory.FazerRefrigerante("z");
            Assert.IsNull(refrigerante);
        }
    }
}