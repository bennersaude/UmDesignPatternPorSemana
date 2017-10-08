using Evitando.Duplicacao.de.Codigo.OO;
using Evitando.Duplicacao.de.Codigo.tissLoteGuiasV3_02_02;

namespace Evitando.Duplicacao.de.Codigo.Exercicios
{
    // Exercicio 3: Temos 3 entidades que representam uma autorizacao,
    // precisamos converte-las para a resposta de um servico, o codigo
    // atual triplica essa implementacao, como podemos melhorar?

    // Entidades

    public class SamGuia : Entidade<SamGuia>
    {
        public string NumeroGuia { get; set; }
        public string ProfissionalExecutante { get; set; }
        public string Beneficiario { get; set; }
    }

    public class SamAutoriz : Entidade<SamAutoriz>
    {
        public string NumeroGuia { get; set; }
        public string ProfissionalExecutante { get; set; }
        public string Beneficiario { get; set; }
    }

    public class WebAutoriz : Entidade<SamAutoriz>
    {
        public string NumeroGuia { get; set; }
        public string ProfissionalExecutante { get; set; }
        public string Beneficiario { get; set; }
    }

    // Serviços

    public class ConsultaGuias
    {
        public ctm_consultaGuia ConsultarGuia(long handle)
        {
            var guia = SamGuia.Get(handle);

            return new ctm_consultaGuia
            {
                numeroGuiaOperadora = guia.NumeroGuia,
                dadosBeneficiario = new ct_beneficiarioDados
                {
                    nomeBeneficiario = guia.Beneficiario
                },
                profissionalExecutante = new ct_contratadoProfissionalDados
                {
                    nomeProfissional = guia.ProfissionalExecutante
                }
            };
        }
    }

    public class ConsultaAutorizacao
    {
        public ctm_consultaGuia ConsultarAutorizacao(long handle)
        {
            var guia = SamAutoriz.Get(handle);

            return new ctm_consultaGuia
            {
                numeroGuiaOperadora = guia.NumeroGuia,
                dadosBeneficiario = new ct_beneficiarioDados
                {
                    nomeBeneficiario = guia.Beneficiario
                },
                profissionalExecutante = new ct_contratadoProfissionalDados
                {
                    nomeProfissional = guia.ProfissionalExecutante
                }
            };
        }
    }

    public class ConsultaAutorizacaoWeb
    {
        public ctm_consultaGuia ConsultarAutorizacaoWeb(long handle)
        {
            var guia = WebAutoriz.Get(handle);

            return new ctm_consultaGuia
            {
                numeroGuiaOperadora = guia.NumeroGuia,
                dadosBeneficiario = new ct_beneficiarioDados
                {
                    nomeBeneficiario = guia.Beneficiario
                },
                profissionalExecutante = new ct_contratadoProfissionalDados
                {
                    nomeProfissional = guia.ProfissionalExecutante
                }
            };
        }
    }
}
