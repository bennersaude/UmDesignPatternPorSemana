using System;

namespace UmDesignPatternPorSemana.Strategy.ElegibilidadeBeneficiario
{

    public class Beneficiario
    {
        public DateTime DataNascimento { get; set; }
        public bool Dependente { get; set; }
    }

    public class DadosAtendimento
    {
        public Beneficiario Beneficiario { get; set; }
        public DateTime DataAtendimento { get; set; }
    }
}