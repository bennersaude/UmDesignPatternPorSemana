using Benner.Tecnologia.Common;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using TestesUnitarios.Avaliacao.Business;
using TestesUnitarios.Avaliacao.Business.Processamento;
using TestesUnitarios.Avaliacao.Dao;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Tests.Avaliacao.Business.Processamento
{
    [TestFixture]
    public class ValidadorGuiaTests
    {
        private IGuiaProperties _guia;
        private IDao<IDespesasGuiaProperties> _daoDespesa;

        [SetUp]
        public void SetUp()
        {
            _guia = Substitute.For<IGuiaProperties>();
            _guia.DataAtendimento = DateTime.Now.AddDays(-1);
            _guia.IndicadorDeclaracaoObitoRn.Returns(false);
            _guia.NumeroDeclaracaoObito = string.Empty;
            _guia.Handle.Returns(new Handle(1));
            _daoDespesa = Substitute.For<IDao<IDespesasGuiaProperties>>();
        }

        [TestCase(true, "Data de atendimento não deve ser superior a data atual.", TestName = "Deve criticar data atendimento superior a atual.")]
        [TestCase(false, "Data de atendimento não deve ser inferior a 01/01/2000.", TestName = "Deve criticar data atendimento inferior a 01/01/2000.")]
        public void Deve_criticar_data_atendimento(bool definirDataSuperior, string mensagemEsperada)
        {
            _guia.DataAtendimento = definirDataSuperior ? DateTime.MaxValue : DateTime.MinValue;

            var validadorGuia = new ValidadorGuia(_daoDespesa);
            var respostaDTO = validadorGuia.Executar(_guia);

            var respostaEsperadaDTO = new RespostaProcessamentoDto()
            {
                Erros = new List<string>() { mensagemEsperada },
                Sucesso = false
            };

            respostaDTO.ShouldBeEquivalentTo(respostaEsperadaDTO);
        }

        [Test]
        public void Deve_criticar_declaracao_obito_invalida()
        {
            _guia.IndicadorDeclaracaoObitoRn.Returns(true);
            var validadorGuia = new ValidadorGuia(_daoDespesa);
            var respostaDTO = validadorGuia.Executar(_guia);

            var respostaEsperadaDTO = new RespostaProcessamentoDto()
            {
                Erros = new List<string>() { "Número da Declaração de Óbito deve ser preenchida." },
                Sucesso = false
            };

            respostaDTO.ShouldBeEquivalentTo(respostaEsperadaDTO);
        }

        [Test]
        public void Deve_criticar_reducao_acrescimo()
        {
            var despesaGuia = Substitute.For<IDespesasGuiaProperties>();
            despesaGuia.ValorReducaoAcrescimo = 101;
            _daoDespesa.GetMany(Arg.Any<Criteria>()).Returns(new List<IDespesasGuiaProperties>() { despesaGuia });
            var validadorGuia = new ValidadorGuia(_daoDespesa);
            var respostaDTO = validadorGuia.Executar(_guia);

            var respostaEsperadaDTO = new RespostaProcessamentoDto()
            {
                Erros = new List<string>() { "Não deve existir nenhuma despesa com valor superior a 100." },
                Sucesso = false
            };

            respostaDTO.ShouldBeEquivalentTo(respostaEsperadaDTO);
        }

        [Test]
        public void Deve_validar_sem_criticas()
        {
            var despesaGuia = Substitute.For<IDespesasGuiaProperties>();
            despesaGuia.ValorReducaoAcrescimo = 0;
            _daoDespesa.GetMany(Arg.Any<Criteria>()).Returns(new List<IDespesasGuiaProperties>());
            var validadorGuia = new ValidadorGuia(_daoDespesa);
            var respostaDTO = validadorGuia.Executar(_guia);

            var respostaEsperadaDTO = new RespostaProcessamentoDto()
            {
                Erros = new List<string>(),
                Sucesso = true
            };

            respostaDTO.ShouldBeEquivalentTo(respostaEsperadaDTO);
        }
    }
}
