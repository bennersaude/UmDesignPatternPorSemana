using FluentAssertions;
using NUnit.Framework;
using System;
using TestesUnitarios.Avaliacao.Business;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Tests.Avaliacao.Business
{
    [TestFixture]
    public class ProcessamentoGuiasTests
    {
        [Test]
        public void DeveProcessarGuiaCorretamente()
        {
            var processamentoGuia = new ProcessamentoGuias();

            var guia = ObterGuiaFake();

            var resultado = processamentoGuia.Processar(guia);

            resultado.ShouldBeEquivalentTo(new RespostaProcessamentoDtoFake().ObterRespostaComSucesso());

        }

        private Guia ObterGuiaFake()
        {
            return new Guia()
            {
                DataAtendimento = DateTime.Now,
                IndicadorDeclaracaoObitoRn = false,
                NumeroDeclaracaoObito = "123"
            };
        }
    }
}
