using Conceitos.InjecaoDependencias.DIP.Dummies.ParametrosSistema;

namespace Conceitos.InjecaoDependencias.DIP.ComDip.ParametrosSistema
{
    public class FactoryParametrosSistema : IFactoryParametrosSistema
    {
        public IParametrosSistema ObterParametrosSistema()
        {
            if (System.Diagnostics.Debugger.IsAttached) return new ParametrosSistemaLocal(new WebConfig());

            return new ParametrosSistema(new PorConfigPortalDao());
        }
    }
}
