using Evitando.Duplicacao.de.Codigo.OO;
using Evitando.Duplicacao.de.Codigo.tissLoteGuiasV3_02_02;

namespace Evitando.Duplicacao.de.Codigo.Exercicios
{
    // Exercicio 3: Temos 3 entidades que representam uma autorizacao,
    // precisamos converte-las para a resposta de um servico, o codigo
    // atual triplica essa implementacao, como podemos melhorar?

    // Entidades

    public interface ISamGuiaProperties
    {
        string NumeroGuia { get; set; }
        string ProfissionalExecutante { get; set; }
        string Beneficiario { get; set; }
    }

    public class SamGuia : Entidade<SamGuia>, ISamGuiaProperties
    {
        public string NumeroGuia { get; set; }
        public string ProfissionalExecutante { get; set; }
        public string Beneficiario { get; set; }
    }

    public class SamAutoriz : Entidade<SamAutoriz>, ISamGuiaProperties
    {
        public string NumeroGuia { get; set; }
        public string ProfissionalExecutante { get; set; }
        public string Beneficiario { get; set; }
    }

    public class WebAutoriz : Entidade<WebAutoriz>, ISamGuiaProperties
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
            return new MontadorCtmConsultaGuia().Montar(SamGuia.Get(handle));
        }
    }

    public class ConsultaAutorizacao
    {
        public ctm_consultaGuia ConsultarAutorizacao(long handle)
        {
            return new MontadorCtmConsultaGuia().Montar(SamAutoriz.Get(handle));
        }
    }

    public class ConsultaAutorizacaoWeb
    {
        public ctm_consultaGuia ConsultarAutorizacaoWeb(long handle)
        {
            return new MontadorCtmConsultaGuia().Montar(WebAutoriz.Get(handle));
        }
    }

    public class MontadorCtmConsultaGuia
    {
        public ctm_consultaGuia Montar(ISamGuiaProperties guia)
        {
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
