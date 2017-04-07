using Conceitos.InjecaoDependencias.DIP.ComDip.ParametrosSistema;
using Conceitos.InjecaoDependencias.DIP.Dummies.ParametrosSistema;

namespace Conceitos.InjecaoDependencias.ServiceLocator.ComServiceLocator.ParametrosSistema
{
    public class ParametrosSistemaLocal : IParametrosSistema
    {
        private IWebConfig webConfig;

        public ParametrosSistemaLocal(IServiceLocator locator)
        {
            webConfig = locator.Resolve<IWebConfig>();
        }

        public string ObterDiretorioTemporarioSistema()
        {
            return webConfig.DiretorioTemporario;
        }

        public string ObterEnderecoCliente()
        {
            return webConfig.EnderecoCliente;
        }
    }
}
