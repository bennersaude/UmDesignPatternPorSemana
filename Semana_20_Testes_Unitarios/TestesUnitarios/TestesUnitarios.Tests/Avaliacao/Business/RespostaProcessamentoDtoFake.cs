using System.Collections.Generic;
using TestesUnitarios.Avaliacao.Business;

namespace TestesUnitarios.Tests.Avaliacao.Business
{
    public class RespostaProcessamentoDtoFake
    {
        public RespostaProcessamentoDto ObterRespostaComErro()
        {
            return new RespostaProcessamentoDto()
            {
                Sucesso = false,
                Erros = new List<string>()
                {

                }
            };
        }

        public RespostaProcessamentoDto ObterRespostaComSucesso()
        {
            return new RespostaProcessamentoDto()
            {
                Sucesso = true
            };
        }
    }
}
