using System.IO;
using UmDesignPatternPorSemana.Proxy.TissSolicitacaoStatusProtocolo;

namespace UmDesignPatternPorSemana.Proxy
{
    public class RemoteProxy
    {
        public void Exemplo()
        {
            var client = new tissSolicitacaoStatusProtocolo_PortTypeClient();
            var request = new solicitacaoStatusProtocoloWS();
            var response = client.tissSolicitacaoStatusProtocolo_Operation(request);
        }
    }
}
