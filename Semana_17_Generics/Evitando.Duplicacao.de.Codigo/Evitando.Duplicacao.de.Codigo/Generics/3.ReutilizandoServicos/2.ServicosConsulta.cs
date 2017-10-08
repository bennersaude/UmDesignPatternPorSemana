using Evitando.Duplicacao.de.Codigo.OO._2.Polimorfismo._5.ReutilizandoServicos.CodigoDuplicado;

namespace Evitando.Duplicacao.de.Codigo.Generics._3.ReutilizandoServicos.ServicosConsulta
{
    public class ServicoGuiaConsulta<TGuia, TBeneficiario> 
        where TGuia : IGuiaConsulta<TBeneficiario>, new()
        where TBeneficiario : IBeneficiario, new()
    {
        public TGuia Consulta()
        {
            var guiaDoBanco = new Guia();

            return new TGuia
            {
                numeroGuiaOperadora = guiaDoBanco.NumeroGuiaOperadora,
                dadosBeneficiario = new TBeneficiario
                {
                    nomeBeneficiario = guiaDoBanco.Beneficiario.Nome,
                    numeroCarteira = guiaDoBanco.Beneficiario.NumeroCarteirinha,
                    numeroCNS = guiaDoBanco.Beneficiario.NumeroCns
                }
            };
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var servicoV3_03_02 = new ServicoGuiaConsulta<tissLoteGuiasV3_03_02.ctm_consultaGuia, tissLoteGuiasV3_03_02.ct_beneficiarioDados>();
            var servicoV3_02_02 = new ServicoGuiaConsulta<tissLoteGuiasV3_02_02.ctm_consultaGuia, tissLoteGuiasV3_02_02.ct_beneficiarioDados>();
        }
    }
}
