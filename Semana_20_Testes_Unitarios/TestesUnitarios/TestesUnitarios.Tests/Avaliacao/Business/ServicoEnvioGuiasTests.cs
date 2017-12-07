using NUnit.Framework;
using FluentAssertions;
using TestesUnitarios.Avaliacao.Business;
using TestesUnitarios.Avaliacao.Entidades;
using TestesUnitarios.Avaliacao.Dao;
using NSubstitute;
using System.Collections.Generic;
using Benner.Tecnologia.Common;
using System;
using System.Linq;

namespace TestesUnitarios.Tests.Avaliacao.Business
{
    [TestFixture]
    public class ServicoEnvioGuiasTests
    {
        private ServicoEnvioGuias _envioGuia;
        private IDespesasGuiaDao _despesasGuiaDao;
        private IDao<IGuia> _guiaDao;
        private IGuia _guiaSalva;

        [SetUp]
        public void SetUp()
        {
            _guiaDao = Substitute.For<IDao<IGuia>>();
            _despesasGuiaDao = Substitute.For<IDespesasGuiaDao>();
            _despesasGuiaDao.ObterDespesasDaGuia(Arg.Any<long>()).Returns(new List<IDespesasGuia>());

            _guiaDao.When(g => g.Save<Guia>(Arg.Any<IGuia>())).Do(args =>
            {
                _guiaSalva = args.Arg<IGuia>();
                if (_guiaSalva != null && _guiaSalva.Handle == null)
                    _guiaSalva.Handle = new Handle(15);
            });


            _envioGuia = new ServicoEnvioGuias(_despesasGuiaDao, _guiaDao);
        }

        #region Validações
        [Test]
        public void deve_validar_despesa_invalida()
        {
            var despesas = ObterDespesas_ItemReducaoAcrescimoValorMaiorQuePermitido();
            _despesasGuiaDao.ObterDespesasDaGuia(Arg.Any<long>()).Returns(despesas);

            var guia = ObterGuia();

            var erros = _envioGuia.ValidarGuia(guia);

            erros.Should().HaveCount(1);
            erros.First().ShouldBeEquivalentTo(ServicoEnvioGuias.MensagemErro_DespesaComAcrescimoMaiorQuePermitido);
        }

        [Test]
        public void nao_deve_validar_despesa_invalida()
        {
            var despesas = ObterDespesas_ItemReducaoAcrescimoValorMaiorQuePermitido();
            _despesasGuiaDao.ObterDespesasDaGuia(Arg.Any<long>()).Returns(despesas);

            var guia = ObterGuia();
            guia.Handle = null;

            var erros = _envioGuia.ValidarGuia(guia);

            erros.Should().HaveCount(0);
        }

        [Test]
        public void deve_validar_data_nao_informada()
        {
            var guia = ObterGuia();
            guia.DataAtendimento = null;

            var erros = _envioGuia.ValidarGuia(guia);

            erros.Should().HaveCount(1);
            erros.First().ShouldBeEquivalentTo(ServicoEnvioGuias.MensagemErro_DataObrigatoria);
        }

        [Test]
        public void deve_validar_data_muito_antiga()
        {
            var guia = ObterGuia();
            guia.DataAtendimento = new DateTime(1995, 12, 19);

            var erros = _envioGuia.ValidarGuia(guia);
            erros.Should().HaveCount(1);
            erros.First().ShouldAllBeEquivalentTo(ServicoEnvioGuias.MensagemErro_DataForaDoPeriodo);
        }

        [Test]
        public void deve_validar_data_futura()
        {
            var guia = ObterGuia();
            guia.DataAtendimento = guia.DataAtendimento.Value.AddDays(1);

            var erros = _envioGuia.ValidarGuia(guia);
            erros.Should().HaveCount(1);
            erros.First().ShouldAllBeEquivalentTo(ServicoEnvioGuias.MensagemErro_DataForaDoPeriodo);
        }

