using System.Collections.Generic;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Avaliacao.Business
{
    public interface IValidacaoGuia
    {
        List<string> ValidarGuia(IGuiaProperties guia);
    }
}