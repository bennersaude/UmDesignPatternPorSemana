using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Avaliacao.Dao
{
    public class FactoryGuiaDAO
    {
        public GuiaDAO Obter()
        {
            return new GuiaDAO(new Dao<Guia, IGuiaProperties>());
        }
    }
}