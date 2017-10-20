using FluentAssertions;
using NSubstitute;
using NSubstitute.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesUnitarios.NotaFiscal;
using NotaFiscalModel = TestesUnitarios.NotaFiscal.NotaFiscal;

namespace TestesUnitarios.Tests.NotaFiscal
{
    public class EnvioFake : IEnvio
    {
        public NotaFiscalModel NotaFiscalEnviada { get; private set; }

        public void EnviarEmail(NotaFiscalModel nota)
        {
            NotaFiscalEnviada = nota;
        }
    }

    [TestFixture]
    public class GeracaoNotaFiscalTests
    {
        private ICalculadoraNotaFiscal calculadora;
        private IEnvio envio;
        private INotaFiscalDao dao;
        private NotaFiscalModel actual;
        private GeracaoNotaFiscal gerador;

        [SetUp]
        protected void FixtureSetup()
        {
            calculadora = Substitute.For<ICalculadoraNotaFiscal>();
            envio = Substitute.For<IEnvio>();
            dao = Substitute.For<INotaFiscalDao>();
            dao.When(x => x.Salvar(Arg.Any<NotaFiscalModel>()))
               .Do(args => PreencherNotaSalva(args, actual));

            gerador = new GeracaoNotaFiscal(calculadora, envio, dao);
        }

        [Test]
        public void Deve_gerar_nota_fiscal_corretamente()
        {
            var pedido = new Pedido("Mario", 1, 100);
            var expected = new NotaFiscalModel(pedido.Cliente, 94, DateTime.Today);
            calculadora.Calcular(Arg.Any<Pedido>()).Returns(94);

            gerador.Gerar(pedido);

            envio.Received(1).EnviarEmail(actual);
            actual.ShouldBeEquivalentTo(expected);
        }

        public void outroteste()
        {
            calculadora.Calcular(Arg.Any<Pedido>()).Returns(95);
        }

        private void PreencherNotaSalva(CallInfo args, NotaFiscalModel actual)
        {
            var nota = args.Arg<NotaFiscalModel>();

            if (nota == null) actual = null;

            actual = args.Arg<NotaFiscalModel>();
        }
    }
}
