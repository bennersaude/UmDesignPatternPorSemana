using Benner.Tecnologia.Common;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesUnitarios.Avaliacao.Dao;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Tests.Avaliacao.Dao
{
    [TestFixture]
    public class DespesasGuiaDaoTests
    {
        private IDao<IDespesasGuiaProperties> dao;
        private List<IDespesasGuiaProperties> despesas;

        [SetUp]
        public void Setup()
        {
            dao = Substitute.For<IDao<IDespesasGuiaProperties>>();
            dao.When(d => d.GetMany(Arg.Any<Criteria>())).Do(args => despesas = args.Arg<List<IDespesasGuiaProperties>>());
            //??????
        }
    }
}
