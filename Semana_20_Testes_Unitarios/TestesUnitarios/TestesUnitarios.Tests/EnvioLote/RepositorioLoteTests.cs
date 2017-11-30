using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using TestesUnitarios.EnvioLote;
using TestesUnitarios.EnvioLote.ValidacaoLote;

namespace TestesUnitarios.Tests.EnvioLote
{
    [TestFixture]
    public class RepositorioLoteTests
    {
        private IServicoEnvioLote servicoEnvioLote;
        private ILoteDao loteDao;
        private IValidacaoLoteGuias validacaoLoteGuias;
        private RepositorioLote repositorioLote;
        private IList<ValidacaoDto> listaValidacoes;

        private Lote loteInvalido;
        private Lote loteValido;
        private Lote loteSalvo;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            loteInvalido = new Lote();
            loteValido = new Lote
            {
                Guias = new List<Guia>
                {
                    new Guia
                    {
                        NumeroGuia = "1"
                    },
                    new Guia
                    {
                        NumeroGuia = "2"
                    }
                }
            };

            var resposta = new RespostaEnvioLoteDto
            {
                GlosasLote = new List<string>
                {
                    "ErroLote"
                },
                GlosasGuia = new List<RespostaEnvioLoteGuiaDto>
                {
                    new RespostaEnvioLoteGuiaDto
                    {
                        GlosasGuia = new List<string>
                        {
                            "ErroGuia1"
                        },
                        NumeroGuia = "1"
                    },
                    new RespostaEnvioLoteGuiaDto
                    {
                        GlosasGuia = new List<string>
                        {
                            "ErroGuia2"
                        },
                        NumeroGuia = "2"
                    }
                }
            };

            servicoEnvioLote = Substitute.For<IServicoEnvioLote>();
            servicoEnvioLote.Enviar(loteValido).Returns(resposta);

            loteDao = Substitute.For<ILoteDao>();

            loteDao.When(x => x.Salvar(loteValido)).Do(args => loteSalvo = args.Arg<Lote>());

            validacaoLoteGuias = Substitute.For<IValidacaoLoteGuias>();

            listaValidacoes = new List<ValidacaoDto> {new ValidacaoDto {Resultado = false, Mensagem = "Erro"}};

            validacaoLoteGuias.ValidarLote(loteInvalido).Returns(listaValidacoes);
            validacaoLoteGuias.ValidarLote(loteValido).Returns(new List<ValidacaoDto>());

            repositorioLote = new RepositorioLote(servicoEnvioLote, loteDao, validacaoLoteGuias);
        }

        [Test]
        public void Deve_retornar_as_glosas_de_validacoes()
        {
            var result = repositorioLote.Salvar(loteInvalido);

            Assert.IsTrue(result.Any());

            Assert.AreEqual(result, listaValidacoes);
        }

        [Test]
        public void Deve_fazer_o_processo_de_salvar_do_lote()
        {
            var expected = new Lote
            {
                Glosas = new List<string>
                {
                    "ErroLote"
                },
                Guias = new List<Guia>
                {
                    new Guia
                    {
                        NumeroGuia = "1",
                        Glosas = new List<string>
                        {
                            "ErroGuia1"
                        }
                    },
                    new Guia
                    {
                        NumeroGuia = "2",
                        Glosas = new List<string>
                        {
                            "ErroGuia2"
                        }
                    }
                }
            };

            var result = repositorioLote.Salvar(loteValido);

            Assert.IsFalse(result.Any());

            expected.ShouldBeEquivalentTo(loteSalvo);
        }
    }
}