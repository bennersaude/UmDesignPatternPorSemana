using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Avaliacao
{
    public interface IServicoEnvioGuias
    {
        bool Enviar(IGuiaProperties guia);
    }
}
