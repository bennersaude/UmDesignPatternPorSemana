using Conceitos.InjecaoDependencias.DIP.ComDip.ParametrosSistema;
using Conceitos.InjecaoDependencias.ServiceLocator.SemServiceLocator;

namespace Conceitos.InjecaoDependencias.ServiceLocator.ComServiceLocator.ProcessamentoLotes
{
    public class EnvioLotes : IEnvioLotes
    {
        private IHttpClient client;

        public EnvioLotes(IServiceLocator locator)
        {
            client = locator.Resolve<IHttpClient>();
        }

        public void EnviarLote(Lote lote)
        {
            client.GetSync(lote);
        }
    }
}
