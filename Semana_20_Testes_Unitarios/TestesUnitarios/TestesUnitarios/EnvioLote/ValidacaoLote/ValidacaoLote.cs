using System.Collections.Generic;

namespace TestesUnitarios.EnvioLote.ValidacaoLote
{
    public class ValidacaoLoteGuias : IValidacaoLoteGuias
    {
        public IList<ValidacaoDto> ValidarLote(Lote lote)
        {
            var validacoesDto = new List<ValidacaoDto>();

            var validacoes = ValidacoesLoteFactory.ObterValidacoes();

            foreach (var validacaoLote in validacoes)
            {
                validacaoLote.Validar(lote, validacoesDto);
            }

            return validacoesDto;
        }
    }
}