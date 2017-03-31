using Conceitos.InjecaoDependencias.DIP.Dummies.ParametrosSistema;

namespace Conceitos.InjecaoDependencias.DIP.ComDip.ParametrosSistema
{
    public class RequisicaoCliente
    {
        private IParametrosSistema parametrosSistema;
        private IHttpClient httpClient;

        public RequisicaoCliente(IFactoryParametrosSistema factoryParametrosSistema, IHttpClient httpClient)
        {
            parametrosSistema = factoryParametrosSistema.ObterParametrosSistema();
            this.httpClient = httpClient;
        }

        public object GetSync(string uriServico)
        {
            var enderecoCliente = parametrosSistema.ObterEnderecoCliente();
            return httpClient.GetSync(new { url = enderecoCliente });
        }
    }
}
