using System;

namespace Evitando.Duplicacao.de.Codigo.Exercicios.Resolucao
{
    public interface ISincronizacao
    {
        long[] IdsSincronizacao { get; set; }
        string UrlRetorno { get; set; }
        DateTime DataInicial { get; set; }
        DateTime DataFinal { get; set; }
    }

    public abstract class SincronizacaoBase<TEntidade> : ISincronizacao where TEntidade : ISincronizacao, new()
    {
        public long[] IdsSincronizacao { get; set; }
        public string UrlRetorno { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }

        public TEntidade ObterSincronizacao(string urlRemoto, int periodo, long[] IdsSincronizacao)
        {
            return new TEntidade
            {
                IdsSincronizacao = IdsSincronizacao,
                DataInicial = DateTime.Now.AddDays(-periodo),
                DataFinal = DateTime.Now,
                UrlRetorno = urlRemoto
            };
        }
    }

    public class SincronizacaoProtocoloPendenteNfDto : SincronizacaoBase<SincronizacaoProtocoloPendenteNfDto> { }

    public class SincronizacaoExtratoUtilizacaoDto : SincronizacaoBase<SincronizacaoExtratoUtilizacaoDto> { }
}
