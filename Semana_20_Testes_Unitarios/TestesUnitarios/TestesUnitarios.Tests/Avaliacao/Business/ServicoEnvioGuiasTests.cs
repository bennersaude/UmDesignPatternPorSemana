

using System;
using NSubstitute;
using NUnit.Framework;
using TestesUnitarios.Avaliacao.Business;
using TestesUnitarios.Avaliacao.Dao;
using TestesUnitarios.Avaliacao.Entidades;
using TestesUnitarios.Avaliacao.Validacoes;

namespace TestesUnitarios.Tests.Avaliacao.Business
{
    [TestFixture]
    public class ServicoEnvioGuiasTests
    {
        private IFactoryValidacoes factoryValidacoes;
        private IDespesasGuiaDao despesasGuiaDao;
        private ServicoEnvioGuias servicoEnvioGuias;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            despesasGuiaDao = Substitute.For<IDespesasGuiaDao>();
            factoryValidacoes = new FactoryValidacoes(despesasGuiaDao);
            servicoEnvioGuias = new ServicoEnvioGuias(factoryValidacoes);
        }
    }
}