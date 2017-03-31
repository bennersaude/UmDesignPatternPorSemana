using Conceitos.InjecaoDependencias.DIP.Dummies.ParametrosSistema;

namespace Conceitos.InjecaoDependencias.DIP.ComDip.ParametrosSistema
{
    public interface IFactoryParametrosSistema
    {
        IParametrosSistema ObterParametrosSistema();
    }
}