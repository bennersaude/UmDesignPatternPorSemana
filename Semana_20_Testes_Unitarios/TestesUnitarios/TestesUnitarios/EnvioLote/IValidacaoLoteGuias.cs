using System.Collections.Generic;

namespace TestesUnitarios.EnvioLote
{
    public interface IValidacaoLoteGuias
    {
        List<ValidacaoDto> Validar(Lote lote);
    }
}
