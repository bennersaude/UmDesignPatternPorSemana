using System;
using NSubstitute;
using NUnit.Framework;
using TestesUnitarios.Avaliacao.Business;
using TestesUnitarios.Avaliacao.Business.Validacoes;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Tests.Avaliacao.Business.Validacoes
{
    [TestFixture]
    public class DataAtendimentoTests
    {
        private DataAtendimento dataAtendimento;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            dataAtendimento = new DataAtendimento();
        }

        [Test]
        public void Nao_deve_ter_data_menor_que_a_data_permitida()
        {
            var guia = Substitute.For<IGuiaProperties>();

            guia.DataAtendimento = ValoresConfiguracao.DataMinimaAtendimentoGuia;

            var retorno = dataAtendimento.Validar(guia);

            Assert.IsEmpty(retorno);

            guia.DataAtendimento = guia.DataAtendimento.Value.AddDays(-1);

            var retornoComErro = dataAtendimento.Validar(guia);

            Assert.AreEqual("Data de atendimento menor do que a permitida", retornoComErro);
        }

        [Test]
        public void Nao_deve_ter_data_maior_que_data_atual()
        {
            var guia = Substitute.For<IGuiaProperties>();

            guia.DataAtendimento = ValoresConfiguracao.DataMinimaAtendimentoGuia;

            var retorno = dataAtendimento.Validar(guia);

            Assert.IsEmpty(retorno);

            guia.DataAtendimento = guia.DataAtendimento.Value.AddDays(-1);

            var retornoComErro = dataAtendimento.Validar(guia);

            Assert.AreEqual("Data de atendimento menor do que a permitida", retornoComErro);
        }
    }
}