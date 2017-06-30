using NUnit.Framework;
using UmDesignPatternPorSemana.Proxy.ProtectionProxy.Stubs;

namespace UmDesignPatternPorSemana.Proxy.DynamicProxy
{
    [TestFixture]
    public class UrlTests
    {
        [Test]
        public void Deve_gerar_url_para_interface_corretamente()
        {
            var actual = new Url().For<IGuiaController, Guia>(c => c.Detalhes(1));
            Assert.AreEqual("minha-aplicacao/Guia/Detalhes/1", actual);
        }

        [Test]
        public void Deve_gerar_url_para_classe_corretamente()
        {
            var actual = new Url().For<GuiaController, Guia>(c => c.Detalhes(1));
            Assert.AreEqual("minha-aplicacao/Guia/Detalhes/1", actual);
        }
    }
}