using Conceitos.InjecaoDependencias.DIP.Dummies.ParametrosSistema;

namespace Conceitos.InjecaoDependencias.DIP.SemDIP.ParametrosSistema
{
    public class RequisicaoCliente
    {
        private IParametrosSistema parametrosSistema;
        private HttpClient client;

        public RequisicaoCliente()
        {
            parametrosSistema = new ParametrosSistema();
            client = new HttpClient();
        }

        public object GetSync(string uriServico)
        {
            var enderecoCliente = parametrosSistema.ObterEnderecoCliente();
            return client.GetSync(new { url = enderecoCliente });
        }

    }
}
