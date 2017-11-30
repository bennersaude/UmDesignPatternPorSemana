using System.Collections.Generic;
using System.Linq;
using TestesUnitarios.EnvioLote.ValidacaoLote;

namespace TestesUnitarios.EnvioLote
{
    public class RepositorioLote
    {
        private readonly IServicoEnvioLote servicoEnvioLote;
        private readonly ILoteDao loteDao;
        private readonly IValidacaoLoteGuias validacaoLoteGuias;

        public RepositorioLote(IServicoEnvioLote servicoEnvioLote, ILoteDao loteDao, IValidacaoLoteGuias validacaoLoteGuias)
        {
            this.servicoEnvioLote = servicoEnvioLote;
            this.loteDao = loteDao;
            this.validacaoLoteGuias = validacaoLoteGuias;
        }

        public IEnumerable<ValidacaoDto> Salvar(Lote lote)
        {
            var listaValidacoes = validacaoLoteGuias.ValidarLote(lote);
            if (listaValidacoes.Any())
                return listaValidacoes;

            var resposta = servicoEnvioLote.Enviar(lote);

            MapearDadosServico(resposta, lote);

            loteDao.Salvar(lote);

            return Enumerable.Empty<ValidacaoDto>();
        }

        private static void MapearDadosServico(RespostaEnvioLoteDto resposta, Lote lote)
        {
            lote.Glosas = resposta.GlosasLote;

            foreach (var guiaDoLote in lote.Guias)
            {
                var numeroGuia = guiaDoLote.NumeroGuia;
                guiaDoLote.Glosas = resposta.GlosasGuia.Where(x => x.NumeroGuia == numeroGuia).SelectMany(x => x.GlosasGuia);
            }
        }
    }
}