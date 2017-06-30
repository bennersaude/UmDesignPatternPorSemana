namespace UmDesignPatternPorSemana.Proxy.ProtectionProxy.Stubs
{
    public class Dao<T> : IDao<T>
    {
        public T GetById(long handle)
        {
            throw new System.NotImplementedException();
        }

        public void Save(T instance)
        {
            throw new System.NotImplementedException();
        }
    }
}