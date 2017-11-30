using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TestesUnitarios.EnvioLote;
using TestesUnitarios.EnvioLote.ValidacaoLote;

namespace TestesUnitarios.Tests.EnvioLote.ValidacaoLote
{
    [TestFixture]
    public class ValidarGuiasSemEventoTests
    {
        private IValidacaoLote validacaoLote;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            validacaoLote = new ValidarGuiasSemEvento();
        }

        [Test]
        public void Deve_validar_se_guias_do_lote_tem_evento()
        {
            var lote = new Lote
            {
                Guias = new List<Guia>
                {
                    new Guia
                    {
                        Eventos = new List<Evento>
                        {
                            new Evento()
                        }
                    },
                    new Guia
                    {
                        Eventos = new List<Evento>
                        {
                            new Evento()
                        }
                    }
                }
            };

            var validacoesDto = new List<ValidacaoDto>();

            validacaoLote.Validar(lote, validacoesDto);

            Assert.IsFalse(validacoesDto.Any());
        }

        [Test]
        public void Deve_retornar_erro_se_guias_do_lote_nao_tem_evento()
        {
            var lote = new Lote
            {
                Guias = new List<Guia>
                {
                    new Guia
                    {
                        Eventos = new List<Evento>
                        {
                            new Evento()
                        }
                    },
                    new Guia
                    {
                        Eventos = new List<Evento>()
                    }
                }
            };

            var validacoesDto = new List<ValidacaoDto>();

            validacaoLote.Validar(lote, validacoesDto);

            Assert.IsTrue(validacoesDto.Any());
        }
    }
}