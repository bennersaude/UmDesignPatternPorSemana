using System;
using UmDesignPatternPorSemana.Proxy.ProtectionProxy.Stubs;

namespace UmDesignPatternPorSemana.Proxy.VirtualProxy
{
    public class GuiaDao : IDao<Guia>
    {
        public Guia GetById(long handle)
        {
            Console.WriteLine($"SELECT * FROM GUIA WHERE HANDLE = {handle}");

            return null;
        }

        public void Save(Guia instance)
        {
            Console.WriteLine("INSERT OU UPDATE");
        }
    }
}