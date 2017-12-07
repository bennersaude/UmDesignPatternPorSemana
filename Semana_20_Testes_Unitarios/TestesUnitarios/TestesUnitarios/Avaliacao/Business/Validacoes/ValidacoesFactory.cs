using System.Collections.Generic;

namespace TestesUnitarios.Avaliacao.Business.Validacoes
{
    public class ValidacoesFactory : IValidacoesFactory
    {
        public IList<IValidacoes> Obter()
        {
            return new List<IValidacoes>
            {
                new DataAtendimento()
            };
        }
    }
}