using System.Collections.Generic;
using UmDesignPatternPorSemana.Proxy.ProtectionProxy.Stubs;

namespace UmDesignPatternPorSemana.Proxy.VirtualProxy
{
    public class FactoryGuiaDao
    {
        public IDao<Guia> ObterDao()
        {
            return new GuiaDaoProxy(new Dao<Guia>(), new Dictionary<long, Guia>());
        }
    }
}