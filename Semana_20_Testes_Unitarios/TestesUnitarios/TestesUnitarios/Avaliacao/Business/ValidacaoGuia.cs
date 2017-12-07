using System;
using System.Collections.Generic;
using System.Linq;
using TestesUnitarios.Avaliacao.Dao;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Avaliacao.Business
{
    public class ValidacaoGuia : IValidacaoGuia
    {
        private readonly IDespesasGuiaDao despesasGuiasDAO;

        public ValidacaoGuia(IDespesasGuiaDao despesasGuiasDAO)
        {
            this.despesasGuiasDAO = despesasGuiasDAO;
        }

        public List<string> ValidarGuia(IGuiaProperties guia)
        {
            var listaErros = new List<string>();

            if (guia.DataAtendimento >= DateTime.Now || guia.DataAtendimento <= new DateTime(2000, 1, 1))
                listaErros.Add("Data de atendimento inválida");

            if (guia.IndicadorDeclaracaoObitoRn == true && string.IsNullOrEmpty(guia.NumeroDeclaracaoObito))
                listaErros.Add("Campo numero declaracao obito deve ser preenchido");

            if (despesasGuiasDAO.ObterDespesasDaGuia(guia.Handle).Any())
            {
                listaErros.Add("Guia inválida");
            }

            return listaErros;
        }
    }
}