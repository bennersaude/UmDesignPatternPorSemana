using Conceitos.InjecaoDependencias.DIP.Dummies.ParametrosSistema;

namespace Conceitos.InjecaoDependencias.DIP.ComDip.ParametrosSistema
{
    public class ParametrosSistemaLocal : IParametrosSistema
    {
        private IWebConfig webConfig;

        public ParametrosSistemaLocal(IWebConfig webConfig)
        {
            this.webConfig = webConfig;
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
