using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using TestesUnitarios.Avaliacao;
using TestesUnitarios.Avaliacao.Entidades;
using TestesUnitarios.Avaliacao.Validacao;

namespace TestesUnitarios.Tests.Avaliacao
{
    [TestFixture]
    public class ProcessamentoGuiaTests
    {
        private ProcessamentoGuia processamentoGuia;
        private IValidacaoGuia validacaoGuia;
        private IServicoEnvioGuias servicoEnvio;

        private IGuiaProperties guia;

        [SetUp]
        public void Setup()
        {
            validacaoGuia = Substitute.For<IValidacaoGuia>();
            servicoEnvio = Substitute.For<IServicoEnvioGuias>();
            servicoEnvio.ClearReceivedCalls();

            guia = Substitute.For<IGuiaProperties>();

            processamentoGuia = new ProcessamentoGuia(validacaoGuia, servicoEnvio);
        }

        [Test]
        public void Nao_deve_enviar_para_servico_caso_validacao_retorne_mensagem_erro()
        {
            validacaoGuia.ObterValidacoes(guia).Returns(new List<string> {"fjhrgh"});
            processamentoGuia.Processar(guia);

            servicoEnvio.DidNotReceiveWithAnyArgs().Enviar(Arg.Any<IGuiaProperties>());
        }

        [Test]
        public void Deve_enviar_para_servico_caso_guia_nao_possua_nenhuma_mensagem_validacao()
        {
            validacaoGuia.ObterValidacoes(Arg.Any<IGuiaProperties>()).Returns(new List<string>());
            processamentoGuia.Processar(guia);

            servicoEnvio.Received(1).Enviar(guia);
        }
    }
}