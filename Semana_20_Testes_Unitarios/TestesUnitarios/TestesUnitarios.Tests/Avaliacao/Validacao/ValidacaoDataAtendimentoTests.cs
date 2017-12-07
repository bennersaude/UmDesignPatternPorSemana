using System;
using NSubstitute;
using NUnit.Framework;
using TestesUnitarios.Avaliacao.Entidades;
using TestesUnitarios.Avaliacao.Validacao;

namespace TestesUnitarios.Tests.Avaliacao.Validacao
{
    [TestFixture]
    public class ValidacaoDataAtendimentoTests
    {
        private const string MENSAGEM_VALIDACAO = "Data atendimento invalida";
        private ValidacaoDataAtendimento validacao;
        private IGuiaProperties guia;

        [SetUp]
        public void Setup()
        {
            validacao = new ValidacaoDataAtendimento();
            guia = Substitute.For<IGuiaProperties>();
        }

        [Test]
        public void Deve_retornar_mensagem_validacao_quando_data_atendimento_maior_que_hoje()
        {
            guia.DataAtendimento = DateTime.Today.AddDays(124);
            Assert.AreEqual(MENSAGEM_VALIDACAO, validacao.Validar(guia));
        }

        [Test]
        public void Deve_retornar_mensagem_validacao_quando_data_atendimento_menor_que_data_minima()
        {
            guia.DataAtendimento = new DateTime(1999, 1, 1);
            Assert.AreEqual(MENSAGEM_VALIDACAO, validacao.Validar(guia));
        }

        [Test]
        public void Deve_retornar_mensagem_validacao_quando_data_atendimento_eh_nula()
        {
            Assert.AreEqual(MENSAGEM_VALIDACAO, validacao.Validar(guia));
        }

        [Test]
        public void Nao_deve_retornar_mensagem_quando_data_atendimento_ok()
        {
            guia.DataAtendimento = DateTime.Today.AddDays(-1);
            Assert.IsNull(validacao.Validar(guia));
        }
    }
}