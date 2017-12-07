using System.Linq;
using TestesUnitarios.Avaliacao.Dao;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Avaliacao.Validacao
{
    public class ValidacaoDespesaGuia : IValidacao
    {
        private readonly IDespesasGuiaDao despesasGuiaDao;

        public ValidacaoDespesaGuia(IDespesasGuiaDao despesasGuiaDao)
        {
            this.despesasGuiaDao = despesasGuiaDao;
        }

        public string Validar(IGuiaProperties guia)
        {
            var despesasGuia = despesasGuiaDao.ObterDespesasDaGuia(guia.Handle).ToList();
            if (!despesasGuia.Any())
                return null;

            return despesasGuia.Any(despesa => despesa.TipoReducaoAcrescimo.HasValue
                                               && despesa.TipoReducaoAcrescimo !=
                                               TipoReducaoAcrescimo.ItemSemReducaoAcrescimo
                                               && despesa.ValorReducaoAcrescimo.HasValue
                                               && despesa.ValorReducaoAcrescimo > 100) 
                   ? "Tipo redução acréscimo não pode ser maior que 100" 
                   : null;
        }
    }
}
