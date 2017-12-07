using System.Collections.Generic;

namespace TestesUnitarios.Avaliacao.Business.Validacoes
{
    public interface IValidacoesFactory
    {
        IList<IValidacoes> Obter();
    }
}