using System;

namespace Evitando.Duplicacao.de.Codigo.Exercicios
{
    // Exercicio 2: Temos 2 dtos de sincronizacao, que utilizam
    // um periodo de dias, como podemos evitar a duplicacao
    // de codigo abaixo?

    public class SincronizacaoExtratoUtilizacaoDto    
    {
        public long[] IdBeneficiarios { get; set; }
        public string UrlRetorno { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
    }

    public class SincronizacaoProtocoloPendenteNfDto
    {
        public long[] ListaIdPrestadores { get; set; }
        public string UrlRetorno { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
    }

    public class SincronizacaoExtratoUtilizacao
    {
        public SincronizacaoExtratoUtilizacaoDto ObterSincronizacao(int periodo, long[] beneficiarios)
        {
            return new SincronizacaoExtratoUtilizacaoDto
            {
                IdBeneficiarios = beneficiarios,
                DataInicial = DateTime.Now.AddDays(-periodo),
                DataFinal = DateTime.Now,
                UrlRetorno = "SincronizacaoExtratoUtilizacao"
            };
        }
    }

    public class SincronizacaoProtocoloPendenteNf
    {
        public SincronizacaoProtocoloPendenteNfDto ObterSincronizacao(int periodo, long[] prestadores)
        {
            return new SincronizacaoProtocoloPendenteNfDto
            {
                ListaIdPrestadores = prestadores,
                DataInicial = DateTime.Now.AddDays(-periodo),
                DataFinal = DateTime.Now,
                UrlRetorno = "SincronizacaoProtocoloPendenteNf"
            };
        }
    }
}
