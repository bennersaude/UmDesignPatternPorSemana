using System.Collections.Generic;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Avaliacao.Business
{
    public class ServicoEnvioGuias : IServicoEnvioGuias
    {
        public RespostaServicoDto EnviarGuia(IGuiaProperties guia)
        {
            return new RespostaServicoDto()
            {
                Erros = new List<string>(),
                Sucesso = false
            };
        }
    }
}
