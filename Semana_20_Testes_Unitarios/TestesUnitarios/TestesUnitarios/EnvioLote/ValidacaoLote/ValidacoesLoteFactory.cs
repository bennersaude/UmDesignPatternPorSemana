using System.Collections.Generic;

namespace TestesUnitarios.EnvioLote.ValidacaoLote
{
    public static class ValidacoesLoteFactory
    {
        public static IList<IValidacaoLote> ObterValidacoes()
        {
            return new List<IValidacaoLote>
            {
                new ValidarQuantidadeGuiasLote(),
                new ValidarGuiasSemEvento(),
                new ValidarQuantidadeEventoZerada()
            };
        }
    }
}