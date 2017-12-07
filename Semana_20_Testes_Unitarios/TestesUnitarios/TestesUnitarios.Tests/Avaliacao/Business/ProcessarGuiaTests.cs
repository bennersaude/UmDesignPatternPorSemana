using System;
using System.Collections.Generic;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using TestesUnitarios.Avaliacao.Business;
using TestesUnitarios.Avaliacao.Business.Validacoes;
using TestesUnitarios.Avaliacao.Dao;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Tests.Avaliacao.Business
{
    [TestFixture]
    public class ProcessarGuiaTests
    {
        public IProcessarGuia ProcessarGuia;
        private IValidacoesGuia validacoesGuia;
        private IServicoEnvioGuias servicoEnvioGuias;
        private IDao<IGuiaProperties> guiaDao;
        private IGuiaProperties guiaPropertiesFalhaValidacao;
        private IGuiaProperties guiaPropertiesFalhaServico;
        private IGuiaProperties guiaPropertiesCorreta;
        private IGuiaProperties guiaRetornoSave;
        private IList<string> erros;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            validacoesGuia = Substitute.For<IValidacoesGuia>();

            guiaPropertiesCorreta = Substitute.For<IGuiaProperties>();
            guiaPropertiesCorreta.Handle = 1;
            guiaPropertiesCorreta.DataAtendimento = DateTime.Today.AddDays(1);

            guiaPropertiesFalhaValidacao = Substitute.For<IGuiaProperties>();
            guiaPropertiesFalhaValidacao.Handle = 2;

            guiaPropertiesFalhaServico = Substitute.For<IGuiaProperties>();
            guiaPropertiesFalhaValidacao.Handle = 3;

            guiaRetornoSave = Substitute.For<IGuiaProperties>();

            erros = new List<string>()
            {
                "Erro"
            };

            validacoesGuia.Validar(guiaPropertiesFalhaValidacao).Returns(erros);

            servicoEnvioGuias = Substitute.For<IServicoEnvioGuias>();
            
            var respostaDto = new RespostaServicoDto
            {
                Sucesso = false,
                Erros = erros
            };

            servicoEnvioGuias.EnviarGuia(guiaPropertiesFalhaServico).Returns(respostaDto);

            guiaDao = Substitute.For<IDao<IGuiaProperties>>();

            guiaDao.When(x => x.Save<Guia>(Arg.Any<IGuiaProperties>())).Do(args => guiaRetornoSave = args.Arg<IGuiaProperties>());

            var respostaServico = new RespostaServicoDto
            {
                Sucesso = true
            };

            servicoEnvioGuias.EnviarGuia(guiaPropertiesCorreta).Returns(respostaServico);

            ProcessarGuia = new ProcessarGuia(validacoesGuia, servicoEnvioGuias, guiaDao);
        }

        [TearDown]
        public void TearDown()
        {
            validacoesGuia.ClearReceivedCalls();
            servicoEnvioGuias.ClearReceivedCalls();
            guiaDao.ClearReceivedCalls();
        }

        [Test]
        public void Deve_processar_guia_corretamente()
        {
            var expected = new RespostaProcessamentoDto
            {
                Sucesso = true,
                Handle = 1
            };

            var resposta = ProcessarGuia.Processar(guiaPropertiesCorreta);

            resposta.ShouldBeEquivalentTo(expected);

            guiaRetornoSave.ShouldBeEquivalentTo(guiaPropertiesCorreta);
        }

        [Test]
        public void Deve_retornar_caso_validacao_retorno_erro()
        {
            var expected = new RespostaProcessamentoDto
            {
                Sucesso = false,
                Erros = erros
            };

            var resposta = ProcessarGuia.Processar(guiaPropertiesFalhaValidacao);

            resposta.ShouldBeEquivalentTo(expected);
        }

        [Test]
        public void Deve_retornar_caso_servico_retorne_erro()
        {
            var expected = new RespostaProcessamentoDto
            {
                Sucesso = false,
                Erros = erros
            };

            var resposta = ProcessarGuia.Processar(guiaPropertiesFalhaServico);

            resposta.ShouldBeEquivalentTo(expected);
        }
    }
}