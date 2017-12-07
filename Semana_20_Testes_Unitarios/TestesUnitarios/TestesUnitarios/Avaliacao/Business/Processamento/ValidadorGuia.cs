using Benner.Tecnologia.Business.Validation;
using Benner.Tecnologia.Common;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using System;
using System.Linq;
using TestesUnitarios.Avaliacao.Dao;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Avaliacao.Business.Processamento
{
    public class ValidadorGuia : IValidadorGuia
    {
        private IGuiaProperties _guia;
        private ValidationResults _validacoes;
        private IDao<IDespesasGuiaProperties> _daoDespesasGuia;

        public ValidadorGuia(IDao<IDespesasGuiaProperties> daoDespesaGuia)
        {
            _validacoes = new ValidationResults();
            _daoDespesasGuia = daoDespesaGuia;
        }

        public RespostaProcessamentoDto Validar(IGuiaProperties guia)
        {
            _guia = guia;

            ValidarData();
            ValidarDeclaracaoObito();
            ValidarReducaoAcrescimo();

            return new RespostaProcessamentoDto()
            {
                Erros = _validacoes.Select(v => v.Message).ToList(),
                Sucesso = _validacoes.IsValid
            };
        }

        private void ValidarData()
        {
            var dataAtendimento = _guia.DataAtendimento.GetValueOrDefault();
            if (dataAtendimento > DateTime.Now)
                _validacoes.AddResult(new EntityValidationResult("Data de atendimento não deve ser superior a data atual."));
            else if (dataAtendimento < new DateTime(2000, 01, 01))
                _validacoes.AddResult(new EntityValidationResult("Data de atendimento não deve ser inferior a 01/01/2000."));
        }

        private void ValidarDeclaracaoObito()
        {
            if (_guia.IndicadorDeclaracaoObitoRn.GetValueOrDefault() && string.IsNullOrWhiteSpace(_guia.NumeroDeclaracaoObito))
                _validacoes.AddResult(new EntityValidationResult("Número da Declaração de Óbito deve ser preenchida."));
        }

        private void ValidarReducaoAcrescimo()
        {
            var criterio = new Criteria("A.GUIA = :HANDLEGUIA AND A.TIPOREDUCAOACRESCIMO <> :TIPOREDUCAOACRESCIMO ");
            criterio.Parameters.Add("HANDLEGUIA", _guia.Handle);
            criterio.Parameters.Add("TIPOREDUCAOACRESCIMO", TipoReducaoAcrescimo.ItemSemReducaoAcrescimo.ToString());
            var listaDespesas = _daoDespesasGuia.GetMany(criterio);
            if (!listaDespesas.Any()) return;
            if (listaDespesas.Where(d => d.ValorReducaoAcrescimo > 100).ToList().Any())
                _validacoes.AddResult(new EntityValidationResult("Não deve existir nenhuma despesa com valor superior a 100."));
        }
    }
}
