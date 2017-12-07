using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Avaliacao.Business
{
    public interface IValidadorGuias
    {
        bool GuiaEhValida(IGuiaProperties guia);
    }
}