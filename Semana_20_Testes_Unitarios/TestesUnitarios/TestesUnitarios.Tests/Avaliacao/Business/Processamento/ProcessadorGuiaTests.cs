using Benner.Tecnologia.Common;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesUnitarios.Avaliacao.Business;
using TestesUnitarios.Avaliacao.Business.Processamento;
using TestesUnitarios.Avaliacao.Dao;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Tests.Avaliacao.Business.Processamento
{
    [TestFixture]
    public class ProcessadorGuiaTests
    {
        private ProcessadorGuia _processadorGuia;
        private IValidadorGuia _validadorGuia;
        private IDao<IGuiaProperties> _daoGuia;
        private IServicoEnvioGuias _servicoEnvioGuia;
        private IGuiaProperties _guia;
        private IGuiaProperties _guiaSalva;
        private Handle _handleValido = new Handle(1);

        [SetUp]
        public void SetUp()
        {
            _validadorGuia = Substitute.For<IValidadorGuia>();
            _validadorGuia.Validar(Arg.Any<IGuiaProperties>()).Returns(new RespostaProcessamentoDto() { Sucesso = true });

            _guia = Substitute.For<IGuiaProperties>();
            _guia.Handle.Returns(_handleValido);

            _daoGuia = Substitute.For<IDao<IGuiaProperties>>();
            _daoGuia.Save<Guia>(Arg.Do<IGuiaProperties>(x => _guiaSalva = x));
            _servicoEnvioGuia = Substitute.For<IServicoEnvioGuias>();
            _servicoEnvioGuia.EnviarGuia(Arg.Any<IGuiaProperties>()).Returns(new RespostaServicoDto() { Sucesso = true });
        }

        private void InstaciarProcessador()
        {
            _processadorGuia = new ProcessadorGuia(_validadorGuia, _daoGuia, _servicoEnvioGuia);
        }

        [Test]
        public void Deve_processar_corretamente()
        {
            InstaciarProcessador();
            var respostaDTO = _processadorGuia.Processar(_guia);
            var respostaEsperadaDTO = new RespostaProcessamentoDto() { Sucesso = true, Handle = _handleValido };
            respostaDTO.ShouldBeEquivalentTo(respostaEsperadaDTO);
            _guiaSalva.ShouldBeEquivalentTo(_guia);
        }

        [Test]
        public void Deve_falahar_ao_enviar()
        {
            var respostaEsperadaDTO = new RespostaProcessamentoDto() { Sucesso = false, Erros = new List<string>() { "InternalServerError" } };

            _servicoEnvioGuia.EnviarGuia(Arg.Any<IGuiaProperties>()).Returns(new RespostaServicoDto()
                {
                    Sucesso = respostaEsperadaDTO.Sucesso,
                    Erros = respostaEsperadaDTO.Erros
            });

            InstaciarProcessador();
            var respostaDTO = _processadorGuia.Processar(_guia);
            respostaDTO.ShouldBeEquivalentTo(respostaEsperadaDTO);
        }

        [Test]
        public void Deve_falahar_ao_validar()
        {
            var respostaEsperadaDTO = new RespostaProcessamentoDto() { Sucesso = false, Erros = new List<string>() { "Número da Declaração de Óbito deve ser preenchida." } };

            _validadorGuia.Validar(Arg.Any<IGuiaProperties>()).Returns(respostaEsperadaDTO);

            InstaciarProcessador();
            var respostaDTO = _processadorGuia.Processar(_guia);
            respostaDTO.ShouldBeEquivalentTo(respostaEsperadaDTO);
        }
    }
}
