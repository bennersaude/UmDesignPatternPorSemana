using FluentAssertions;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TestesUnitarios.EnvioLote;

namespace TestesUnitarios.Tests.LoteGuias
{
    [TestFixture]
    public class ValidacaoLoteGuiasTests
    {
        private IValidacaoLoteGuias _validacaoLoteGuias;

        private static IEnumerable Validacoes
        {
            get
            {
                yield return new TestCaseData(
                    105,
                    new List<Evento> { new Evento { Quantidade = 1 } },
                    "Lote não pode possuir mais que 100 guias para envio"
                ).SetName("Deve gerar validacao com mensagem que lote nao pode possuir mais de 100 guias");

                yield return new TestCaseData(
                    1,
                    null,
                    "Lote não pode possuir guias sem eventos para envio"
                ).SetName("Deve gerar validacao com mensagem que lote nao pode possuir guias sem eventos, quando lista de eventos nulo");

                yield return new TestCaseData(
                    1,
                    new List<Evento>(),
                    "Lote não pode possuir guias sem eventos para envio"
                ).SetName("Deve gerar validacao com mensagem que lote nao pode possuir guias sem eventos, quando lista de evntos vazia");

                yield return new TestCaseData(
                    1,
                    new List<Evento> { new Evento { Quantidade = 0 } },
                    "Lote não pode possuir eventos com quantidade 0 para envio"
                ).SetName("Deve gerar validacao com mensagem que lote nao pode possuir eventos com quantidade 0");
            }
        }


        [SetUp]
        public void SetUp()
        {
            _validacaoLoteGuias = new ValidacaoLoteGuias();
        }

        [TestCaseSource("Validacoes")]
        public void Deve_validar_lote_guias_corretamente(int quantidadeGuias, List<Evento> eventos, string mensagem)
        {
            var lote = GerarLote(quantidadeGuias, eventos);
            var validacoesLote = _validacaoLoteGuias.Validar(lote);
            var validacaoEsperada = new ValidacaoDto
            {
                Mensagem = mensagem,
                Resultado = false
            };

            validacoesLote.Should().ContainSingle();
            validacoesLote.Single().ShouldBeEquivalentTo(validacaoEsperada);
        }

        private Lote GerarLote(int quantidadeGuias, List<Evento> eventos)
        {
            var lote = new Lote();
            var guias = new List<Guia>();

            for (int i = 0; i < quantidadeGuias; i++)
                guias.Add(new Guia { Eventos = eventos });

            lote.Guias = guias;

            return lote;
        }
    }
}
