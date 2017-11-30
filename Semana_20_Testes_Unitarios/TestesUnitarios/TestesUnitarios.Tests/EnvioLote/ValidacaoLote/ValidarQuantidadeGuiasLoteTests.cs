using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TestesUnitarios.EnvioLote;
using TestesUnitarios.EnvioLote.ValidacaoLote;

namespace TestesUnitarios.Tests.EnvioLote.ValidacaoLote
{
    [TestFixture]
    public class ValidarQuantidadeGuiasLoteTests
    {
        private IValidacaoLote validacaoLote;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            validacaoLote = new ValidarQuantidadeGuiasLote();
        }

        [TestCase(100, false)]
        [TestCase(101, true)]
        public void Deve_validar_se_lote_possui_quantidade_certa_de_guias(long quantidade, bool result)
        {
            var lote = new Lote
            {
                Guias = new List<Guia>()
            };

            for (var i = 0; i < quantidade; i++)
            {
                lote.Guias.Add(new Guia());
            }

            var validacoesDto = new List<ValidacaoDto>();

            validacaoLote.Validar(lote, validacoesDto);

            Assert.AreEqual(result, validacoesDto.Any());
        }
    }
}