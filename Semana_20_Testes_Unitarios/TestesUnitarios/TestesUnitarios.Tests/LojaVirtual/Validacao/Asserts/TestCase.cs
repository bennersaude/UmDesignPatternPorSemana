using System;
using NUnit.Framework;

namespace TestesUnitarios.Tests.LojaVirtual.Validacao.Asserts
{
    [TestFixture]
    public class TestCase
    {
        [TestCase(
            typeof(ParametrosSistemaEntidade),
            false,
            TestName = "Deve retornar parametros que acessam o banco"
        )]
        [TestCase(
            typeof(ParametrosSistemaLocal),
            true,
            TestName = "Deve retornar parametros fakes"
        )]
        public void Deve_retornar_parametros_corretamente(Type expected, bool debug)
        {
            var factory = new FactoryParametrosSistemas();
            Assert.IsInstanceOf(expected, factory.ObterParametros(debug));
        }
    }
}
