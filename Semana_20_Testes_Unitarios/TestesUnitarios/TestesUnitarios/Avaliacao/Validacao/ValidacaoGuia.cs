using System.Collections.Generic;
using System.Linq;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Avaliacao.Validacao
{
    public class ValidacaoGuia : IValidacaoGuia
    {
        private readonly IFactoryValidacoes factoryValidacoes;

        public ValidacaoGuia(IFactoryValidacoes factoryValidacoes)
        {
            this.factoryValidacoes = factoryValidacoes;
        }

        public IList<string> ObterValidacoes(IGuiaProperties guia)
        {
            var validacoes = factoryValidacoes.ObterValidacoes();
            return validacoes
                .Select(validacao => validacao.Validar(guia))
                .Where(mensagem => !string.IsNullOrEmpty(mensagem)).ToList();
        }
    }
}
