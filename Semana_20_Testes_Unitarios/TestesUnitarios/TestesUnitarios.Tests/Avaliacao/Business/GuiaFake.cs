using System;
using TestesUnitarios.Avaliacao.Dao;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Tests.Avaliacao.Business
{
    public class GuiaFake
    {
        private readonly IDao<IGuiaProperties> dao;

        public GuiaFake(IDao<IGuiaProperties> dao)
        {
            this.dao = dao;
        }

        public IGuiaProperties ObterGuiaValida()
        {
            var guia = dao.Create();
            guia.DataAtendimento = DateTime.Now;
            guia.IndicadorDeclaracaoObitoRn = true;
            guia.NumeroDeclaracaoObito = "123";
            return guia;
        }
    }
}