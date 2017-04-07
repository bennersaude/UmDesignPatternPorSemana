using System;
using Conceitos.InjecaoDependencias.DIP.Dummies.ParametrosSistema;

namespace Conceitos.InjecaoDependencias.ServiceLocator.ComServiceLocator.ParametrosSistema
{
    public class ParametrosSistema : IParametrosSistema
    {
        private IPorConfigPortalDao dao;

        public ParametrosSistema(IServiceLocator locator)
        {
            dao = locator.Resolve<IPorConfigPortalDao>();
        }

        public string ObterDiretorioTemporarioSistema()
        {
            return dao.GetFirstOrDefault().DiretorioTemporario;
        }

        public string ObterEnderecoCliente()
        {
            return dao.GetFirstOrDefault().EnderecoCliente;
        }
    }
}
