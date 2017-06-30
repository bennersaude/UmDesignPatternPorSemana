using UmDesignPatternPorSemana.Proxy.ProtectionProxy.Stubs;

namespace UmDesignPatternPorSemana.Proxy.VirtualProxy
{
    public class GuiaController
    {
        public Guia Detalhes(int handle)
        {
            var factoryDao = new FactoryGuiaDao();
            var guiaDao = factoryDao.ObterDao();

            return guiaDao.GetById(handle);
        }
    }
}