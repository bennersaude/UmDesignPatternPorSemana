using Evitando.Duplicacao.de.Codigo.OO._2.Polimorfismo._4.ReutilizandoEntidades.CodigoDuplicado;
using Evitando.Duplicacao.de.Codigo.OO._2.Polimorfismo._4.ReutilizandoEntidades.Refatorado;
using Evitando.Duplicacao.de.Codigo.tissLoteGuiasV3_02_02;

namespace Evitando.Duplicacao.de.Codigo.OO._2.Polimorfismo._4.ReutilizandoEntidades.Refatorado
{
    // Interface
    public interface IGuia
    {
        string ProfissionalExecutante { get; set; }
        string Beneficiario { get; set; }
    }
}

namespace Evitando.Duplicacao.de.Codigo.OO._2.Polimorfismo._4.ReutilizandoEntidades.CodigoDuplicado
{
    //Entidades
    public partial class SamGuia : IGuia { }
    public partial class SamAutoriz : IGuia { }
}

namespace Evitando.Duplicacao.de.Codigo.OO._2.Polimorfismo._4.ReutilizandoEntidades.Refatorado
{
    // Servico
    public class ConsultaGuias
    {
        public ctm_consultaGuia MapearResposta(IGuia guia)
        {
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

            var respostaGuia = consultaGuias.MapearResposta(new SamGuia());
            var respostaAutorizacao = consultaGuias.MapearResposta(new SamAutoriz());
        }
    }
}
