using System.Linq;

namespace TestesUnitarios.EnvioLote
{
    public class ValidacaoEnvioLote : IValidacaoEnvioLote
    {
        public ValidacaoDto Validar(Lote lote)
        {
            if (lote.Guias.Count() > 100)
                return new ValidacaoDto {Mensagem = "Não pode ter mais que 100", Resultado = false};
            if (lote.Guias.Any(g => g.Eventos == null || !g.Eventos.Any()))
                return new ValidacaoDto { Mensagem = "Não pode ter guias sem eventos", Resultado = false };
            if (lote.Guias.Any(g => g.Eventos.Any(e => e.Quantidade == 0)))
                return new ValidacaoDto { Mensagem = "Não pode ter eventos com quantidade 0", Resultado = false };

            return new ValidacaoDto {Mensagem = "Ok", Resultado = true};
        }
    }
}
