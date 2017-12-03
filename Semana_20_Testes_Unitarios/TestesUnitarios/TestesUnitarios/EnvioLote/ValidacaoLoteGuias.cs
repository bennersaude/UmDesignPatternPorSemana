using System.Collections.Generic;
using System.Linq;

namespace TestesUnitarios.EnvioLote
{
    public class ValidacaoLoteGuias : IValidacaoLoteGuias
    {
        public List<ValidacaoDto> Validar(Lote lote)
        {
            var validacoes = new List<ValidacaoDto>();

            if (lote.Guias.Count() > 100)
                validacoes.Add( new ValidacaoDto { Mensagem = "Lote não pode possuir mais que 100 guias para envio", Resultado = false });

            if (lote.Guias.Any(g => g.Eventos == null || !g.Eventos.Any()))
                validacoes.Add(new ValidacaoDto { Mensagem = "Lote não pode possuir guias sem eventos para envio", Resultado = false });

            if (lote.Guias.Any(g => g.Eventos != null && g.Eventos.Any(e => e.Quantidade == 0)))
                validacoes.Add(new ValidacaoDto { Mensagem = "Lote não pode possuir eventos com quantidade 0 para envio", Resultado = false });

            return validacoes;
        }
    }
}