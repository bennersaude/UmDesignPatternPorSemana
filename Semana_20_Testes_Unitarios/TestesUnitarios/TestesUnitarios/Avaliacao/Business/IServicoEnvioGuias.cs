using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Avaliacao.Business
{
    public interface IServicoEnvioGuias
    {
        RespostaServicoDto EnviarGuia(Guia guia);
    }
}