using UmDesignPatternPorSemana.Proxy.ProtectionProxy.Stubs;

namespace UmDesignPatternPorSemana.Proxy.ProtectionProxy
{
    public class GuiaController
    {
        public void CancelarGuia(int handle)
        {
            var guiaDao = new Dao<Guia>();
            var factoryCancelamento = new FactoryCancelamentoGuia();

            var guia = guiaDao.GetById(handle);
            var cancelamento = factoryCancelamento.ObterCancelamento();

            cancelamento.CancelarGuia(guia);
        }
    }
}