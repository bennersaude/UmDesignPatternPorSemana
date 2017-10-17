using System;

namespace Evitando.Duplicacao.de.Codigo.Exercicios
{
    // Exercicio 2: Temos 2 dtos de sincronizacao, que utilizam
    // um periodo de dias, como podemos evitar a duplicacao
    // de codigo abaixo?

    public class SincronizacaoExtratoUtilizacao
    {
        public SincronizacaoListaUsuariosDataDTO ObterSincronizacao(int periodo, long[] beneficiarios)
        {
            return new SincronizacaoListaUsuariosData().ObterSincronizacao(periodo, beneficiarios, "SincronizacaoExtratoUtilizacao");
        }
    }

    public class SincronizacaoProtocoloPendenteNf
    {
        public SincronizacaoListaUsuariosDataDTO ObterSincronizacao(int periodo, long[] prestadores)
        {
            return new SincronizacaoListaUsuariosData().ObterSincronizacao(periodo, prestadores, "SincronizacaoProtocoloPendenteNf");
        }
    }

    /*Estas classe é dispensável caso não aja particularidades na sincronização,
        podendo ser realizada a chamada da classe "SincronizacaoListaUsuariosData" diretamente no controller.
    */

    public class SincronizacaoListaUsuariosDataDTO
    {
        public long[] ListaUsuarios { get; set; }
        public string UrlRetorno { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
    }

    public class SincronizacaoListaUsuariosData
    {
        public SincronizacaoListaUsuariosDataDTO ObterSincronizacao(int periodo, long[] prestadores, string uriRetorno)
        {
            return new SincronizacaoListaUsuariosDataDTO
            {
                ListaUsuarios = prestadores,
                DataInicial = DateTime.Now.AddDays(-periodo),
                DataFinal = DateTime.Now,
                UrlRetorno = uriRetorno
            };
        }
    }
}