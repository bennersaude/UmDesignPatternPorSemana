using Conceitos.InjecaoDependencias.DIP.ComDip.ParametrosSistema;

namespace Conceitos.InjecaoDependencias.DIP.Dummies.ParametrosSistema
{
    public class HttpClient : IHttpClient
    {
        public HttpClient()
        {

        }

        public object GetSync(object parametros)
        {
            return null;
        }
    }
}
