using NUnit.Framework;
using TestesUnitarios.Avaliacao.Business;

namespace TestesUnitarios.Tests.Avaliacao.Business
{
    [TestFixture]
    public class ServicoEnvioGuiasTests
    {
        private IServicoEnvioGuias envioGuias;

        [Test]
        public void DeveSalvarGuia()
        {
            envioGuias = new ServicoEnvioGuias();

            //envioGuias.Enviar();


        }
    }
}