using System.Collections.Generic;
using System.Linq;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Avaliacao.Business.Validacoes
{
    public class ValidacoesGuia : IValidacoesGuia
    {
        private readonly IValidacoesFactory validacoesFactory;

        public ValidacoesGuia(IValidacoesFactory validacoesFactory)
        {
            this.validacoesFactory = validacoesFactory;
        }

        public IList<string> Validar(IGuiaProperties guia)
        {
            var validacoes = validacoesFactory.Obter();

            return validacoes.Select(validacao => validacao.Validar(guia))
                .Where(retorno => retorno != string.Empty).ToList();
        }
    }
}