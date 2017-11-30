using System.Collections.Generic;
using System.Linq;

namespace TestesUnitarios.EnvioLote.ValidacaoLote
{
    public class ValidarQuantidadeGuiasLote : IValidacaoLote
    {
        public void Validar(Lote lote, IList<ValidacaoDto> validacoes)
        {
            if (lote.Guias.Count() > 100)
                validacoes.Add(new ValidacaoDto { Mensagem = "Lote possui mais de 100 guias.", Resultado = false });
        }
    }
}