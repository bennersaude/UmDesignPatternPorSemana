using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Avaliacao.Business
{
    public class ServicoEnvioGuias : IServicoEnvioGuias
    {
        public RespostaServicoDto EnviarGuia(IGuiaProperties guia)
        {
            if (guia.Handle == 1)
            {
                return new RespostaServicoDto()
                {
                    Sucesso = false
                };
            }

            return new RespostaServicoDto()
            {
                Sucesso = true
            };
        }
    }
}