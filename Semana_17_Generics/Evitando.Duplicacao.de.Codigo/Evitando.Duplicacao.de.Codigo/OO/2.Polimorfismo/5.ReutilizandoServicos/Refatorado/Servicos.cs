using System;
using Evitando.Duplicacao.de.Codigo.OO._2.Polimorfismo._5.ReutilizandoServicos.CodigoDuplicado;
using Evitando.Duplicacao.de.Codigo.OO._2.Polimorfismo._5.ReutilizandoServicos.Refatorado;

namespace Evitando.Duplicacao.de.Codigo.OO._2.Polimorfismo._5.ReutilizandoServicos.Refatorado
{
    // Interfaces para serviços

    public interface IBeneficiario
    {
        string nomeBeneficiario { get; set; }
        string numeroCarteira { get; set; }
        string numeroCNS { get; set; }
    }

    public interface IGuiaConsulta
    {
        string numeroGuiaOperadora { get; set; }
        IBeneficiario ObterDadosBeneficiario();
    }
}

namespace Evitando.Duplicacao.de.Codigo.tissLoteGuiasV3_02_02
{
    // Serviços Tiss V3_02_02

    public partial class ctm_consultaGuia : IGuiaConsulta
    {
        public IBeneficiario ObterDadosBeneficiario()
        {
            return dadosBeneficiario;
        }
    }
    public partial class ct_beneficiarioDados : IBeneficiario { }
}

namespace Evitando.Duplicacao.de.Codigo.tissLoteGuiasV3_03_02
{
    // Serviços Tiss V3_03_02

    public partial class ctm_consultaGuia : IGuiaConsulta
    {
        public IBeneficiario ObterDadosBeneficiario()
        {
            return dadosBeneficiario;
        }
    }
    public partial class ct_beneficiarioDados : IBeneficiario { }
}

namespace Evitando.Duplicacao.de.Codigo.OO._2.Polimorfismo._5.ReutilizandoServicos.Refatorado
{
    // Uma implementação para todas as versões

    public class EnvioGuias
    {
        public void Salvar(IGuiaConsulta guia)
        {
            var beneficiario = guia.ObterDadosBeneficiario();
            var novaGuia = new Guia
            {
                NumeroGuiaOperadora = guia.numeroGuiaOperadora,
                Beneficiario = new Beneficiario
                {
                    Nome = beneficiario.nomeBeneficiario,
                    NumeroCarteirinha = beneficiario.numeroCarteira,
                    NumeroCns = beneficiario.numeroCNS
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
