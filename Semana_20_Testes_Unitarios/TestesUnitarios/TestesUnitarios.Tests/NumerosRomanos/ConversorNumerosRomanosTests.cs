using NUnit.Framework;
using System;
using TestesUnitarios.NumerosRomanos;

namespace TestesUnitarios.Tests.NumerosRomanos
{
    [TestFixture]
    public class ConversorNumerosRomanosTests
    {
        [Test]
        public void Deve_converter_I_para_1()
        {
            var conversor = new ConversorNumerosRomanos();
            var actual = conversor.Converter('I');
            Assert.AreEqual(1, actual);
        }

        [Test]
        public void Deve_converter_V_para_5()
        {
            var conversor = new ConversorNumerosRomanos();
            var actual = conversor.Converter('V');
            Assert.AreEqual(5, actual);
        }

        [Test]
        public void Deve_gerar_excecao_quando_numero_invalido()
        {
            var conversor = new ConversorNumerosRomanos();
            var exception = Assert.Throws<ArgumentException>(() => conversor.Converter('P'));
            Assert.AreEqual("Numero invalido", exception.Message);
        }

        [Test]
        public void Deve_converter_II_para_2()
        {
            var conversor = new ConversorNumerosRomanos();
            var actual = conversor.Converter("II");
            Assert.AreEqual(2, actual);
        }
    }
}
