using System.Linq;

namespace TestesUnitarios.EnvioLote
{
    public class ProcessoLote
    {
        private readonly IValidacaoEnvioLote validacaoEnvioLote;
        private readonly IServicoEnvioLote servicoEnvioLote;
        private readonly IRepositorioLote repositorioLote;

        public ProcessoLote(
            IValidacaoEnvioLote validacaoEnvioLote, 
            IServicoEnvioLote servicoEnvioLote, 
            IRepositorioLote repositorioLote)
        {
            this.validacaoEnvioLote = validacaoEnvioLote;
            this.servicoEnvioLote = servicoEnvioLote;
            this.repositorioLote = repositorioLote;
        }

        public void Processar(Lote lote)
        {
            if (!validacaoEnvioLote.Validar(lote).Resultado)
                return;

            var resposta = servicoEnvioLote.Enviar(lote);

            MapearResposta(lote, resposta);

            repositorioLote.Salvar(lote);
        }

        private static void MapearResposta(Lote lote, RespostaEnvioLoteDto resposta)
        {
            lote.Glosas = resposta.GlosasLote;
            
            foreach (var guia in lote.Guias)
            {
                var glosaGuia = resposta.GlosasGuia.FirstOrDefault(glosa => glosa.NumeroGuia == guia.NumeroGuia);
                if (glosaGuia != null)
                    guia.Glosas = glosaGuia.GlosasGuia;
            }
        }
    }
}
