using Conceitos.InjecaoDependencias.DIP.Dummies.ParametrosSistema;

namespace Conceitos.InjecaoDependencias.DIP.SemDIP.ParametrosSistema
{
    public class ParametrosSistema : IParametrosSistema
    {
        private readonly PorConfigPortal _porConfigPortal;

        public ParametrosSistema()
        {
            _porConfigPortal = PorConfigPortal.GetFirstOrDefault();
        }
            
        public string ObterDiretorioTemporarioSistema()
        {
            return _porConfigPortal.DiretorioTemporario;
        }

        public string ObterEnderecoCliente()
        {
            return _porConfigPortal.EnderecoCliente;
        }
    }
}
