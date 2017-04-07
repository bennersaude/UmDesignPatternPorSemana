using Conceitos.InjecaoDependencias.DIP.ComDip.ParametrosSistema;

namespace Conceitos.InjecaoDependencias.ServiceLocator.SemServiceLocator
{
    public class EnvioLotes : IEnvioLotes
    {
        private IHttpClient client;

        public EnvioLotes(IHttpClient client)
        {
            this.client = client;
        }

        public void EnviarLote(Lote lote)
        {
            client.GetSync(lote);
        }
    }
}
