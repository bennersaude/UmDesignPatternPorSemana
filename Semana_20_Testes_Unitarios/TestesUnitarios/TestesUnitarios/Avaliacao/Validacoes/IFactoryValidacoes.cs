using System.Collections.Generic;

namespace TestesUnitarios.Avaliacao.Validacoes
{
    public interface IFactoryValidacoes
    {
        IEnumerable<IValidacaoGuia> ObeterValidacoes();
    }
}