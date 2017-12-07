using System.Collections.Generic;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Avaliacao.Validacao
{
    public interface IValidacaoGuia
    {
        IList<string> ObterValidacoes(IGuiaProperties guia);
    }
}
