using NUnit.Framework;
using System;
using System.Collections.Generic;
using TestesUnitarios.NumeroRomano;

namespace TestesUnitarios.Tests._2.NumerosRomanos
{
    [TestFixture]
    public class NumeroRomanoTests
    {
        [Test]
        public void Deve_Transformar_X_Em_10()
        {
            var conversor = new ConversorNumeroRomano();
            var actual = conversor.Converter('X');
            Assert.AreEqual(10, actual);
        }

        [Test]
        public void Deve_Transformar_II_Em_2()
        {
            var conversor = new ConversorNumeroRomano();
            var actual = conversor.Converter("II");
            Assert.AreEqual(2, actual);
        }

        [Test]
        public void Deve_Retornar_ArgumentException()
        {
            var conversor = new ConversorNumeroRomano();
            var exception = Assert.Throws<ArgumentException>(() => conversor.Converter('P'));
            Assert.AreEqual("Número inválido!", exception.Message);
        }

        [Test]
        public void Deve_Transformar_L_Em_50()
        {
            var conversor = new ConversorNumeroRomano();
            var actual = conversor.Converter('L');
            Assert.AreEqual(50, actual);
        }

        [Test]
        public void Deve_Transformar_C_Em_100()
        {
            var conversor = new ConversorNumeroRomano();
            var actual = conversor.Converter('C');
            Assert.AreEqual(100, actual);
        }

        [Test]
        public void Deve_Transformar_D_Em_500()
        {
            var conversor = new ConversorNumeroRomano();
            var actual = conversor.Converter('D');
            Assert.AreEqual(500, actual);
        }

        [Test]
        public void Deve_Transformar_M_Em_1000()
        {
            var conversor = new ConversorNumeroRomano();
            var actual = conversor.Converter('M');
            Assert.AreEqual(1000, actual);
        }
    }
}
