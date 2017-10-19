using NUnit.Framework;
using TestesUnitarios.CalculoSalario;

namespace TestesUnitarios.Tests.CalculoSalario
{
    [TestFixture]
    public class CalculadoraSalarioTests
    {
        [Test]
        public void Deve_calcular_desconto_para_desenvolvedor_que_ganha_4000()
        {
            var calculadora = new CalculoraSalario();
            var funcionario = new Funcionario("Mario", 4000, Cargo.DESENVOLVEDOR);
            double salario = calculadora.Calcular(funcionario);

            Assert.AreEqual(3200, salario);
        }

        [Test]
        public void Deve_calcular_desconto_para_dba_que_ganha_3000()
        {
            var calculadora = new CalculoraSalario();
            var funcionario = new Funcionario("Fingolo", 3000, Cargo.DBA);
            double salario = calculadora.Calcular(funcionario);

            Assert.AreEqual(2250, salario);
        }
    }
}
