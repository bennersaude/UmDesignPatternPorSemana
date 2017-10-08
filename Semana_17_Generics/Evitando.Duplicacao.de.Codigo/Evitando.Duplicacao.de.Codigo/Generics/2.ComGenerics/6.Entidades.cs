namespace Evitando.Duplicacao.de.Codigo.Generics._2.ComGenerics
{
    public partial class SamPrestador : OO.Entidade<SamPrestador>
    {
        public string Nome { get; set; }
    }

    public interface ISamPrestadorProperties
    {
        string Nome { get; set; }
    }

    public partial class SamPrestador : ISamPrestadorProperties
    {
    }

    public class DaoGenerico<TEntidade, TInterface> where TEntidade : OO.Entidade<TEntidade>, TInterface
    {
        public TInterface Create()
        {
            return OO.Entidade<TEntidade>.Create();
        }
    }

    public class BusinessComponent
    {
        public void Salvando()
        {
            var meuDao = new DaoGenerico<SamPrestador, ISamPrestadorProperties>();
            var novaEntidade = meuDao.Create();
        }
    }

}
