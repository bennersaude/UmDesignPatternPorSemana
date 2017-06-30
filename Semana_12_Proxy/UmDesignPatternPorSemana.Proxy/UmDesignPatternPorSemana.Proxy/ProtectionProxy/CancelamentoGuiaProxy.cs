using System;
using System.Collections.Generic;
using System.Linq;
using UmDesignPatternPorSemana.Proxy.ProtectionProxy.Stubs;

namespace UmDesignPatternPorSemana.Proxy.ProtectionProxy
{
    public class CancelamentoGuiaProxy : ICancelamentoGuia
    {
        private readonly ICancelamentoGuia cancelamentoGuia;
        private readonly IEnumerable<IValidacaoCancelamentoGuia> validacoes;

        public CancelamentoGuiaProxy(ICancelamentoGuia cancelamentoGuia, IEnumerable<IValidacaoCancelamentoGuia> validacoes)
        {
            this.cancelamentoGuia = cancelamentoGuia;
            this.validacoes = validacoes;
        }

        public void CancelarGuia(Guia guia)
        {
            if (validacoes.Any(v => !v.PodeCancelar(guia))) throw new Exception("Não foi possivel cancelar a guia!");

            cancelamentoGuia.CancelarGuia(guia);
        }
    }
}