using System;
using TestesUnitarios.Avaliacao.Dao;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Tests.Avaliacao.Business
{
    public class GuiaFake
    {
        private readonly IDao<IGuiaProperties> dao;
        private IGuiaProperties guia;

        public GuiaFake(IDao<IGuiaProperties> dao)
        {
            this.dao = dao;
            guia = dao.Create();
        }

        public IGuiaProperties ObterGuiaValida()
        {
            guia.DataAtendimento = DateTime.Now;
            guia.IndicadorDeclaracaoObitoRn = true;
            guia.NumeroDeclaracaoObito = "123";
            return guia;
        }

        public IGuiaProperties ObterGuiaDataAtendimentoInvalida()
        {
            guia.DataAtendimento = DateTime.Now.AddMonths(2);

            return guia;
        }

        public IGuiaProperties ObterGuiaNumeroDeclaracaoObitoInvalido()
        {
            guia.DataAtendimento = DateTime.Now;
            guia.IndicadorDeclaracaoObitoRn = true;
            guia.NumeroDeclaracaoObito = "";

            return guia;
        }
    }
}