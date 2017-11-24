using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using TestesUnitarios.EnvioLote;

namespace TestesUnitarios.Tests.EnvioLote
{
    [TestFixture]
    public class ProcessoLoteTests
    {
        private IValidacaoEnvioLote validacaoEnvioLote;
        private IServicoEnvioLote servicoEnvioLote;
        private IRepositorioLote repositorioLote;
        private ProcessoLote processoLote;
        private Lote loteSalvo;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            validacaoEnvioLote = Substitute.For<IValidacaoEnvioLote>();
            servicoEnvioLote = Substitute.For<IServicoEnvioLote>();
            repositorioLote = Substitute.For<IRepositorioLote>();
        }

        [SetUp]
        public void Setup()
        {
            validacaoEnvioLote.ClearReceivedCalls();
            servicoEnvioLote.ClearReceivedCalls();
            repositorioLote.ClearReceivedCalls();
            repositorioLote.Salvar(Arg.Do<Lote>(l => loteSalvo = l));

            processoLote = new ProcessoLote(validacaoEnvioLote, servicoEnvioLote, repositorioLote);
        }

        [Test]
        public void Nao_deve_chamar_servico_envio_lote_quando_validacao_falha()
        {
            validacaoEnvioLote.Validar(Arg.Any<Lote>()).Returns(new ValidacaoDto {Resultado = false});

            processoLote.Processar(new Lote());

            servicoEnvioLote.DidNotReceiveWithAnyArgs().Enviar(Arg.Any<Lote>());
        }

        [Test]
        public void Deve_mapear_resposta_lote_corretamente()
        {
            validacaoEnvioLote.Validar(Arg.Any<Lote>()).Returns(new ValidacaoDto { Resultado = true });
            servicoEnvioLote.Enviar(Arg.Any<Lote>()).Returns(GerarRespostaEnvioLote());

            var loteEnviado = GerarLote();
            processoLote.Processar(loteEnviado);

            CollectionAssert.AreEquivalent(loteSalvo.Glosas, loteEnviado.Glosas);
            CollectionAssert.AreEquivalent(loteSalvo.Guias.First().Glosas, loteEnviado.Guias.First().Glosas);
        }

        private static Lote GerarLote()
        {
            return new Lote { Guias = new List<Guia> { new Guia{ NumeroGuia = "12" }}};
        }

        private static RespostaEnvioLoteDto GerarRespostaEnvioLote()
        {
            return new RespostaEnvioLoteDto
            {
                GlosasLote = new List<string> {"glosa lote"},
                GlosasGuia = new List<RespostaEnvioLoteGuiaDto>
                {
                    new RespostaEnvioLoteGuiaDto
                    {
                        NumeroGuia = "12",
                        GlosasGuia = new List<string> {"glosa guia"}
                    }
                }
            };
        }
    }
}