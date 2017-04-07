using Conceitos.InjecaoDependencias.DIP.ComDip.ParametrosSistema;
using Conceitos.InjecaoDependencias.DIP.Dummies.ParametrosSistema;
using Conceitos.InjecaoDependencias.ServiceLocator.SemServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conceitos.InjecaoDependencias.ServiceLocator.ComServiceLocator.ProcessamentoLotes
{
    public class ServiceLocatorRegistration
    {
        public static IServiceLocator Locator { get; private set; }

        public IServiceLocator ObterLocator()
        {
            var locator = new ServiceLocator();

            locator.Register<IHttpClient, HttpClient>(() => new HttpClient());
            locator.Register<IValidacaoGuias, ValidacaoGuias>(() => new ValidacaoGuias());
            locator.Register<IGeracaoLotes, GeracaoLotes>(() => new GeracaoLotes(locator));
            locator.Register<IEnvioLotes, EnvioLotes>(() => new EnvioLotes(locator));
            locator.Register<IProcessamentoLotes, ProcessamentoLotes>(() => new ProcessamentoLotes(locator));

            Locator = locator;
            return locator;
        }
    }
}
