using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System;
using TestesUnitarios.Avaliacao.Dao;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Tests.Avaliacao.Dao
{
    [TestFixture]
    public class GuiaDAOTests
    {
        private IDao<IGuiaProperties> dao;
        private IGuiaDAO guiaDAO;
        private IGuiaProperties guiaSalva;
        private IGuiaProperties expected;

        [SetUp]
        public void SetUp()
        {
            dao = Substitute.For<IDao<IGuiaProperties>>();
            dao.When(d => d.Save<Guia>(Arg.Any<IGuiaProperties>())).Do(args => guiaSalva = args.Arg<IGuiaProperties>());
            guiaDAO = new GuiaDAO(dao);
        }
                
        [Test]
        public void Deve_gravar_entidade_corretamente()
        {
            expected = Substitute.For<IGuiaProperties>();
            expected.DataAtendimento = new DateTime(2017,1,1);
            expected.IndicadorDeclaracaoObitoRn = true;
            expected.NumeroDeclaracaoObito = "6546";

            var actual = guiaDAO.GravarGuia(this.expected);
            actual.ShouldBeEquivalentTo(actual);
        }
    }
}