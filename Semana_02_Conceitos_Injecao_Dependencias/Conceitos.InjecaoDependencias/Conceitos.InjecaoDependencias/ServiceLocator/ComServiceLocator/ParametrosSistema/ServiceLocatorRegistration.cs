using Conceitos.InjecaoDependencias.DIP.ComDip.ParametrosSistema;
using Conceitos.InjecaoDependencias.DIP.Dummies.ParametrosSistema;

namespace Conceitos.InjecaoDependencias.ServiceLocator.ComServiceLocator.ParametrosSistema
{
    public class ServiceLocatorRegistration
    {
        public static IServiceLocator Locator { get; private set; }

        public IServiceLocator ObterLocator()
        {
            var locator = new ServiceLocator();

            locator.Register<IHttpClient, HttpClient>(() => new HttpClient());
            locator.Register<IWebConfig, WebConfig>(() => new WebConfig());
            locator.Register<IRequisicaoCliente, RequisicaoCliente>(() => new RequisicaoCliente(locator));
            locator.Register<IPorConfigPortalDao, PorConfigPortal>(() => new PorConfigPortal());
            locator.Register<IParametrosSistema, IParametrosSistema>(() => {
                if (System.Diagnostics.Debugger.IsAttached) return new ParametrosSistemaLocal(locator);

                return new ParametrosSistema(locator);
            });

            Locator = locator;
            return locator;
        }
    }
}
