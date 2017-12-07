using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesUnitarios.Avaliacao.Business;
using TestesUnitarios.Avaliacao.Dao;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Tests.Avaliacao.Business
{
    [TestFixture]
    public class ServioProcessoGuiaTests
    {
        private ServicoProcessoGuia _processarGuia;
        private IServicoEnvioGuias _servicoGuias;
        private IDao<IGuiaProperties> _daoBase;
        private IDao<IDespesasGuiaProperties> _daoBaseDespesas;

        [SetUp]
        public void SetUp()
        {
            _servicoGuias = Substitute.For<IServicoEnvioGuias>();
            _daoBase = Substitute.For<IDao<IGuiaProperties>>();
            _daoBaseDespesas = Substitute.For<IDao<IDespesasGuiaProperties>>();
            _processarGuia = new ServicoProcessoGuia(_servicoGuias, _daoBase, _daoBaseDespesas);
        }

        [Test]
        public void Deve_processar_guia_sem_erros()
        {
            var resposta = new RespostaServicoDto();
            resposta.Sucesso = true;
            _servicoGuias.EnviarGuia(Arg.Any<Guia>()).Returns(resposta);
            //continua no proximo episodio
        }
    }
}
