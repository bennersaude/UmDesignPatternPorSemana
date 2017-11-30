using System.Collections.Generic;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using TestesUnitarios.EnvioLote;
using TestesUnitarios.EnvioLote.ValidacaoLote;

namespace TestesUnitarios.Tests.EnvioLote.ValidacaoLote
{
    [TestFixture]
    public class ValidacaoLoteTests
    {
        private ValidacaoLoteGuias validacaoLoteGuias;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            validacaoLoteGuias = new ValidacaoLoteGuias();
        }

        [Test]
        public void Deve_chamar_todas_validacoes()
        {
            var expected = new List<ValidacaoDto>
            {
                new ValidacaoDto
                {
                    Resultado = false,
                    Mensagem = "Lote possui mais de 100 guias."
                },
                new ValidacaoDto
                {
                    Resultado = false,
                    Mensagem = "Lote possui guia sem evento."
                },
                new ValidacaoDto
                {
                    Resultado = false,
                    Mensagem = "Lote possui guias com quantidade de eventos zerados."
                }
            };

            var lote = new Lote
            {
                Guias = new List<Guia>
                {
                    new Guia
                    {
                        Eventos = new List<Evento>
                        {
                            new Evento
                            {
                                Quantidade = 0
                            }
                        }
                    },
                    new Guia
                    {
                        Eventos = new List<Evento>()
                    }
                }
            };

            for (var i = 0; i < 100; i++)
            {
                lote.Guias.Add(new Guia {Eventos = new List<Evento> {new Evento {Quantidade = 1} } });
            }

            var validacoes = validacaoLoteGuias.ValidarLote(lote);

            validacoes.Should().HaveCount(3);

            expected.ShouldBeEquivalentTo(validacoes);
        }
    }
}