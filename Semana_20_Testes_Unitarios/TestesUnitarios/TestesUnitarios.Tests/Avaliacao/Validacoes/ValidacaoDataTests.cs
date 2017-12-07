using System;
using NUnit.Framework;
using TestesUnitarios.Avaliacao.Entidades;
using TestesUnitarios.Avaliacao.Validacoes;

namespace TestesUnitarios.Tests.Avaliacao.Validacoes
{
    [TestFixture]
    public class ValidacaoDataTests
    {
        private ValidacaoData validacao;

        [TestFixtureSetUp]
        protected void FixtureSetup()
        {
            validacao = new ValidacaoData();
        }

        [Test]
        public void Deve_retotornar_false_quando_data_invalida()
        {
            var result = validacao.Validar(new GuiaFake
            {
                DataAtendimento = new DateTime(1900, 01, 01)
            });

            Assert.AreEqual(result, false);
        }

        [Test]
        public void Deve_retotornar_true_quando_data_valida()
        {
            var result = validacao.Validar(new GuiaFake
            {
                DataAtendimento = new DateTime(2017, 12, 06)
            });

            Assert.AreEqual(result, true);
        }
    }
}