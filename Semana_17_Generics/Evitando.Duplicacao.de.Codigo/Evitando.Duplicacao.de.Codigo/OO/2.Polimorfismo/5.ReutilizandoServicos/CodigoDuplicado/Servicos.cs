namespace Evitando.Duplicacao.de.Codigo.OO._2.Polimorfismo._5.ReutilizandoServicos.CodigoDuplicado
{
    // Entidades

    public class Beneficiario
    {
        public string Nome { get; set; }
        public string NumeroCarteirinha { get; set; }
        public string NumeroCns { get; set; }
    }
    public class Guia : Entidade<Guia>
    {
        public string NumeroGuiaOperadora { get; set; }
        public Beneficiario Beneficiario { get; set; }
    }

    // Serviços Tiss V3_02_02

    namespace V3_02_02
    {
        public class EnvioGuias
        {
            public void Salvar(tissLoteGuiasV3_02_02.ctm_consultaGuia guia)
            {
                var novaGuia = new Guia
                {
                    NumeroGuiaOperadora = guia.numeroGuiaOperadora,
                    Beneficiario = new Beneficiario
                    {
                        Nome = guia.dadosBeneficiario.nomeBeneficiario,
                        NumeroCarteirinha = guia.dadosBeneficiario.numeroCarteira,
                        NumeroCns = guia.dadosBeneficiario.numeroCNS
                    }
                };

                novaGuia.Salvar();
            }
        }
    }

    // Serviços Tiss V3_03_02

    namespace V3_03_02
    {
        public class EnvioGuias
        {
            public void Salvar(tissLoteGuiasV3_03_02.ctm_consultaGuia guia)
            {
                var novaGuia = new Guia
                {
                    NumeroGuiaOperadora = guia.numeroGuiaOperadora,
                    Beneficiario = new Beneficiario
                    {
                        Nome = guia.dadosBeneficiario.nomeBeneficiario,
                        NumeroCarteirinha = guia.dadosBeneficiario.numeroCarteira,
                        NumeroCns = guia.dadosBeneficiario.numeroCNS
                    }
                };

                novaGuia.Salvar();
            }
        }
    }

    // Utilizando as classes

    class Program
    {
        static void Main(string[] args)
        {
            var envioGuiasV3_03_02 = new V3_03_02.EnvioGuias();
            var envioGuiasV3_02_02 = new V3_02_02.EnvioGuias();

            var guiaV3_03_02 = new tissLoteGuiasV3_03_02.ctm_consultaGuia();
            var guiaV3_02_02 = new tissLoteGuiasV3_02_02.ctm_consultaGuia();

            envioGuiasV3_03_02.Salvar(guiaV3_03_02);
            envioGuiasV3_02_02.Salvar(guiaV3_02_02);
        }
    }
}
