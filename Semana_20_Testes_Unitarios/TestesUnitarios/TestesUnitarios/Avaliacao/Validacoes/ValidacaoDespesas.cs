using System.Linq;
using TestesUnitarios.Avaliacao.Dao;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Avaliacao.Validacoes
{
    public class ValidacaoDespesas : IValidacaoGuia
    {
        private readonly IDespesasGuiaDao despesasGuiaDao;

        public ValidacaoDespesas(IDespesasGuiaDao despesasGuiaDao)
        {
            this.despesasGuiaDao = despesasGuiaDao;
        }

        public bool Validar(IGuia guia)
        {
            var despesasDaGuia = despesasGuiaDao.ObterDespesasDaGuia(guia.HandleLong);

            return !despesasDaGuia.Any(despesa =>
                    despesa.TipoReducaoAcrescimo != TipoReducaoAcrescimo.ItemSemReducaoAcrescimo &&
                    despesa.ValorReducaoAcrescimo > 100);
        }

        public string ObterMensagemErro()
        {
            return "Valor redução acréscimo não pode ser maior que 100";
        }
    }
}
