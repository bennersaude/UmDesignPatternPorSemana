using System.Collections.Generic;
using UmDesignPatternPorSemana.Proxy.ProtectionProxy.Stubs;

namespace UmDesignPatternPorSemana.Proxy.VirtualProxy
{
    public class GuiaDaoProxy : IDao<Guia>
    {
        private readonly IDao<Guia> guiaDao;
        private readonly IDictionary<long, Guia> cache;

        public GuiaDaoProxy(IDao<Guia> guiaDao, IDictionary<long, Guia> cache)
        {
            this.guiaDao = guiaDao;
            this.cache = cache;
        }

        public Guia GetById(long handle)
        {
            return cache.ContainsKey(handle) ? cache[handle] : guiaDao.GetById(handle);
        }

        public void Save(Guia instance)
        {
            cache[instance.Handle] = instance;
            guiaDao.Save(instance);
        }
    }
}