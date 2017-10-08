using System;

namespace UmDesignPatternPorSemana.Strategy.ElegibilidadeBeneficiario.RegrasElegibilidade
{
    public class BeneficiarioComIdadeInvalidaParaSerDependente : IRegraElegibilidade
    {
        private readonly IParametrosOperadora parametrosOperadora;

        public BeneficiarioComIdadeInvalidaParaSerDependente(IParametrosOperadora parametrosOperadora)
        {
            this.parametrosOperadora = parametrosOperadora;
        }

        public bool VerificarElegibilidade(DadosAtendimento atendimento)
        {
            if (!atendimento.Beneficiario.Dependente) return true;

            var idadeBeneficiario = ObterIdade(atendimento.Beneficiario.DataNascimento, atendimento.DataAtendimento);
            var idadeMaximaPermitida = parametrosOperadora.ObterIdadeMaximaPermitidaParaDependentes();

            return idadeBeneficiario <= idadeMaximaPermitida;
        }

        public int ObterIdade(DateTime nascimento, DateTime referencia)
        {
            return 0;
        }
    }
}
