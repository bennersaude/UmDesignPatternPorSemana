using System.Collections.Generic;

namespace TestesUnitarios.EnvioLote.ValidacaoLote
{
    public interface IValidacaoLoteGuias
    {
        IList<ValidacaoDto> ValidarLote(Lote lote);
    }
}