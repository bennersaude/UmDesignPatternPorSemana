using Semana05.Facade.CancelamentoGuias;
using Semana05.Facade.CancelamentoGuiasSaudavel.Regras;
using System.Collections.Generic;
using System.Linq;

namespace Semana05.Facade.CancelamentoGuiasSaudavel
{
    public class CancelamentoGuias : ICancelamentoGuias
    {
        private readonly IEnumerable<IRegraCancelamentoGuia> regras;
        private readonly IAtualizacaoGuiaCancelada atualizacaoGuiaCancelada;

        public CancelamentoGuias(
            IEnumerable<IRegraCancelamentoGuia> regras, 
            IAtualizacaoGuiaCancelada atualizacaoGuiaCancelada)
        {
            this.regras = regras;
            this.atualizacaoGuiaCancelada = atualizacaoGuiaCancelada;
        }

        public void CancelarGuia(long handleGuia)
        {
            if (!regras.All(r => r.PodeCancelar(handleGuia))) return;

            atualizacaoGuiaCancelada.AtualizarDados(handleGuia);
        }
    }
}
