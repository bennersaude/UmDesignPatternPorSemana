using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Avaliacao.Dao
{
    public class GuiaDAO : IGuiaDAO
    {
        private readonly IDao<IGuiaProperties> dao;

        public GuiaDAO(IDao<IGuiaProperties> dao)
        {
            this.dao = dao;
        }

        public IGuiaProperties GravarGuia(IGuiaProperties guia)
        {
            var guiaNova = dao.Create();

            guiaNova.DataAtendimento = guia.DataAtendimento;
            guiaNova.IndicadorDeclaracaoObitoRn = guia.IndicadorDeclaracaoObitoRn;
            guiaNova.NumeroDeclaracaoObito = guia.NumeroDeclaracaoObito;

            dao.Save<Guia>(guiaNova);

            return guiaNova;
        }
    }
}