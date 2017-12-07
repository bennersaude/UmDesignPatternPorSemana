using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using TestesUnitarios.Avaliacao.Business.Validacoes;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Tests.Avaliacao.Business.Validacoes
{
    [TestFixture]
    public class ValidacoesGuiaTests
    {
        private IValidacoesFactory validacoesFactory;
        private IValidacoesGuia validacoesGuia;
        private IValidacoes validacao1;
        private IValidacoes validacao2;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            validacoesFactory = Substitute.For<IValidacoesFactory>();

            validacao1 = Substitute.For<IValidacoes>();
            validacao2 = Substitute.For<IValidacoes>();

            validacao1.Validar(Arg.Any<IGuiaProperties>()).Returns("Deu erro");

            var listaValidacoes = new List<IValidacoes>
            {
                validacao1,
                validacao2
            };
            
            validacoesFactory.Obter().Returns(listaValidacoes.ToList());

            validacoesGuia = new ValidacoesGuia(validacoesFactory);
        }

        [Test]
        public void Deve_obter_todas_validacoes_e_chamar()
        {
            var guia = Substitute.For<IGuiaProperties>();

            var erros = validacoesGuia.Validar(guia);

            validacao1.Received(1).Validar(guia);
            validacao2.Received(1).Validar(guia);

            Assert.IsTrue(erros.Any());

            Assert.AreEqual("Deu erro", erros.First());
        }
    }
}