using Evitando.Duplicacao.de.Codigo.OO;
using Evitando.Duplicacao.de.Codigo.tissLoteGuiasV3_02_02;

namespace Evitando.Duplicacao.de.Codigo.Exercicios.Resolucao
{
    public interface Guia
    {
        string NumeroGuia { get; set; }
        string ProfissionalExecutante { get; set; }
        string Beneficiario { get; set; }
    }

    public abstract class GuiaBase : Guia
    {
        public string NumeroGuia { get; set; }
        public string ProfissionalExecutante { get; set; }
        public string Beneficiario { get; set; }
    }

    public partial class SamGuia : GuiaBase { }
    public partial class SamAutoriz : GuiaBase { }
    public partial class WebAutoriz : GuiaBase { }


    public class AutorizacaoGuia<TEntidade> where TEntidade : Guia 
    {
        public ctm_consultaGuia Consultar(long handle)
        {
            var guia = Entidade<TEntidade>.Get(handle);

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

    public class ConsultaGuias : AutorizacaoGuia<SamGuia> { }
    public class ConsultaAutorizacao : AutorizacaoGuia<SamAutoriz> { }
    public class ConsultaAutorizacaoWeb : AutorizacaoGuia<WebAutoriz> { }
}
