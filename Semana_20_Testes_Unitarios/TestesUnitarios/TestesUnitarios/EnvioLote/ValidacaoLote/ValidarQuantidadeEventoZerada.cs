using System.Collections.Generic;
using System.Linq;

namespace TestesUnitarios.EnvioLote.ValidacaoLote
{
    public class ValidarQuantidadeEventoZerada : IValidacaoLote
    {
        public void Validar(Lote lote, IList<ValidacaoDto> validacoes)
        {
            if (PossuiEventoComQuantidadeZero(lote.Guias))
                validacoes.Add(new ValidacaoDto { Mensagem = "Lote possui guias com quantidade de eventos zerados.", Resultado = false });
        }

        private static bool PossuiEventoComQuantidadeZero(IEnumerable<Guia> guias)
        {
            return !guias.All(guia => guia.Eventos.Any(evento => evento.Quantidade != 0));
        }
    }
}