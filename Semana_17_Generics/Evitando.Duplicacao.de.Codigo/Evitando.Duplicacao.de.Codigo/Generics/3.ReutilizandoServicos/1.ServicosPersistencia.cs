using Evitando.Duplicacao.de.Codigo.Generics._3.ReutilizandoServicos;
using Evitando.Duplicacao.de.Codigo.OO._2.Polimorfismo._5.ReutilizandoServicos.CodigoDuplicado;

namespace Evitando.Duplicacao.de.Codigo.Generics._3.ReutilizandoServicos
{
    public interface IBeneficiario
    {
        string nomeBeneficiario { get; set; }
        string numeroCarteira { get; set; }
        string numeroCNS { get; set; }
    }

    public interface IGuiaConsulta<T> where T : IBeneficiario
    {
        string numeroGuiaOperadora { get; set; }
        T dadosBeneficiario { get; set; }
    }
}

namespace Evitando.Duplicacao.de.Codigo.tissLoteGuiasV3_02_02
{
    // Serviços Tiss V3_02_02

    public partial class ctm_consultaGuia : IGuiaConsulta<ct_beneficiarioDados> {}
    public partial class ct_beneficiarioDados : IBeneficiario { }
}

namespace Evitando.Duplicacao.de.Codigo.tissLoteGuiasV3_03_02
{
    // Serviços Tiss V3_03_02

    public partial class ctm_consultaGuia : IGuiaConsulta<ct_beneficiarioDados> { }
    public partial class ct_beneficiarioDados : IBeneficiario { }
}


namespace Evitando.Duplicacao.de.Codigo.Generics._3.ReutilizandoServicos
{
    // Uma implementação para todas as versões

    public class EnvioGuias
    {
        public void Salvar<T>(IGuiaConsulta<T> guia) where T : IBeneficiario
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
        }
    }

    // Utilizando as classes

    class Program
    {
        static void Main(string[] args)
        {
            var envioGuias = new EnvioGuias();

            var guiaV3_03_02 = new tissLoteGuiasV3_03_02.ctm_consultaGuia();
            var guiaV3_02_02 = new tissLoteGuiasV3_02_02.ctm_consultaGuia();

            envioGuias.Salvar(guiaV3_03_02);
            envioGuias.Salvar(guiaV3_02_02);
        }
    }
}