using Conceitos.InjecaoDependencias.DIP.ComDip.ParametrosSistema;
using Conceitos.InjecaoDependencias.DIP.Dummies.ParametrosSistema;

namespace Conceitos.InjecaoDependencias.ServiceLocator.ComServiceLocator.ParametrosSistema
{
    public class RequisicaoCliente : IRequisicaoCliente
    {
        private IParametrosSistema parametrosSistema;
        private IHttpClient httpClient;

        public RequisicaoCliente(IServiceLocator locator)
        {
            parametrosSistema = locator.Resolve<IParametrosSistema>();
            httpClient = locator.Resolve<IHttpClient>();
        }

        public object GetSync(string uriServico)
        {
            var enderecoCliente = parametrosSistema.ObterEnderecoCliente();
            return httpClient.GetSync(new { url = enderecoCliente });
        }
    }
}
