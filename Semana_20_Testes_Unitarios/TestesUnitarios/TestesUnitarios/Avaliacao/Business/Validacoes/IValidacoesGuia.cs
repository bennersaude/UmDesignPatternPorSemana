using System.Collections.Generic;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Avaliacao.Business.Validacoes
{
    public interface IValidacoesGuia
    {
        IList<string> Validar(IGuiaProperties guia);
    }
}