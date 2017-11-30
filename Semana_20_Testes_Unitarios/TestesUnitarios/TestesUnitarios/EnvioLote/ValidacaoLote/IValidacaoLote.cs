using System.Collections.Generic;

namespace TestesUnitarios.EnvioLote.ValidacaoLote
{
    public interface IValidacaoLote
    {
        void Validar(Lote lote, IList<ValidacaoDto> validacoes);
    }
}