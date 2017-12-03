using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using TestesUnitarios.EnvioLote;

namespace TestesUnitarios.Tests.LoteGuias
{
    [TestFixture]
    public class ServicoLoteGuiasTests
    {
        private IValidacaoLoteGuias _validacaoLoteGuias;
        private IServicoEnvioLote _servicoEnvioLote;
        private ISalvarLoteGuias _salvarLoteGuias;
        private Lote _loteSalvo;
        private ServicoLoteGuias _servicoLoteGuias;

        private static IEnumerable Envios
        {
            get
            {
                yield return new TestCaseData(
                    new List<ValidacaoDto> { new ValidacaoDto { Resultado = false } },
                    0
                ).SetName("Nao deve enviar se lote invalido");

                yield return new TestCaseData(
                    new List<ValidacaoDto>(),
                    1
                ).SetName("Deve enviar se lote valido");
            }
        }

        [SetUp]
        public void SetUp()
        {
            _validacaoLoteGuias = Substitute.For<IValidacaoLoteGuias>();

            _servicoEnvioLote = Substitute.For<IServicoEnvioLote>();
            _servicoEnvioLote.Enviar(Arg.Any<Lote>()).Returns(GerarRespostaEnvio());

            _salvarLoteGuias = Substitute.For<ISalvarLoteGuias>();
            _salvarLoteGuias.When(d => d.Salvar(Arg.Any<Lote>())).Do(args => _loteSalvo = args.Arg<Lote>());

            _servicoLoteGuias = new ServicoLoteGuias(_servicoEnvioLote, _validacaoLoteGuias, _salvarLoteGuias);
        }

        [TestCaseSource("Envios")]
        public void Deve_enviar_lote_corretamente(List<ValidacaoDto> validacoes, int expected)
        {
            _validacaoLoteGuias.Validar(Arg.Any<Lote>()).Returns(validacoes);

            _servicoLoteGuias.ProcessarLote(new Lote { Guias = new List<Guia>() });

            _servicoEnvioLote.Received(expected).Enviar(Arg.Any<Lote>());
        }

        [Test]
        public void Deve_mapear_e_salvar_lote_corretamente()
        {
            var expected = GerarLoteEsperado();
            var lote = new Lote { Guias = new List<Guia> { new Guia { NumeroGuia = "1" }, new Guia { NumeroGuia = "2" } } };

            _validacaoLoteGuias.Validar(Arg.Any<Lote>()).Returns(new List<ValidacaoDto>());

            _servicoLoteGuias.ProcessarLote(lote);

            _salvarLoteGuias.Received(1).Salvar(Arg.Any<Lote>());
            _loteSalvo.ShouldBeEquivalentTo(expected);
        }

        private RespostaEnvioLoteDto GerarRespostaEnvio()
        {
            return new RespostaEnvioLoteDto
            {
                GlosasLote = new List<string> { "Glosa Lote 1", "Glosa Lote 2" },
                GlosasGuia = new List<RespostaEnvioLoteGuiaDto>
                {
                    new RespostaEnvioLoteGuiaDto
                    {
                        NumeroGuia = "1",
                        GlosasGuia = new List<string> {"Glosa Guia 1"}
                    },

                    new RespostaEnvioLoteGuiaDto
                    {
                        NumeroGuia = "2",
                        GlosasGuia = new List<string> {"Glosa Guia 2"}
                    }
                }
                
            };
        }

        private Lote GerarLoteEsperado()
        {
            return new Lote
            {
                Glosas = new List<string> { "Glosa Lote 1", "Glosa Lote 2" },
                Guias = new List<Guia>
                {
                    new Guia
                    {
                        NumeroGuia = "1",
                        Glosas = new List<string> {"Glosa Guia 1"}
                    },

                    new Guia
                    {
                        NumeroGuia = "2",
                        Glosas = new List<string> {"Glosa Guia 2"}
                    }
                }

            };
        }
    }
}
