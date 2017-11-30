using System.Collections.Generic;
using System.Linq;

namespace TestesUnitarios.EnvioLote.ValidacaoLote
{
    public class ValidarGuiasSemEvento : IValidacaoLote
    {
        public void Validar(Lote lote, IList<ValidacaoDto> validacoes)
        {
            if (PossuiGuiaSemEvento(lote.Guias))
                validacoes.Add(new ValidacaoDto { Mensagem = "Lote possui guia sem evento.", Resultado = false });
        }

        private static bool PossuiGuiaSemEvento(IEnumerable<Guia> guias)
        {
            return !guias.All(guia => guia.Eventos.Any());
        }
    }
}