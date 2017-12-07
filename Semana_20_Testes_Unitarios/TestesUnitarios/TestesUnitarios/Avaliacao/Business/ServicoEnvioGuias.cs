using System;
using System.Collections.Generic;
using System.Linq;
using TestesUnitarios.Avaliacao.Dao;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Avaliacao.Business
{
    public class ServicoEnvioGuias
    {
        private IDespesasGuiaDao _despesasGuiaDao;
        private IDao<IGuia> _guiaDao;
        public const string MensagemErro_DataObrigatoria = "A data de atendimento é obrigatória!";
        public const string MensagemErro_DataForaDoPeriodo = "A data de atendimento deve estar entre 01/01/2000 e hoje!";
        public const string MensagemErro_NumeroDeclaracaoObitoNaoInformado = "O número da declaração de óbio não foi informado";
        public const string MensagemErro_DespesaComAcrescimoMaiorQuePermitido = "A guia possui despesas com Valor de Redução de Acrescimo acima de 100";

        public ServicoEnvioGuias(IDespesasGuiaDao despesasGuiaDao, IDao<IGuia> guiaDao)
        {
            _despesasGuiaDao = despesasGuiaDao;
            _guiaDao = guiaDao;
        }

        public RespostaServicoDto EnviarGuia(IGuia guia)
        {
            try
            {
                var erros = ValidarGuia(guia);

                if (erros.Any())
                    return new RespostaServicoDto { Erros = erros };

                _guiaDao.Save<Guia>(guia);

                return new RespostaServicoDto { Sucesso = true, GuiaProcessada = guia };
            }
            catch (Exception ex)
            {
                return new RespostaServicoDto { Erros = new List<string> { ex.Message } };
            }
        }

        public List<string> ValidarGuia(IGuia guia)
        {
            var erros = new List<string>();

            if (!guia.DataAtendimento.HasValue)
                erros.Add(MensagemErro_DataObrigatoria);
            else
            {
                if (guia.DataAtendimento.Value.Date < new DateTime(2000, 1, 1) || guia.DataAtendimento.Value.Date > DateTime.Today)
                    erros.Add(MensagemErro_DataForaDoPeriodo);
            }

            if (guia.IndicadorDeclaracaoObitoRn ?? false && string.IsNullOrEmpty(guia.NumeroDeclaracaoObito))
                erros.Add(MensagemErro_NumeroDeclaracaoObitoNaoInformado);

            if (guia.Handle != null)
            {
                var despesas = _despesasGuiaDao.ObterDespesasDaGuia(guia.Handle);
                if (despesas.Any(d => d.TipoReducaoAcrescimo != TipoReducaoAcrescimo.ItemSemReducaoAcrescimo && d.ValorReducaoAcrescimo > 100))
                    erros.Add(MensagemErro_DespesaComAcrescimoMaiorQuePermitido);
            }

            return erros;
        }
    }
}
