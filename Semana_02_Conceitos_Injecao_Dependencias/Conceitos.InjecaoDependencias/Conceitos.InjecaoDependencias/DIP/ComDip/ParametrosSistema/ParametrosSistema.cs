using System;
using Conceitos.InjecaoDependencias.DIP.Dummies.ParametrosSistema;

namespace Conceitos.InjecaoDependencias.DIP.ComDip.ParametrosSistema
{
    public class ParametrosSistema : IParametrosSistema
    {
        private IPorConfigPortalDao dao;

        public ParametrosSistema(IPorConfigPortalDao dao)
        {
            this.dao = dao;
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
