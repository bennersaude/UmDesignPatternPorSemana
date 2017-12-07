using Benner.Tecnologia.Common;
using NSubstitute;
using NUnit.Framework;
using System;
using TestesUnitarios.Avaliacao.Business;
using TestesUnitarios.Avaliacao.Dao;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Tests.Avaliacao.Business
{
    [TestFixture]
    public class ValidadorDeGuiasTests
    {
        private ValidadorDeGuias _validadorDeGuias;
        private IGuiaProperties _guia;
        private IDespesasGuiaDao _despesasGuiaDao;
        private IDao<IDespesasGuiaDao> _daoBase;
        private IDespesasGuiaProperties _guiaDespesas;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            _validadorDeGuias = new ValidadorDeGuias();

            _despesasGuiaDao = Substitute.For<IDespesasGuiaDao>();
            _daoBase = Substitute.For<IDao<IDespesasGuiaDao>>();
            _guiaDespesas = Substitute.For<IDespesasGuiaProperties>();

        }

        [Test]
        public void Deve_retornar_erro_guia_data_invalida()
        {
            var expected = "A data de atendimento da guia deve estar entre " + "01/01/2000" + " e " + DateTime.Today.ToString();
            
            _guia = ObterGuia(DateTime.Now.AddDays(1), true, "123");

            var actual = _validadorDeGuias.Validar(_guia);

            Assert.True(actual.Contains(expected));
        }

        [Test]
        public void Deve_retornar_quando_despesa_invalida()
        {
            _guiaDespesas = ObterDespesas(1, 101, TipoReducaoAcrescimo.ItemReducao);
            _daoBase.When(d => d.GetFirstOrDefault(Arg.Any<Handle>())).Do(args => _guiaDespesas = args.Arg<IDespesasGuiaProperties>());
            _despesasGuiaDao.ObterDespesasDaGuia(Arg.Any<long>()).Returns(_guiaDespesas);


            _guia = ObterGuia(DateTime.Now.AddDays(1), true, "123");

            var listaErros = _validadorDeGuias.Validar(_guia);

        }


        private IGuiaProperties ObterGuia(DateTime dataAtendimento, bool indicadorDeclaracaoObito, string numeroDeclaracaoObito)
        {
            var guiaProperties = Substitute.For<IGuiaProperties>();

            guiaProperties.DataAtendimento = dataAtendimento;
            guiaProperties.IndicadorDeclaracaoObitoRn = indicadorDeclaracaoObito;
            guiaProperties.NumeroDeclaracaoObito = numeroDeclaracaoObito;

            return guiaProperties;
        }

        private IDespesasGuiaProperties ObterDespesas(Handle handleGuia, decimal? valorReducaoAcrescimo, TipoReducaoAcrescimo? tipoReducaoAcrescimo)
        {
            var guiaDespesas = Substitute.For<IDespesasGuiaProperties>();

            guiaDespesas.Guia.Handle = handleGuia;
            guiaDespesas.ValorReducaoAcrescimo = valorReducaoAcrescimo;
            guiaDespesas.TipoReducaoAcrescimo = tipoReducaoAcrescimo;

            return guiaDespesas;
        }



    }
}
