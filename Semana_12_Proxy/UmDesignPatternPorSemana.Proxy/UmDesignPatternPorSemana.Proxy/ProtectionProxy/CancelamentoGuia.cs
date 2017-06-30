using System;
using UmDesignPatternPorSemana.Proxy.ProtectionProxy.Stubs;

namespace UmDesignPatternPorSemana.Proxy.ProtectionProxy
{
    public class CancelamentoGuia : ICancelamentoGuia
    {
        private readonly IDao<Guia> guiaDao;

        public CancelamentoGuia(IDao<Guia> guiaDao)
        {
            this.guiaDao = guiaDao;
        }

        public void CancelarGuia(Guia guia)
        {
            guia.Situacao = Situacao.Cancelada;
            guia.DataCancelamento = DateTime.Today;

            guiaDao.Save(guia);
        }
    }
}