using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmDesignPatternPorSemana.Strategy.ElegibilidadeBeneficiario
{
    public interface IRegraElegibilidade
    {
        bool VerificarElegibilidade(DadosAtendimento atendimento);
    }

    public class VerificacaoElegibilidade
    {
        private readonly IEnumerable<IRegraElegibilidade> regras;

        public VerificacaoElegibilidade(IEnumerable<IRegraElegibilidade> regras)
        {
            this.regras = regras;
        }

        public bool BeneficiarioEstaElegivel(DadosAtendimento atendimento)
        {
            return regras.All(regra => regra.VerificarElegibilidade(atendimento));
        }
    }
}
