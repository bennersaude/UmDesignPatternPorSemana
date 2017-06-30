using System.Collections.Generic;
using UmDesignPatternPorSemana.Proxy.ProtectionProxy.Stubs;

namespace UmDesignPatternPorSemana.Proxy.ProtectionProxy
{
    public class FactoryCancelamentoGuia
    {
        public ICancelamentoGuia ObterCancelamento()
        {
            return new CancelamentoGuiaProxy(new CancelamentoGuia(new Dao<Guia>()), ObterValidacoes());
        }

        private static IEnumerable<IValidacaoCancelamentoGuia> ObterValidacoes()
        {
            return new List<IValidacaoCancelamentoGuia> {new VerificacaoPermissoesUsuario(), new VerificacaoStatus()};
        }
    }
}