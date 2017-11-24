using System.Collections.Generic;
using NUnit.Framework;
using TestesUnitarios.EnvioLote;

namespace TestesUnitarios.Tests.EnvioLote
{
    [TestFixture]
    public class ValidacaoEnvioLoteTests
    {
        [Test]
        public void Deve_lancar_mensagem_lote_que_possui_mais_de_100_guias()
        {
            var validacao = new ValidacaoEnvioLote().Validar(ObterLote(150));

            Assert.IsFalse(validacao.Resultado);
            Assert.AreEqual("Não pode ter mais que 100", validacao.Mensagem);
        }

        [Test]
        public void Deve_lancar_mensagem_lote_que_possui_guias_sem_eventos()
        {
            var validacao = new ValidacaoEnvioLote().Validar(ObterLote(50));

            Assert.IsFalse(validacao.Resultado);
            Assert.AreEqual("Não pode ter guias sem eventos", validacao.Mensagem);
        }

        [Test]
        public void Deve_lancar_mensagem_lote_que_possui_eventos_com_quantidade_0()
        {
            var lote = ObterLote(50);
            foreach (var guia in lote.Guias)
                guia.Eventos = new List<Evento> { new Evento()};

            var validacao = new ValidacaoEnvioLote().Validar(lote);

            Assert.IsFalse(validacao.Resultado);
            Assert.AreEqual("Não pode ter eventos com quantidade 0", validacao.Mensagem);
        }

        [Test]
        public void Deve_validar_lote_quando_todas_condicoes_ok()
        {
            var lote = ObterLote(50);
            foreach (var guia in lote.Guias)
                guia.Eventos = new List<Evento> { new Evento {Quantidade = 1} };

            var validacao = new ValidacaoEnvioLote().Validar(lote);

            Assert.IsTrue(validacao.Resultado);
        }

        private static Lote ObterLote(int quantidadeGuias)
        {
            var guias = new List<Guia>();
            for (var i = 0; i < quantidadeGuias; i++)
                guias.Add(new Guia());
            return new Lote {Guias = guias};
        }
    }
}