using System;
using System.Collections.Generic;
using System.Linq;
using TestesUnitarios.Avaliacao.Dao;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Avaliacao.Business
{
    public class ValidacaoGuia : IValidacaoGuia
    {
        private readonly IDespesasGuiaDao _despesasGuiaDao;

        public ValidacaoGuia(IDespesasGuiaDao despesasGuiaDao)
        {
            _despesasGuiaDao = despesasGuiaDao;
        }

        public RespostaProcessamentoDto Validar(IGuiaProperties guia)
        {
            var respostaProcessamentoDto = new RespostaProcessamentoDto { Erros = new List<string>(), Sucesso = true };
            var erros = new List<string>();
            var dataMinima = new DateTime(2000, 01, 01);

            if (guia.DataAtendimento.HasValue && (guia.DataAtendimento.Value > DateTime.Now || guia.DataAtendimento.Value < dataMinima))
                erros.Add("Data de atendimento inválida");

            if (guia.IndicadorDeclaracaoObitoRn.HasValue && guia.IndicadorDeclaracaoObitoRn.Value && string.IsNullOrEmpty(guia.NumeroDeclaracaoObito))
                erros.Add("Número da declaração de óbito deve ser preenchido");

            if(!ValidarDespesas(guia.Handle))
                erros.Add("Valor da redução de acréscimo não pode ser maior que 100");

            if (erros.Any())
            {
                respostaProcessamentoDto.Erros = erros;
                respostaProcessamentoDto.Sucesso = false;
            }

            return respostaProcessamentoDto;
        }

        private bool ValidarDespesas(long handleGuia)
        {
            var despesasGuia = _despesasGuiaDao.ObterDespesasDaGuia(handleGuia);

            if (despesasGuia != null && despesasGuia.Any(d => d.TipoReducaoAcrescimo != null))
            {
                if (despesasGuia.Any(d => d.TipoReducaoAcrescimo != TipoReducaoAcrescimo.ItemSemReducaoAcrescimo && d.ValorReducaoAcrescimo.HasValue && d.ValorReducaoAcrescimo.Value > 100))
                    return false;
            }

            return true;
        }
    }
}