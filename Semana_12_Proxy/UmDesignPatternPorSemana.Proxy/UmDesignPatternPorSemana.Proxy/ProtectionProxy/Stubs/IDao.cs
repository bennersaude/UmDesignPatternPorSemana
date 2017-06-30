namespace UmDesignPatternPorSemana.Proxy.ProtectionProxy.Stubs
{
    public interface IDao<T>
    {
        T GetById(long handle);
        void Save(T instance);
    }
}