using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesUnitarios.CalculoSalario;

namespace TestesUnitarios.Tests.CalculoSalario
{
    [TestFixture]
    public class CalculoSalarioTests
    {
        [Test]
        public void Deve_calcular_desconto_para_desenvolvedor_que_ganha_3000()
        {
            var calculadora = new CalculadoraSalario();
            var funcionario = new Funcionario("Mario", 3000, Cargo.DESENVOLVEDOR);

            double salario = calculadora.Calcular(funcionario);
            Assert.AreEqual(2700, salario);
        }

        [Test]
        public void Deve_calcular_desconto_para_desenvolvedor_que_ganha_2900()
        {
            var calculadora = new CalculadoraSalario();
            var funcionario = new Funcionario("Mario", 2900, Cargo.DESENVOLVEDOR);

            double salario = calculadora.Calcular(funcionario);
            Assert.AreEqual(2610, salario);
        }

        [Test]
        public void Deve_calcular_desconto_para_desenvolvedor_que_ganha_4000()
        {
            var calculadora = new CalculadoraSalario();
            var funcionario = new Funcionario("Mario", 4000, Cargo.DESENVOLVEDOR);

            double salario = calculadora.Calcular(funcionario);
            Assert.AreEqual(3200, salario);
        }

        [Test]
        public void Deve_calcular_desconto_para_dba_que_ganha_4000()
        {
            var calculadora = new CalculadoraSalario();
            var funcionario = new Funcionario("Mario", 4000, Cargo.DBA);

            double salario = calculadora.Calcular(funcionario);
            Assert.AreEqual(3000, salario);
        }

        [Test]
        public void Deve_calcular_desconto_para_dba_que_ganha_2500()
        {
            var calculadora = new CalculadoraSalario();
            var funcionario = new Funcionario("Mario", 2500, Cargo.DBA);

            double salario = calculadora.Calcular(funcionario);
            Assert.AreEqual(2125, salario);
        }

        [Test]
        public void Deve_calcular_desconto_para_dba_que_ganha_2400()
        {
            var calculadora = new CalculadoraSalario();
            var funcionario = new Funcionario("Mario", 2400, Cargo.DBA);

            double salario = calculadora.Calcular(funcionario);
            Assert.AreEqual(2040, salario);
        }

    }
}
