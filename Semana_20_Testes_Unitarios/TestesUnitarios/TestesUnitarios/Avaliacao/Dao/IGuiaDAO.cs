using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Avaliacao.Dao
{
    public interface IGuiaDAO
    {
        IGuiaProperties GravarGuia(IGuiaProperties guia);
    }
}