using System.Collections.Generic;
using TestesUnitarios.Avaliacao.Business;

namespace TestesUnitarios.Tests.Avaliacao.Business
{
    public class RespostaServicoDtoFake
    {
        public RespostaServicoDto ObterRespostaComErro()
        {
            return new RespostaServicoDto()
            {
                Sucesso = false,
                Erros = new List<string>()
                {

                }
            };
        }

        public RespostaServicoDto ObterRespostaComSucesso()
        {
            return new RespostaServicoDto()
            {
                Sucesso = true
            };
        }
    }
}
