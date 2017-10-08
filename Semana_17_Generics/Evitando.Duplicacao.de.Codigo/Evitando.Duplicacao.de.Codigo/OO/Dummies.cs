namespace Evitando.Duplicacao.de.Codigo.OO
{
    public class Entidade<T>
    {
        public long Handle { get; set; }

        public void Salvar()
        {

        }

        public static T Create()
        {
            return default(T);
        }

        public static T Get(long id)
        {
            return default(T);
        }

        public static T GetFirstOrDefault(Criteria where)
        {
            return default(T);
        }
    }

    public class Criteria
    {
        public Criteria(string where, params string[] argumentos)
        {

        }
    }
}
