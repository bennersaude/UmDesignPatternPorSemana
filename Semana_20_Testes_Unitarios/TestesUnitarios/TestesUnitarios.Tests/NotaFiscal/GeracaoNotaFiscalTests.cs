using System;
using NUnit.Framework;
using TestesUnitarios.NotaFiscal;
using FluentAssertions;
using NSubstitute;

namespace TestesUnitarios.Tests.NotaFiscal
{

    public class EnvioFake : IEnvio
    {
        public TestesUnitarios.NotaFiscal.NotaFiscal NotaFiscalEnviada { get; set; }

        public void EnviarEmail(TestesUnitarios.NotaFiscal.NotaFiscal nota)
        {
            NotaFiscalEnviada = nota;
        }
    }

    [TestFixture]
    public class GeracaoNotaFiscalTests
    {
        [Test]
        public void Deve_gerar_nota_fiscal_correamente()
        {
            var pedido = new Pedido("Mario", 1, 100);
            var expected = new TestesUnitarios.NotaFiscal.NotaFiscal(pedido.Cliente, 94, DateTime.Today);
            TestesUnitarios.NotaFiscal.NotaFiscal actual = null;
            var daoFake = Substitute.For<INotaFiscalDao>();
            var envioFake = Substitute.For<IEnvio>();

            //var envioFake = new EnvioFake();
            //var calculadora = new CalculadoraMock();

            daoFake.When(x => x.Salvar(Arg.Any<TestesUnitarios.NotaFiscal.NotaFiscal>())).Do(args => actual = args.Arg<TestesUnitarios.NotaFiscal.NotaFiscal>());

            var calculadora = Substitute.For<ICalculadoraNotaFiscal>();
            calculadora.Calcular(Arg.Any<Pedido>()).Returns(94);

            var gerador = new GeracaoNotaFiscal(calculadora, envioFake, daoFake);
            gerador.Gerar(pedido);

            envioFake.Received(1).EnviarEmail(actual);

            actual.ShouldBeEquivalentTo(expected);
            envioFake.NotaFiscalEnviada.Should().NotBeNull();
        }
    }
}
