using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TestesUnitarios.EnvioLote;
using TestesUnitarios.EnvioLote.ValidacaoLote;

namespace TestesUnitarios.Tests.EnvioLote.ValidacaoLote
{
    [TestFixture]
    public class ValidarQuantidadeEventoZeradaTests
    {
        private IValidacaoLote validacaoLote;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            validacaoLote = new ValidarQuantidadeEventoZerada();
        }

        [Test]
        public void Deve_validar_se_eventos_das_guias_tem_quantidade()
        {
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
                                Quantidade = 1
                            }
                        }
                    },
                    new Guia
                    {
                        Eventos = new List<Evento>
                        {
                            new Evento
                            {
                                Quantidade = 2
                            }
                        }
                    }
                }
            };

            var validacoesDto = new List<ValidacaoDto>();

            validacaoLote.Validar(lote, validacoesDto);

            Assert.IsFalse(validacoesDto.Any());
        }

        [Test]
        public void Deve_retornar_erro_se_eventos_das_guias_tiver_quantidade_0()
        {
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
                                Quantidade = 3
                            }
                        }
                    },
                    new Guia
                    {
                        Eventos = new List<Evento>
                        {
                            new Evento
                            {
                                Quantidade = 0
                            }
                        }
                    }
                }
            };

            var validacoesDto = new List<ValidacaoDto>();

            validacaoLote.Validar(lote, validacoesDto);

            Assert.IsTrue(validacoesDto.Any());
        }
    }
}