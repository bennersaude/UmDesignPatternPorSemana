using System.Linq;

namespace TestesUnitarios.EnvioLote
{
    public class ServicoLoteGuias
    {
        private readonly IServicoEnvioLote _servicoEnvioLote;
        private readonly IValidacaoLoteGuias _validacaoLoteGuias;
        private readonly ISalvarLoteGuias _salvarLoteGuias;

        public ServicoLoteGuias(IServicoEnvioLote servicoEnvioLote, IValidacaoLoteGuias validacaoLoteGuias, ISalvarLoteGuias salvarLoteGuias)
        {
            _servicoEnvioLote = servicoEnvioLote;
            _validacaoLoteGuias = validacaoLoteGuias;
            _salvarLoteGuias = salvarLoteGuias;
        }

        public void ProcessarLote(Lote lote)
        {
            var validacoes = _validacaoLoteGuias.Validar(lote);

            if (validacoes.Any(v => !v.Resultado)) return;

            var resposta = _servicoEnvioLote.Enviar(lote);

            ProcessarRespostaEnvio(lote, resposta);

            _salvarLoteGuias.Salvar(lote);
        }

        private void ProcessarRespostaEnvio(Lote lote, RespostaEnvioLoteDto resposta)
        {
            lote.Glosas = resposta.GlosasLote;

            foreach (var guia in lote.Guias)
            {
                var glosaGuia = resposta.GlosasGuia.FirstOrDefault(g => g.NumeroGuia == guia.NumeroGuia);
                if (glosaGuia != null)
                    guia.Glosas = glosaGuia.GlosasGuia;
            }
        }
    }
}