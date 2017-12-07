using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using TestesUnitarios.Avaliacao.Business;
using TestesUnitarios.Avaliacao.Dao;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Tests.Avaliacao.Business
{
    [TestFixture]
    public class ProcessamentoGuiaTests
    {
        private IValidacaoGuia validacaoGuia;
        private IServicoEnvioGuias servicoEnvioGuias;
        private IGuiaDAO guiaDAO;
        private IGuiaProperties guia;
        private ProcessamentoGuia processamentoGuia;

        [SetUp]
        public void SetUp()
        {
            guia = Substitute.For<IGuiaProperties>();
            guia.Handle = 1;

            guiaDAO = Substitute.For<IGuiaDAO>();
            guiaDAO.GravarGuia(Arg.Any<IGuiaProperties>()).Returns(guia);

            validacaoGuia = Substitute.For<IValidacaoGuia>();
            validacaoGuia.ValidarGuia(Arg.Any<IGuiaProperties>()).Returns(new List<string>());

            servicoEnvioGuias = Substitute.For<IServicoEnvioGuias>();
            servicoEnvioGuias.EnviarGuia(Arg.Any<IGuiaProperties>()).Returns(new RespostaServicoDto() { Sucesso = true });

            processamentoGuia = new ProcessamentoGuia(guiaDAO, servicoEnvioGuias);
        }

        [Test]
        public void Deve_retornar_processamento_com_sucesso()
        {
            var expected = new RespostaProcessamentoDto()
            {
                Sucesso = true,
                Handle = 1
            };
        }

        [Test]
        public void Deve_retornar_processamento_com_erro()
        {
        }
    }
}