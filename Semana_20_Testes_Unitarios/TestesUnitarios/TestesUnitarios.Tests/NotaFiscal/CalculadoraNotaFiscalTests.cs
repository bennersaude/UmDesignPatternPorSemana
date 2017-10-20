using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesUnitarios.NotaFiscal;

namespace TestesUnitarios.Tests.NotaFiscal
{
    [TestFixture]
    public class CalculadoraNotaFiscalTests
    {
        [Test]
        public void Deve_calcular_nota_fiscal_corretamente()
        {
            var gerador = new CalculadoraNotaFiscal();
            var actual = gerador.Calcular(new Pedido("Vitor Helmans", 20, 5));

            Assert.AreEqual(94, actual);
        }
    }
}
