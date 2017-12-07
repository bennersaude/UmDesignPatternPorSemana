using System;
using System.Collections.Generic;
using TestesUnitarios.Avaliacao.Dao;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Avaliacao.Business
{
    public class ValidadorDeGuias
    {
        private const string DATAMINIMAEMISSAOGUIA = "01/01/2000";
        private readonly DespesasGuiaDao _despesasGuiaDao;

        public List<String> Validar(IGuiaProperties guia)
        {
            var errosValidacao = new List<string>();

            if (guia.DataAtendimento > DateTime.Now || guia.DataAtendimento < Convert.ToDateTime(DATAMINIMAEMISSAOGUIA))
                errosValidacao.Add("A data de atendimento da guia deve estar entre " + DATAMINIMAEMISSAOGUIA + " e " + DateTime.Today.ToString());

            if (guia.IndicadorDeclaracaoObitoRn.Equals(null))
                errosValidacao.Add("O campo IndicadorDeclaracaoObitoRn deve ser preenchido");
            else
            {
                if (guia.IndicadorDeclaracaoObitoRn.Equals(true) && string.IsNullOrEmpty(guia.NumeroDeclaracaoObito))
                    errosValidacao.Add("O campo NumeroDeclaracaoObito deve ser preenchido");
            }

            _despesasGuiaDao.ObterDespesasDaGuia(1);




            return errosValidacao;

        }
    }
}
