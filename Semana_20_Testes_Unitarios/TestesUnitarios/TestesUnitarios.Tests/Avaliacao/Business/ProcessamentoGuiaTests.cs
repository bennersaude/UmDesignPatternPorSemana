using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TestesUnitarios.Avaliacao.Business;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Tests.Avaliacao.Business
{
    [TestFixture]
    public class ProcessamentoGuiaTests
    {
        private IValidacaoGuia _validacaoGuia;
        private IServicoEnvioGuias _servicoEnvioGuias;
        private ISalvarGuia _salvarGuia;
        private ProcessamentoGuia _processamentoGuia;

        private static IEnumerable EnviosServico
        {
            get
            {
                yield return new TestCaseData(
                    false,
                    new List<string> { "Erro no processamento "},
                    0,
                    (long?)null
                ).SetName("Se guia invalida deve retornar erros de validacao e finalizar processamento");

                yield return new TestCaseData(
                    true,
                    new List<string>(),
                    1,
                    (long?)1
                ).SetName("Se guia valida deve enviar");
            }
        }

        private static IEnumerable RespostasServico
        {
            get
            {
                yield return new TestCaseData(
                    false,
                    new List<string> { "Erro no processamento " },
                    0,
                    (long?)null
                ).SetName("Se envio com erro deve retornar erros e finalizar processamento");

                yield return new TestCaseData(
                    true,
                    new List<string>(),
                    1,
                    (long?)1
                ).SetName("Se envio sucesso deve salvar guia e retornar dto de processamento com sucesso");
            }
        }

        [SetUp]
        public void SetUp()
        {
            _validacaoGuia = Substitute.For<IValidacaoGuia>();
            _servicoEnvioGuias = Substitute.For<IServicoEnvioGuias>();
            _salvarGuia = Substitute.For<ISalvarGuia>();

            _processamentoGuia = new ProcessamentoGuia(_validacaoGuia, _servicoEnvioGuias, _salvarGuia);
        }

        [TestCaseSource("EnviosServico")]
        public void Deve_enviar_guia_corretamente(bool sucesso, List<string> erros, int enviou, long? handle)
        {
            var guia = Substitute.For<IGuiaProperties>();
            guia.Handle = 1;

            _validacaoGuia.Validar(Arg.Any<IGuiaProperties>()).Returns(new RespostaProcessamentoDto { Sucesso = sucesso, Erros = erros });
            _servicoEnvioGuias.EnviarGuia(Arg.Any<IGuiaProperties>()).Returns(new RespostaServicoDto { Sucesso = sucesso, Erros = erros });

            var respostaProcessamentoDto = _processamentoGuia.Processar(guia);

            var respostaEsperada = new RespostaProcessamentoDto
            {
                Erros = erros,
                Sucesso = sucesso,
                Handle = handle
            };

            respostaProcessamentoDto.ShouldBeEquivalentTo(respostaEsperada);
            _servicoEnvioGuias.Received(enviou).EnviarGuia(Arg.Any<IGuiaProperties>());
        }

        [TestCaseSource("RespostasServico")]
        public void Deve_processar_resposta_servico_corretamente(bool sucesso, List<string> erros, int salvou, long? handle)
        {
            var guia = Substitute.For<IGuiaProperties>();
            guia.Handle = 1;

            _validacaoGuia.Validar(Arg.Any<IGuiaProperties>()).Returns(new RespostaProcessamentoDto { Sucesso = true, Erros = new List<string>() });
            _servicoEnvioGuias.EnviarGuia(Arg.Any<IGuiaProperties>()).Returns(new RespostaServicoDto { Sucesso = sucesso, Erros = erros });

            var respostaProcessamentoDto = _processamentoGuia.Processar(guia);

            var respostaEsperada = new RespostaProcessamentoDto
            {
                Erros = erros,
                Sucesso = sucesso,
                Handle = handle
            };

            respostaProcessamentoDto.ShouldBeEquivalentTo(respostaEsperada);
            _salvarGuia.Received(salvou).Salvar(Arg.Any<IGuiaProperties>());
        }
    }
}
