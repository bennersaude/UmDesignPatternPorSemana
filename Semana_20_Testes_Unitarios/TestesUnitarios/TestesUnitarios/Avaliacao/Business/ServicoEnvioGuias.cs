using System.Collections.Generic;
using TestesUnitarios.Avaliacao.Business.Processamento;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Avaliacao.Business
{
    public class ServicoEnvioGuias : IProcessadorGuia
    {
        public ProcessamentoDTOBase Executar(IGuiaProperties guia)
        {
            return new RespostaServicoDto()
            {
                Erros = new List<string>(),
                Sucesso = false
            };
        }
    }
}
