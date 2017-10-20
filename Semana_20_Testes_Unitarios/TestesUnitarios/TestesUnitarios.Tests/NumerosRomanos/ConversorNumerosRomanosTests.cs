using FluentAssertions;
using NUnit.Framework;
using System;
using TestesUnitarios.NumerosRomanos;

namespace TestesUnitarios.Tests.NumerosRomanos
{
    [TestFixture]
    public class ConversorNumerosRomanosTests
    {
        private ConversorNumerosRomanos conversor;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            conversor = new ConversorNumerosRomanos();
        }

        [TestCase('I', 1, TestName ="Deve converter I para 1")]
        [TestCase('V', 5)]
        [TestCase('X', 10)]
        public void Deve_converter_numero_romano_para_inteiro(char numeroRomano, int expected)
        {
            var actual = conversor.Converter(numeroRomano);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Deve_converter_V_para_5()
        {
            var actual = conversor.Converter('V');
            Assert.AreEqual(5, actual);
        }

        [Test]
        public void Deve_gerar_excecao_quando_numero_invalido()
        {
            var exception = Assert.Throws<ArgumentException>(() => conversor.Converter('P'));
            Assert.AreEqual("Numero invalido", exception.Message);
        }

        [Test]
        public void Deve_converter_II_para_2()
        {
            var actual = conversor.Converter("II");
            Assert.AreEqual(2, actual);
        }
    }
}