        [Test]
        public void deve_validar_numero_declaracao_obito()
        {
            var guia = ObterGuia();
            guia.IndicadorDeclaracaoObitoRn = true;

            var erros = _envioGuia.ValidarGuia(guia);
            erros.Should().HaveCount(1);
            erros.First().ShouldAllBeEquivalentTo(ServicoEnvioGuias.MensagemErro_NumeroDeclaracaoObitoNaoInformado);
        }
        #endregion

        #region Consumo Envio Guia
        [Test]
        public void deve_consumir_servico_e_salvar_guia()
        {
            var guia = ObterGuia();
            guia.Handle = null;

            var retorno = _envioGuia.EnviarGuia(guia);

            retorno.Sucesso.Should().Be(true);
            retorno.GuiaProcessada.Handle.Value.Should().Be(15);
        }

        [Test]
        public void deve_consumir_servico_e_salvar_guia_com_handle_ja_preenchido()
        {
            var guia = ObterGuia();

            var retorno = _envioGuia.EnviarGuia(guia);

            retorno.Sucesso.Should().Be(true);
            retorno.GuiaProcessada.Handle.Value.Should().Be(1);
        }

        [Test]
        public void deve_consumir_servico_e_retornar_erro()
        {
            var guia = ObterGuia();
            guia.Handle = null;
            guia.DataAtendimento = guia.DataAtendimento.Value.AddDays(1);

            var retorno = _envioGuia.EnviarGuia(guia);

            retorno.Sucesso.Should().Be(false);
            retorno.Erros.First().ShouldAllBeEquivalentTo(ServicoEnvioGuias.MensagemErro_DataForaDoPeriodo);
        }

        [Test]
        public void deve_consumir_servico_e_retornar_mais_de_um_erro()
        {
            var guia = ObterGuia();
            guia.Handle = null;
            guia.DataAtendimento = guia.DataAtendimento.Value.AddDays(1);
            guia.IndicadorDeclaracaoObitoRn = true;

            var retorno = _envioGuia.EnviarGuia(guia);

            retorno.Sucesso.Should().Be(false);
            retorno.Erros.ShouldAllBeEquivalentTo(new List<string>
            {
                ServicoEnvioGuias.MensagemErro_DataForaDoPeriodo,
                ServicoEnvioGuias.MensagemErro_NumeroDeclaracaoObitoNaoInformado
            });
        }

        [Test]
        public void deve_consumir_servico_e_retornar_erros_validacao()
        {
            var despesas = ObterDespesas_ItemReducaoAcrescimoValorMaiorQuePermitido();
            _despesasGuiaDao.ObterDespesasDaGuia(Arg.Any<long>()).Returns(despesas);

            var guia = ObterGuia();
            guia.DataAtendimento = guia.DataAtendimento.Value.AddDays(1);
            guia.IndicadorDeclaracaoObitoRn = true;

            var retorno = _envioGuia.EnviarGuia(guia);

            retorno.Sucesso.Should().Be(false);
            retorno.Erros.ShouldAllBeEquivalentTo(new List<string>
            {
                ServicoEnvioGuias.MensagemErro_DataForaDoPeriodo,
                ServicoEnvioGuias.MensagemErro_NumeroDeclaracaoObitoNaoInformado,
                ServicoEnvioGuias.MensagemErro_DespesaComAcrescimoMaiorQuePermitido
            });
        }

        #endregion

        #region Mock
        private IGuia ObterGuia()
        {
            var guia = Substitute.For<IGuia>();
            guia.Handle = new Handle(1);
            guia.DataAtendimento = DateTime.Today;
            return guia;
        }

        private List<IDespesasGuia> ObterDespesas_ItemReducaoAcrescimoValorMaiorQuePermitido()
        {
            var despesa = Substitute.For<IDespesasGuia>();
            despesa.TipoReducaoAcrescimo = TipoReducaoAcrescimo.ItemReducao;
            despesa.ValorReducaoAcrescimo = 101;

            return new List<IDespesasGuia> { despesa };
        }
        #endregion
    }
}
