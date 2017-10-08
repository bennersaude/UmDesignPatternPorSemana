using Evitando.Duplicacao.de.Codigo.tissLoteGuiasV3_02_02;

namespace Evitando.Duplicacao.de.Codigo.OO._2.Polimorfismo._4.ReutilizandoEntidades.CodigoDuplicado
{
    // Entidades

    public partial class SamGuia : Entidade<SamGuia>
    {
        public string ProfissionalExecutante { get; set; }
        public string Beneficiario { get; set; }
    }

    public partial class SamAutoriz : Entidade<SamAutoriz>
    {
        public string ProfissionalExecutante { get; set; }
        public string Beneficiario { get; set; }
    }

    // Implementação de serviços com a mesma resposta

    public class ConsultaGuias
    {
        public ctm_consultaGuia ConsultarGuia(long handle)
        {
            var guia = SamGuia.Get(handle);
            return new ctm_consultaGuia
            {
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

    public class ConsultaAutorizacoes
    {
        public ctm_consultaGuia ConsultarAutorizacao(long handle)
        {
            var guia = SamAutoriz.Get(handle);
            return new ctm_consultaGuia
            {
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

    // Utilizando as classes
    class Program
    {
        static void Main(string[] args)
        {
            var consultaGuias = new ConsultaGuias();
            var consultaAutorizacoes = new ConsultaAutorizacoes();

            var respostaGuia = consultaGuias.ConsultarGuia(87);
            var respostaAutorizacao = consultaAutorizacoes.ConsultarAutorizacao(88);
        }
    }
}
